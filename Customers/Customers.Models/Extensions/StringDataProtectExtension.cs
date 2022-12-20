using System;
using System.Collections;
using System.Security.Cryptography;

namespace Customers.Models.Extensions
{
	public static class StringDataProtectExtension
	{
        private static string Encryptor(string _data)
        {
            if (string.IsNullOrEmpty(_data))
            {
                return "";
            }
            byte[] data = System.Text.Encoding.UTF8.GetBytes(_data);
            byte[] result;
            SHA512 shaM = SHA512.Create();
            result = shaM.ComputeHash(data);
            return System.Text.Encoding.UTF8.GetString(result) ?? "";
        }

        public static string Encrypt(this string data)
        {
            return Encryptor(data);
        }
    }
}

