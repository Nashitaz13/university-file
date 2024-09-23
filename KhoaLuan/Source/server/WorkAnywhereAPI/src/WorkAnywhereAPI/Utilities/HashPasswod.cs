using System;
using System.Security.Cryptography;
using System.Text;

namespace WorkAnywhereAPI.Utilities
{
  public static class HashPasswod
    {
        private readonly static string salt = "NZsP6NnmfBuYeJrrAKNuVQ==";

        public static string EncryptPassword(string password)
        {
            var sha = SHA256.Create();
            var saltedHashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(password + salt)));
            return saltedHashedPassword;
        }
    }
}
