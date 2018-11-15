using System;
using BackgroundCopyManager;
using System.Data;
using App.Model.Db;
using System.IO;
using System.Collections.Generic;

namespace App.Model
{
    public class UpdateUtility
    {
        #region Methods
        public static System.Guid ConvertToGuid(GUID bitsGuid)
        {
            Guid guid = new System.Guid(bitsGuid.Data1, bitsGuid.Data2, bitsGuid.Data3, bitsGuid.Data4[0], bitsGuid.Data4[1], bitsGuid.Data4[2], bitsGuid.Data4[3], bitsGuid.Data4[4], bitsGuid.Data4[5], bitsGuid.Data4[6], bitsGuid.Data4[7]);
            return guid;
        }

        public static GUID ConvertToBitsGuid(System.Guid value)
        {
            GUID myGuid;
            Byte[] inGuid;
            System.UInt32 data1;
            System.UInt16 data2;
            System.UInt16 data3;
            Byte[] data4 = new Byte[8];
            inGuid = value.ToByteArray();
            data1 = System.BitConverter.ToUInt32(inGuid, 0);
            data2 = System.BitConverter.ToUInt16(inGuid, 4);
            data3 = System.BitConverter.ToUInt16(inGuid, 6);
            Array.Copy(inGuid, 8, data4, 0, 8);
            myGuid.Data1 = data1;
            myGuid.Data2 = data2;
            myGuid.Data3 = data3;
            myGuid.Data4 = data4;
            return myGuid;
        }

        public static DataSet GetAvailablePatches(string version)
        {
            DataSet ds = SocketClient.GetAvailablePatches(version);
            return ds;
        }

        public static DataTable GetPatchesFiles(string version)
        {
            Kv kv = new Kv();
            List<string> pFiles = new List<string>();

            string path = KeyValues.Instance.GetKeyValue(KeyValueE.PatchPath).Value;

            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                string pExt = ".zip";
                FileInfo[] files = dir.GetFiles("*" + pExt);
                string pVersion = "";
                int pNo = 1;
                long patchSize = 0;// in MB

                foreach (FileInfo item in files)
                {
                    pVersion = item.Name.Replace(pExt, "");
                    if (IsUpgradeRequired(version, pVersion))
                    {
                        kv.Set("PatchFile" + pNo++, item.Name);
                        patchSize = patchSize + (item.Length / 1000 / 1000);// in MB
                    }
                }
                if (patchSize > 0)
                {
                    kv.Set("PatchSize", patchSize);
                }

                string setupFile = path + "\\InfinityChess.msi";
                if (File.Exists(setupFile))
                {
                    FileInfo fi = new FileInfo(setupFile);
                    kv.Set("SetupSize", fi.Length / 1000 / 1000); // in MB
                }
            }
            return kv.DataTable;
        }

        public static bool IsUpgradeRequired(string currentVer, string newVer)
        {
            try
            {
                Version currentVersion = new Version(currentVer);
                Version newVersion = new Version(newVer);

                return IsUpgradeRequired(currentVersion, newVersion);
            }
            catch (Exception ex)
            {
                return false;
            }            
        }

        public static bool IsUpgradeRequired(Version currentVer, Version newVer)
        {
            bool isRequired = false;

            if (newVer.Major > currentVer.Major)
            {
                isRequired = true;
            }
            else if (newVer.Major < currentVer.Major)
            {
                isRequired = false;
            }
            else if (newVer.Minor > currentVer.Minor)
            {
                isRequired = true;
            }
            else if (newVer.Minor < currentVer.Minor)
            {
                isRequired = false;
            }
            else if (newVer.Build > currentVer.Build)
            {
                isRequired = true;
            }
            else if (newVer.Build < currentVer.Build)
            {
                isRequired = false;
            }
            else if (newVer.Revision > currentVer.Revision)
            {
                isRequired = true;
            }
            else if (newVer.Revision < currentVer.Revision)
            {
                isRequired = false;
            }

            return isRequired;
        }

        #endregion
    }
}
