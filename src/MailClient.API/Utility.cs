﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.API
{
    public class Utility
    {
        public static string Base64UrlEncode(string input)
        {
            //Using System.Text.Encoding.UTF8.GetBytes method
            var inputBytes = Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
    }
}
