using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3AWS_Sample.Code
{
    class Misc
    {
        public static string GetContentType(string fileExtension)
        {
            string contentType = string.Empty;
            switch (fileExtension)
            {
                case "bmp": contentType = "image/bmp"; break;
                case "jpeg": contentType = "image/jpeg"; break;
                case "jpg": contentType = "image/jpg"; break;
                case "gif": contentType = "image/gif"; break;
                case "tiff": contentType = "image/tiff"; break;
                case "png": contentType = "image/png"; break;
                case "plain": contentType = "text/plain"; break;
                case "rtf": contentType = "text/rtf"; break;
                case "msword": contentType = "application/msword"; break;
                case "zip": contentType = "application/zip"; break;
                case "mpeg": contentType = "audio/mpeg"; break;
                case "pdf": contentType = "application/pdf"; break;
                case "xgzip": contentType = "application/x-gzip"; break;
                case "xcompressed": contentType = "applicatoin/x-compressed"; break;
            }
            return contentType;
        }

        public static void SaveStreamToFile(string fileFullPath, Stream stream)
        {
            using (stream)
            {
                using (FileStream fs = new FileStream(fileFullPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = new byte[32768];
                    int bytesRead = 0;
                    do
                    {
                        bytesRead = stream.Read(data, 0, data.Length);
                        fs.Write(data, 0, bytesRead);
                    }
                    while (bytesRead > 0);
                    fs.Flush();
                }
            }

        }
    }
}
