using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace App.Model
{
    public class UImage
    {
        #region Method

        #region GetImageBytes

        public static byte[] GetImageBytes(string filePath)
        {
            if (!UFile.Exists(filePath))
            {
                return null;
            }

            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            byte[] image = new byte[fs.Length];
            fs.Read(image, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            return image;
        }
        #endregion

        #endregion

    }
}
