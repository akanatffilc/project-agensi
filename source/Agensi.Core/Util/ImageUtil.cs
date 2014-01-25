using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Util
{
    public static class ImageUtil
    {
        /// <summary>
        /// ImageBinaryをBase64Stringに返還する
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public static string ToImageBase64(byte[] imageData)
        {
            if (imageData == null)
                return "";

            return Convert.ToBase64String(imageData);
        }


        /// <summary>
        /// imageBinaryをImageに変換する
        /// </summary>
        /// <param name="imageBinary"></param>
        /// <returns></returns>
        public static string ToImageSrc(byte[] imageBinary)
        {
            if (imageBinary == null)
                return "";

            Image image = null;
            var imageType = "";
            using (var stream = new MemoryStream(imageBinary))
            {
                image = Image.FromStream(stream);

                if (ImageFormat.Jpeg.Equals(image.RawFormat))
                {
                    imageType = "image/jpeg";
                }
                else if (ImageFormat.Png.Equals(image.RawFormat))
                {
                    imageType = "image/png";
                }
                else if (ImageFormat.Gif.Equals(image.RawFormat))
                {
                    imageType = "image/gif";
                }
                else
                {
                    throw new Exception("画像フォーマットが非対応です。");
                }
            }

            var base64 = Convert.ToBase64String(imageBinary);

            var stringImageSrc = string.Format("data:{0};base64, {1}", imageType, base64);
            return stringImageSrc;
        }
    }
}
