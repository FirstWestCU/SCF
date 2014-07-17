using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Coop
{
    public static class HashGenerator
    {
        /// <summary>
        /// Salts and hashes the given key using SHA-512. DO NOT USE FOR PASSWORD HASHES!
        /// </summary>
        /// <param name="key">The value to hash</param>
        /// <returns>Salted and Hashed value</returns>
        public static string GenerateHash(string key)
        {
            key = "56fsaD" + key + "23!";
            SHA512 shaM = new SHA512Managed();
            ASCIIEncoding shamByte = new ASCIIEncoding();
            string hash = Convert.ToBase64String(shaM.ComputeHash(shamByte.GetBytes(key))).Replace("+", "-").Replace("/", "_");
            return hash;
        }
    }
}