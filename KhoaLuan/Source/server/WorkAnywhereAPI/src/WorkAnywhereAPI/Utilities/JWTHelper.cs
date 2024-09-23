using System.IdentityModel.Tokens.Jwt;

namespace WorkAnywhereAPI.Utilities
{
    public static class JWTHelper
    {
        public static string GetUserNameFromToken(string token)
        {
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            foreach(var item in jwtSecurityToken.Claims)
            {
                if(item.Type == JwtRegisteredClaimNames.Sub)
                {
                    return item.Value;
                }
            }
            return string.Empty;
        }
    }
}
