using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Utilities
{
    public static class FileManager
    {
        public static string findExtension(string filename)
        {
            int pointIndex = filename.IndexOf('.');
            string extension = filename.Substring(pointIndex);
            return extension;
        }
        
        public static string saveFile(FileUPloadAPI file)
        {
            string fileName = file.files.FileName;
            string destination = AppDomain.CurrentDomain.BaseDirectory + "/Database";


            switch (findExtension(fileName))
            {
                case ".jpg":
                    destination += "/photos/";
                    break;
                case ".jpeg":
                    destination += "/photos/";
                    break;
                case ".png":
                    destination += "/photos/";
                    break;
                case ".gpx":
                    destination += "/gpxs/";
                    break;
                default:
                    return null;
            }

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            using (FileStream fileStream = System.IO.File.Create(destination + "/" + file.files.FileName))
            {
                file.files.CopyTo(fileStream);
                fileStream.Flush();
                return destination + "/" + file.files.FileName;
            }
        }
    }
}
