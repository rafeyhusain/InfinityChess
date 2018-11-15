using System;
using System.Management;

namespace App.Model
{
    #region BlockMachineE
    public enum BlockMachineE
    {
        Initialized = 0,
        Done = 1,
    }
    #endregion

    public class WmiHelper
    {
        public static  string GetMachineKey()
        {
            String processorId = GetWmiData("Win32_Processor", "ProcessorId");
            String boardId = GetWmiData("Win32_BaseBoard", "SerialNumber");
            return processorId + boardId;
        }

        private static  string GetWmiData(String strClass, String strProperty)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + strClass);
                foreach (ManagementObject queryObj in searcher.Get())
                    return queryObj.GetPropertyValue(strProperty).ToString();
            }
            catch 
            {
                return String.Empty;
            }
            return String.Empty;
        }
    }
}
