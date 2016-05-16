using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;

namespace AdminGold.Models
{
    public class ProductsPicture
    {
        public tblSysPicture classPicture { get; set; }
        public string nameProduct { get; set; }
        public string idProducts { get; set; }
        public string cfile { get; set; }
        public string nameImg { get; set; }
        public byte isactive { get; set; }
        public int idpicture { get; set; }
        public int index { get; set; }
        public string GetFilePathPhysical(PictureSize size)
        {
            // check if we have converted files
            //if (IsConverted)
                return DirectoryPhysical + FileName(size);
            //else
            //    return classPicture.originalFilepath;
        }
        public enum PictureSize : int
        {
            Original = 853, // The summ of ascii values of the word "original"
            Large = 1,
            Medium = 2,
            Small = 3,
            Tiny = 4
        }
        public string DirectoryPhysical
        {
            get { return "D:/"; }
        }
        public string FileName(PictureSize size)
        {
            // check if we have converted files
            //if (IsConverted)
            //{
               switch (AngelType)
                {
                    case RotationAngle.Rotated0:
                        return string.Format(classPicture.convertedFilename, (int)size);
                        break;

                    case RotationAngle.Rotated90:
                        if (!string.IsNullOrWhiteSpace(classPicture.convertedFilename90))
                            return string.Format(classPicture.convertedFilename90, (int)size);
                        break;

                    case RotationAngle.Rotated180:
                        if (!string.IsNullOrWhiteSpace(classPicture.convertedFilename180))
                            return string.Format(classPicture.convertedFilename180, (int)size);
                        break;

                    case RotationAngle.Rotated270:
                        if (!string.IsNullOrWhiteSpace(classPicture.convertedFilename270))
                            return string.Format(classPicture.convertedFilename270, (int)size);
                        break;
                }

                return "";
            //}
            //else
            //{
            //    if (classPicture.originalFilepath.StartsWith("http:", StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        return Path.GetFileName(classPicture.originalFilepath);
            //    }
            //    return classPicture.originalFilepath;
            //}
        }
        //public bool IsConverted
        //{
        //    get
        //    {
        //        switch (AngelType)
        //        {
        //            default:
        //                return !string.IsNullOrWhiteSpace(classPicture.convertedFilename);

        //            case RotationAngle.Rotated90:
        //                return !string.IsNullOrWhiteSpace(classPicture.convertedFilename90);

        //            case RotationAngle.Rotated180:
        //                return !string.IsNullOrWhiteSpace(classPicture.convertedFilename180);

        //            case RotationAngle.Rotated270:
        //                return !string.IsNullOrWhiteSpace(classPicture.convertedFilename270);
        //        }
        //    }
        //}
        public RotationAngle AngelType
        {
            get { return (RotationAngle)AngelTypeId; }
            set { AngelTypeId = (int)value; }
        }
        public enum RotationAngle : int
        {
            Rotated0 = 0,
            Rotated90 = 1,
            Rotated180 = 2,
            Rotated270 = 3,
        }
        public int AngelTypeId { get; set; }
        public string GetConvertedFileName()
        {
            // check if we have converted files
            //if (IsConverted)
            //{
                switch (AngelType)
                {
                    case RotationAngle.Rotated0:
                        return classPicture.convertedFilename;
                        break;

                    case RotationAngle.Rotated90:
                        return classPicture.convertedFilename90;
                        break;

                    case RotationAngle.Rotated180:
                        return classPicture.convertedFilename180;
                        break;

                    case RotationAngle.Rotated270:
                        return classPicture.convertedFilename270;
                        break;
                }

                return null;
            //}
            //else
            //    return null;
        }
        public string SetFileName(string filenamePattern)
        {
            // check if we have converted files

            switch (AngelType)
            {
                case RotationAngle.Rotated0:
                    classPicture.convertedFilename = filenamePattern;
                    break;

                case RotationAngle.Rotated90:
                    classPicture.convertedFilename90 = filenamePattern;
                    break;

                case RotationAngle.Rotated180:
                    classPicture.convertedFilename180 = filenamePattern;
                    break;

                case RotationAngle.Rotated270:
                    classPicture.convertedFilename270 = filenamePattern;
                    break;
            }

            return "";
        }
        public string CreateFilename()
        {
            string encoded = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            encoded = encoded.Replace("/", "_").Replace("+", "-");
            return encoded.Substring(0, 22);
        }
        public string GetFilePath(PictureSize size)
        {
            // check if we have converted files
           
                return "D:/"  + FileName(size);
          
        }
        public WatermarkType WaterMarkLarge { get; set; }
        public enum WatermarkType
        {
            [Description("none")]
            None = 0,
            [Description("image")]
            Image,
            [Description("text")]
            Text
        }
    }
}