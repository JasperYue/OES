using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Common;
using System.Drawing;
using System.Collections.Generic;

namespace Common
{
    public class ApplicationUtil
    {
        public static string IMAGE_DIR = AppDomain.CurrentDomain.BaseDirectory + @"\Image";

        public static string BIN_DIR = AppDomain.CurrentDomain.BaseDirectory;

        //public static string CURRENT_PATH = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        /// <summary>
        /// Encrypte password by using MD5
        /// </summary>
        public static string Md5(string password)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(password));
            return BitConverter.ToString(data).Replace("-", "").ToLower();
        }
        /// <summary>
        /// Whether the prev image same with next image
        /// </summary>
        public static bool IsSameImage(Image a, Image b)
        {
            if (a.Width != b.Width || a.Height != b.Height) return false;
            Bitmap p1 = a as Bitmap;
            Bitmap p2 = b as Bitmap;
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    if (p1.GetPixel(x, y) != p2.GetPixel(x, y)) return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Convert name to big camel, like user_name to UserName
        /// </summary>
        public static string Convert2Camel(string name)
        {
            StringBuilder result = new StringBuilder();
            // Quick check
            if (string.IsNullOrEmpty(name))
            {
                // It's unnecessary to convert name
                return string.Empty;
            }
            else if (!name.Contains("_"))
            {
                // Not contain underline, only uppercase the first letter
                return name.Substring(0, 1).ToUpper() + name.Substring(1);
            }

            // Use underline to split string
            String[] camels = name.Split('_');
            foreach (String camel in camels)
            {
                // Skip underline at start, end and double underline
                if (string.IsNullOrEmpty(camel))
                {
                    continue;
                }

                // Handle camel segment
                // Upper the first letter of every segment
                result.Append(camel.Substring(0, 1).ToUpper());
                result.Append(camel.Substring(1).ToLower());
            }
            return result.ToString();
        }
    }
}
