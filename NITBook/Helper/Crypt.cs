using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace NITBook.Helper
{
    public class Crypt
    {
        public static string Encryption(string admin,string password)
        {
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(admin));
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}