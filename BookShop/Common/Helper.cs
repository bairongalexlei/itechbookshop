﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Common
{
    public static class Helper
    {
        public static string TrimString(string strToTrim)
        {
            if (string.IsNullOrEmpty(strToTrim))
                return strToTrim;

            var resultString = strToTrim.Trim();
            return resultString;
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn, string imageExtension)
        {
            if (string.IsNullOrEmpty(imageExtension) || imageIn == null)
                return null;

            try
            {
                string imageExt = imageExtension.ToUpper();

                using (var ms = new MemoryStream())
                {
                    if (imageExt.Equals(System.Drawing.Imaging.ImageFormat.Gif.ToString().ToUpper()))
                        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    else if (imageExt.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.ToString().ToUpper()))
                        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    else if (imageExt.Equals("JPG"))
                        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    else if (imageExt.Equals(System.Drawing.Imaging.ImageFormat.Png.ToString().ToUpper()))
                        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    else
                        return null;

                    return ms.ToArray();
                }
            }
            catch 
            {
                return null;
            }
        }
    }
}
