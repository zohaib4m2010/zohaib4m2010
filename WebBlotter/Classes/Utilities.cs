﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebBlotter.Classes
{
    public class Utilities
    {
        //public static string ComputeStringToSha256Hash(string plainText)
        //{
        //    // Create a SHA256 hash from string   
        //    using (SHA256 sha256Hash = SHA256.Create())
        //    {
        //        // Computing Hash - returns here byte array
        //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

        //        // now convert byte array to a string   
        //        StringBuilder stringbuilder = new StringBuilder();
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            stringbuilder.Append(bytes[i].ToString("x2"));
        //        }
        //        return stringbuilder.ToString();
        //    }
        //}
    }
}