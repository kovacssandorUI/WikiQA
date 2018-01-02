using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WikiQA.Helper
{
    public static class StringExtensions
    {
        /// <summary>
        /// Used to hash any strings into 32 characters hash
        /// </summary>
        /// <param name="input"></param>
        /// <returns>32 characters hash code</returns>
        public static string ToMD5HashString(this string input)
        {
            return MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input)).Select(data => data.ToString("x2")).Aggregate((seed, item) => seed + item);
        }
    }
}
