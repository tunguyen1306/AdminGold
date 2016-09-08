using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace APImyPromotion.Models
{
    public class clsPicture
    {
      
        public tbl_advert_picture_promotion clPicture { get; set; }
        public int idProducts { get; set; }
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
            //    return clPicture.originalFilepath;
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
            get { return "~/fileUpload"; }
        }
        public string FileName(PictureSize size)
        {
           
            switch (AngelType)
            {
                case RotationAngle.Rotated0:
                    return string.Format(clPicture.convertedFilename, (int)size);
                    break;

                case RotationAngle.Rotated90:
                    if (!string.IsNullOrWhiteSpace(clPicture.convertedFilename90))
                        return string.Format(clPicture.convertedFilename90, (int)size);
                    break;

                case RotationAngle.Rotated180:
                    if (!string.IsNullOrWhiteSpace(clPicture.convertedFilename180))
                        return string.Format(clPicture.convertedFilename180, (int)size);
                    break;

                case RotationAngle.Rotated270:
                    if (!string.IsNullOrWhiteSpace(clPicture.convertedFilename270))
                        return string.Format(clPicture.convertedFilename270, (int)size);
                    break;
            }

            return "";
         
        }
       
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
                    return clPicture.convertedFilename;
                    break;

                case RotationAngle.Rotated90:
                    return clPicture.convertedFilename90;
                    break;

                case RotationAngle.Rotated180:
                    return clPicture.convertedFilename180;
                    break;

                case RotationAngle.Rotated270:
                    return clPicture.convertedFilename270;
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
                    clPicture.convertedFilename = filenamePattern;
                    break;

                case RotationAngle.Rotated90:
                    clPicture.convertedFilename90 = filenamePattern;
                    break;

                case RotationAngle.Rotated180:
                    clPicture.convertedFilename180 = filenamePattern;
                    break;

                case RotationAngle.Rotated270:
                    clPicture.convertedFilename270 = filenamePattern;
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

            return FileName(size);

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