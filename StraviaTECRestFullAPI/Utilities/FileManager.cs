using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Utilities
{
    public static class FileManager
    {
        /**
         * Description: Figures out file extension
         * Params:
         * - filename
         * Return: extension for file
         */
        public static string findExtension(string filename)
        {
            int pointIndex = filename.IndexOf('.');
            string extension = filename.Substring(pointIndex);
            return extension.ToLower();
        }
        
        /**
         * Description: Saves file to file system
         * Params:
         * - file: file to be saved
         * - token: token given to the user
         * - id: id of activity
         * - type: type of activity
         * Return: path to image
         */
        public static string saveFile(FileUPloadAPI file, string token, string id, string type)
        {
            string fileName = file.files.FileName;
            string destination = AppDomain.CurrentDomain.BaseDirectory + "/Database";

            bool isGPX = false;

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
                    isGPX = true;
                    break;
                default:
                    return null;
            }
            
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            string fullPath = destination + "/" + file.files.FileName;

            bool dbApproved;


            if (!isGPX)
            {
                dbApproved = Connector.savePhoto(token, fullPath);
            }
            else
            {
                switch (type)
                {
                    case "activity":
                        dbApproved = Connector.saveGPXForActivity(token, id, fullPath);
                        break;
                    default:
                        dbApproved = false;
                        break;
                }
            }

            if (dbApproved)
            {

                using (FileStream fileStream = System.IO.File.Create(fullPath))
                {
                    file.files.CopyTo(fileStream);
                    fileStream.Flush();
                    return destination + "/" + file.files.FileName;
                }

            }

            return null;
        }

        /**
         * Description: Gets a user profile picture
         * - token: token given to client
         * Return: Returns Filestream to user image
         */
        public static FileStream getUserPhoto(string token)
        {
            FileStream picture = File.OpenRead(Connector.getPhotoPath(token));

            if(picture != null)
            {
                return picture;
            }

            return null;
        }

        /**
         * Description: get a gpx related to an activity
         * Params:
         * - id_activity: id of activity
         * Return: Filestream to gpx
         */
        public static FileStream getGPXActivity(string id_activity)
        {
            FileStream picture = File.OpenRead(Connector.getGPXForActivity(id_activity));

            if (picture != null)
            {
                return picture;
            }

            return null;
        }
    }
}
