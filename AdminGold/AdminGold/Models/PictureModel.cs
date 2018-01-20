using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AdminGold.Models
{
    public class PictureModel
    {

        public List<tblPicture> ListPicture { get; set; }
      
        public tblPicture TblPicture { get; set; }
      
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
            //    return tblPicture.originalFilepath;
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
            // check if we have converted files
            //if (IsConverted)
            //{
            switch (AngelType)
            {
                case RotationAngle.Rotated0:
                    return string.Format(TblPicture.ConvertedFilename, (int)size);
                    break;

                case RotationAngle.Rotated90:
                    if (!string.IsNullOrWhiteSpace(TblPicture.ConvertedFilename90))
                        return string.Format(TblPicture.ConvertedFilename90, (int)size);
                    break;

                case RotationAngle.Rotated180:
                    if (!string.IsNullOrWhiteSpace(TblPicture.ConvertedFilename180))
                        return string.Format(TblPicture.ConvertedFilename180, (int)size);
                    break;

                case RotationAngle.Rotated270:
                    if (!string.IsNullOrWhiteSpace(TblPicture.ConvertedFilename270))
                        return string.Format(TblPicture.ConvertedFilename270, (int)size);
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
                    return TblPicture.ConvertedFilename;
                    break;

                case RotationAngle.Rotated90:
                    return TblPicture.ConvertedFilename90;
                    break;

                case RotationAngle.Rotated180:
                    return TblPicture.ConvertedFilename180;
                    break;

                case RotationAngle.Rotated270:
                    return TblPicture.ConvertedFilename270;
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
                    TblPicture.ConvertedFilename = filenamePattern;
                    break;

                case RotationAngle.Rotated90:
                    TblPicture.ConvertedFilename90 = filenamePattern;
                    break;

                case RotationAngle.Rotated180:
                    TblPicture.ConvertedFilename180 = filenamePattern;
                    break;

                case RotationAngle.Rotated270:
                    TblPicture.ConvertedFilename270 = filenamePattern;
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