using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using WorkAnywhereAPI.Models;
using WorkAnywhereAPI.Options;
using WorkAnywhereAPI.Repository;

namespace WorkAnywhereAPI.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly JwtIssuerOptions jwtOptions;
        private readonly ILogger logger;
        private readonly JsonSerializerSettings serializerSettings;
        private string userId;
        /// <summary>
        /// Initial instance of token controller
        /// </summary>
        /// <param name="jwtOptions">The Jwt options</param>
        /// <param name="loggerFactory">Logger factory</param>
        public TokenController(IOptions<JwtIssuerOptions> jwtOptions, ILoggerFactory loggerFactory)
        {
            this.jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(this.jwtOptions);

            this.logger = loggerFactory.CreateLogger<TokenController>();

            this.serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        /// <summary>
        /// Create token
        /// </summary>
        /// <param name="applicationUser">The application user</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateTokenAsync([FromForm] User applicationUser)
        {
            var identity = await GetClaimsIdentity(applicationUser);
            if (identity == null)
            {
                this.logger.LogInformation($"Invalid username ({applicationUser.UserName}) or password ({applicationUser.Password})");
                return BadRequest("Invalid credentials");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, await this.jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(this.jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("ManualUser")
            };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: this.jwtOptions.Issuer,
                audience: this.jwtOptions.Audience,
                claims: claims,
                notBefore: this.jwtOptions.NotBefore,
                expires: this.jwtOptions.Expiration,
                signingCredentials: this.jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Serialize and return the response
            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)jwtOptions.ValidFor.TotalDays,
                id = this.userId
            };

            var json = JsonConvert.SerializeObject(response, this.serializerSettings);
            return new OkObjectResult(json);
        }

        #region Privates methods

        private void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        /// <summary>
        /// Create claims identity
        /// </summary>
        private Task<ClaimsIdentity> GetClaimsIdentity(User user)
        {
            var userRepository = new UserRepository();
            switch (user.AuthType)
            {
                case AuthTypeEnum.Manual:
                    if (userRepository.ValidatedLogin(user, out this.userId))
                    {
                        return Task.FromResult(new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"),
                        new[]
                        {
                            new Claim("ManualUser", "IsManualUser")
                        }));
                    }
                    else
                    {
                        // Credentials are invalid, or account doesn't exist
                        return Task.FromResult<ClaimsIdentity>(null);
                    }
                case AuthTypeEnum.Facebook:
                    if (!userRepository.IsExistUserName(user.UserName, out this.userId))
                    {
                        var guid = Guid.NewGuid().ToString();
                        userRepository.Create(new Models.User()
                        {
                            UserName = user.UserName,
                            AuthType = AuthTypeEnum.Facebook,
                            UserId = guid
                        });
                        this.userId = guid;
                    }
                    return Task.FromResult(new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"),
                      new[]
                      {
                           new Claim("ManualUser", "IsFacebookUser")
                      }));
                case AuthTypeEnum.Google:
                    if (!userRepository.IsExistUserName(user.UserName, out this.userId))
                    {
                        var guid = Guid.NewGuid().ToString();
                        userRepository.Create(new User()
                        {
                            UserName = user.UserName,
                            AuthType = AuthTypeEnum.Google,
                            UserId = guid
                        });
                        this.userId = guid;
                    }
                    return Task.FromResult(new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"),
                      new[]
                      {
                            new Claim("ManualUser", "IsGoogleUser")
                      }));
            }
            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }

        #endregion
    }
}