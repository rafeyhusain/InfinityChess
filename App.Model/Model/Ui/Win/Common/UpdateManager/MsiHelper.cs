using System;
using System.Text;
using System.Runtime.InteropServices; 

namespace App.Model
{
    #region Enums
    public enum MsiErrorE : uint
    {
        /// <summary>No error occured.</summary>
        NoError = 0,
        /// <summary>The operation was successful.</summary>
        Success = 0,
        /// <summary>The system cannot find the file specified.</summary>
        FileNotFound = 2,
        /// <summary>Access is denied.</summary>
        AccessDenied = 5,
        /// <summary>The handle is invalid.</summary>
        InvalidHandle = 6,
        /// <summary>Not enough storage is available to process this command.</summary>
        NotEnoughMemory = 8,
        /// <summary>The data is invalid.</summary>
        InvalidData = 13,
        /// <summary>Not enough storage is available to complete this operation.</summary>
        OutOfMemory = 14,
        /// <summary>The parameter is incorrect.</summary>
        InvalidParameter = 87,
        /// <summary>The system cannot open the device or file specified.</summary>
        OpenFailed = 110,
        /// <summary>There is not enough space on the disk.</summary>
        DiskFull = 112,
        /// <summary>This function is not available for this platform. It is only available on Windows 2000 and Windows XP with Window Installer version 2.0.</summary>
        CallNotImplemented = 120,
        /// <summary>The specified path is invalid.</summary>
        BadPathName = 161,
        /// <summary>No data is available.</summary>
        NoData = 232,
        /// <summary>More data is available.</summary>
        MoreData = 234,
        /// <summary>No more data is available.</summary>
        NoMoreItems = 259,
        /// <summary>The directory name is invalid.</summary>
        Directory = 267,
        /// <summary>The volume for a file has been externally altered so that the opened file is no longer valid.</summary>
        FileInvalid = 1006,
        /// <summary>This error code only occurs when using Windows Installer version 2.0 and Windows XP. If Windows Installer determines a product may be incompatible with the current operating system, it displays a dialog box informing the user and asking whether to try to install anyway. This error code is returned if the user chooses not to try the installation.</summary>
        AppHelpBlock = 1259,
        /// <summary>The Windows Installer service could not be accessed.</summary>
        InstallServiceFailure = 1601,
        /// <summary>The user cancels installation.</summary>
        InstallUserExit = 1602,
        /// <summary>A fatal error occurred during installation.</summary>
        InstallFailure = 1603,
        /// <summary>Installation suspended, incomplete.</summary>
        InstallSuspend = 1604,
        /// <summary>This action is only valid for products that are currently installed.</summary>
        UnknownProduct = 1605,
        /// <summary>The feature identifier is not registered.</summary>
        UnknownFeature = 1606,
        /// <summary>The component identifier is not registered.</summary>
        UnknownComponent = 1607,
        /// <summary>This is an unknown property.</summary>
        UnknownProperty = 1608,
        /// <summary>The handle is in an invalid state.</summary>
        InvalidHandleState = 1609,
        /// <summary>The configuration data for this product is corrupt.</summary>
        BadConfiguration = 1610,
        /// <summary>The component qualifier not present.</summary>
        IndexAbsent = 1611,
        /// <summary>The installation source for this product is not available. Verify that the source exists and that you can access it.</summary>
        InstallSourceAbsent = 1612,
        /// <summary>This installation package cannot be installed by the Windows Installer service. You must install a Windows service pack that contains a newer version of the Windows Installer service.</summary>
        InstallPackageVersion = 1613,
        /// <summary>The product is uninstalled.</summary>
        ProductUninstalled = 1614,
        /// <summary>The SQL query syntax is invalid or unsupported.</summary>
        BadQuerySyntax = 1615,
        /// <summary>The record field does not exist.</summary>
        InvalidField = 1616,
        /// <summary>Another installation is already in progress.</summary>
        InstallAlreadyRunning = 1618,
        /// <summary>This installation package could not be opened. Verify that the package exists and is accessible, or contact the application vendor to verify that this is a valid Windows Installer package.</summary>
        InstallPackageOpenFailed = 1619,
        /// <summary>This installation package could not be opened. Contact the application vendor to verify that this is a valid Windows Installer package.</summary>
        InstallPackageInvalid = 1620,
        /// <summary>There was an error starting the Windows Installer service user interface. </summary>
        InstallUIFailure = 1621,
        /// <summary>There was an error opening installation log file. Verify that the specified log file location exists and is writable.</summary>
        InstallLogFailure = 1622,
        /// <summary>This language of this installation package is not supported by your system.</summary>
        InstallLanguageUnsupported = 1623,
        /// <summary>There was an error applying transforms. Verify that the specified transform paths are valid.</summary>
        InstallTransformFailure = 1624,
        /// <summary>This installation is forbidden by system policy.</summary>
        InstallPackageRejected = 1625,
        /// <summary>The function could not be executed.</summary>
        FunctionNotCalled = 1626,
        /// <summary>The function failed during execution.</summary>
        FunctionFailed = 1627,
        /// <summary>An invalid or unknown table was specified.</summary>
        InvalidTable = 1628,
        /// <summary>The data supplied is the wrong type.</summary>
        DatatypeMismatch = 1629,
        /// <summary>Data of this type is not supported.</summary>
        UnsupportedType = 1630,
        /// <summary>The Windows Installer service failed to start.</summary>
        CreateFailed = 1631,
        /// <summary>The Temp folder is either full or inaccessible. Verify that the Temp folder exists and that you can write to it.</summary>
        InstallTempUnwritable = 1632,
        /// <summary>This installation package is not supported on this platform.</summary>
        InstallPlatformUnsupported = 1633,
        /// <summary>Component is not used on this machine.</summary>
        InstallNotUsed = 1634,
        /// <summary>This patch package could not be opened.</summary>
        PatchPackageOpenFailed = 1635,
        /// <summary>This patch package could not be opened</summary>
        PatchPackageInvalid = 1636,
        /// <summary>This patch package cannot be processed by the Windows Installer service.</summary>
        PatchPackageUnsupported = 1637,
        /// <summary>Another version of this product is already installed. Installation of this version cannot continue. To configure or remove the existing version of this product, use Add/Remove Programs in Control Panel.</summary>
        ProductVersion = 1638,
        /// <summary>Invalid command line argument. Consult the Windows Installer SDK for detailed command-line help.</summary>
        InvalidCommandLine = 1639,
        /// <summary>Installation from a Terminal Server client session is not permitted for the current user.</summary>
        InstallRemoteDisallowed = 1640,
        /// <summary>The installer has initiated a restart. This error code is not available on Windows Installer version 1.0.</summary>
        SuccessRebootInitiated = 1641,
        /// <summary>The installer cannot install the upgrade patch because the program being upgraded may be missing or the upgrade patch updates a different version of the program. Verify that the program to be upgraded exists on your computer and that you have the correct upgrade patch. This error code is not available on Windows Installer version 1.0.</summary>
        PatchTargetNotFound = 1642,
        /// <summary>The patch package is not permitted by system policy. This error code is available with Windows Installer versions 2.0.</summary>
        InstallTransformRejected = 1643,
        /// <summary>One or more customizations are not permitted by system policy. This error code is available with Windows Installer versions 2.0.</summary>
        InstallRemoteProhibited = 1644,
        /// <summary>The specified datatype is invalid.</summary>
        InvalidDataType = 1804,
        /// <summary>The specified username is invalid.</summary>
        BadUserName = 2202,
        /// <summary>A restart is required to complete the install. This does not include installs where the ForceReboot action is run. This error code is not available on Windows Installer version 1.0.</summary>
        SucessRebootRequired = 3010,
        /// <summary>Unspecified error.</summary>
        E_Fail = 0x80004005,
    }
    #endregion

    public class MsiHelper
    {
        #region Data members
        private const String MSI_LIB = "msi.dll";

        [DllImport(MSI_LIB, CharSet = CharSet.Unicode)]
        extern static Int32 MsiGetProductInfo(string product,
            string property, [Out] StringBuilder valueBuf, ref Int32 len);

        [DllImport(MSI_LIB, CharSet = CharSet.Auto)]
        extern static MsiErrorE MsiApplyPatch(string patchPackage,
            string installPackage, Int32 installType, string commandLine); 
        #endregion

        #region Methods
        public static Version GetVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        public static Version GetVersion(String productCode)
        {
            Int32 bufferLength = 512;
            var versionBuilder = new StringBuilder(bufferLength);

            var result = MsiGetProductInfo(productCode, "VersionString", versionBuilder, ref bufferLength);

            if (result == 1605)
                throw new Exception("Invalid product code.");

            String[] versionParts = versionBuilder.ToString().Split('.');

            Version version = new Version(Convert.ToInt32(versionParts[0]), Convert.ToInt32(versionParts[1]), Convert.ToInt32(versionParts[2]));
            
            return version;
        }

        public static MsiErrorE ApplyPatch(String patchPath)
        {
            return MsiApplyPatch(patchPath, "", 0, "REINSTALL=ALL REINSTALLMODE=omus");
        } 

        public static string GetMsg(MsiErrorE msgId)
        {
            switch (msgId)
            {
                case MsiErrorE.Success:
                    return "The operation was successful.";
                case MsiErrorE.FileNotFound:
                    return "The system cannot find the file specified.";
                case MsiErrorE.AccessDenied:
                    return "Access is denied.";
                case MsiErrorE.InvalidHandle:
                    return "The handle is invalid.";
                case MsiErrorE.NotEnoughMemory:
                    return "Not enough storage is available to process this command.";
                case MsiErrorE.InvalidData:
                    return "The data is invalid.";
                case MsiErrorE.OutOfMemory:
                    return "Not enough storage is available to complete this operation.";   
                case MsiErrorE.InvalidParameter:
                    return "The parameter is incorrect.";
                case MsiErrorE.OpenFailed:
                    return "The system cannot open the device or file specified.";
                case MsiErrorE.DiskFull:
                    return "There is not enough space on the disk.";      
                case MsiErrorE.CallNotImplemented:
                    return "This function is not available for this platform. It is only available on Windows 2000 and Windows XP with Window Installer version 2.0.";
                case MsiErrorE.BadPathName:
                    return "The specified path is invalid.";
                case MsiErrorE.NoData:
                    return "No data is available.";
                case MsiErrorE.MoreData:
                    return "More data is available.";
                case MsiErrorE.NoMoreItems:
                    return "No more data is available.";
                case MsiErrorE.Directory:
                    return "The directory name is invalid.";
                case MsiErrorE.FileInvalid:
                    return "The volume for a file has been externally altered so that the opened file is no longer valid.";
                case MsiErrorE.AppHelpBlock:
                    return "Product is not compatible with the current operating system.";
                case MsiErrorE.InstallServiceFailure:
                    return "The Windows Installer service could not be accessed.";
                case MsiErrorE.InstallUserExit:
                    return "The user cancels installation.";
                case MsiErrorE.InstallFailure:
                    return "A fatal error occurred during installation.";
                case MsiErrorE.InstallSuspend:
                    return "Installation suspended, incomplete.";
                case MsiErrorE.UnknownProduct:
                    return "This action is only valid for products that are currently installed.";
                case MsiErrorE.UnknownFeature:
                    return "The feature identifier is not registered.";
                case MsiErrorE.UnknownComponent:
                    return "The component identifier is not registered.";
                case MsiErrorE.UnknownProperty:
                    return "This is an unknown property.";
                case MsiErrorE.InvalidHandleState:
                    return "The handle is in an invalid state.";
                case MsiErrorE.BadConfiguration:
                    return "The configuration data for this product is corrupt.";
                case MsiErrorE.IndexAbsent:
                    return "The component qualifier not present.";
                case MsiErrorE.InstallSourceAbsent:
                    return "The installation source for this product is not available.";
                case MsiErrorE.InstallPackageVersion:
                    return "This installation package cannot be installed by the Windows Installer service.";
                case MsiErrorE.ProductUninstalled:
                    return "The product is uninstalled.";
                case MsiErrorE.BadQuerySyntax:
                    return "The SQL query syntax is invalid or unsupported.";
                case MsiErrorE.InvalidField:
                    return "The record field does not exist.";
                case MsiErrorE.InstallAlreadyRunning:
                    return "Another installation is already in progress.";
                case MsiErrorE.InstallPackageOpenFailed:
                    return "This installation package could not be opened.";
                case MsiErrorE.InstallPackageInvalid:
                    return "This installation package is not valid.";
                case MsiErrorE.InstallUIFailure:
                    return "There was an error starting the Windows Installer service user interface.";
                case MsiErrorE.InstallLogFailure:
                    return "There was an error opening installation log file.";
                case MsiErrorE.InstallLanguageUnsupported:
                    return "The language of this installation package is not supported by system.";
                case MsiErrorE.InstallTransformFailure:
                    return "There was an error applying transforms.";
                case MsiErrorE.InstallPackageRejected:
                    return "This installation is forbidden by system policy.";
                case MsiErrorE.FunctionNotCalled:
                    return "The function could not be executed.";
                case MsiErrorE.FunctionFailed:
                    return "The function failed during execution.";
                case MsiErrorE.InvalidTable:
                    return "An invalid or unknown table was specified.";
                case MsiErrorE.DatatypeMismatch:
                    return "The data supplied is the wrong type.";
                case MsiErrorE.UnsupportedType:
                    return "Data of this type is not supported.";
                case MsiErrorE.CreateFailed:
                    return "The Windows Installer service failed to start.";
                case MsiErrorE.InstallTempUnwritable:
                    return "The Temp folder is either full or inaccessible.";
                case MsiErrorE.InstallPlatformUnsupported:
                    return "This installation package is not supported on this platform.";
                case MsiErrorE.InstallNotUsed:
                    return "Component is not used on this machine.";
                case MsiErrorE.PatchPackageOpenFailed:
                    return "This patch package could not be opened.";
                case MsiErrorE.PatchPackageInvalid:
                    return "This patch package is invalid";
                case MsiErrorE.PatchPackageUnsupported:
                    return "This patch package cannot be processed by the Windows Installer service.";
                case MsiErrorE.ProductVersion:
                    return "Another version of this product is already installed.";
                case MsiErrorE.InvalidCommandLine:
                    return "Invalid command line argument.";
                case MsiErrorE.InstallRemoteDisallowed:
                    return "Installation from a Terminal Server client session is not permitted for the current user.";
                case MsiErrorE.SuccessRebootInitiated:
                    return "The installer has initiated a restart.";
                case MsiErrorE.PatchTargetNotFound:
                    return "The installer cannot install the upgrade patch because the program being upgraded may be missing.";
                case MsiErrorE.InstallTransformRejected:
                    return "The patch package is not permitted by system policy.";
                case MsiErrorE.InstallRemoteProhibited:
                    return "One or more customizations are not permitted by system policy.";
                case MsiErrorE.InvalidDataType:
                    return "The specified datatype is invalid.";
                case MsiErrorE.BadUserName:
                    return "The specified username is invalid.";
                case MsiErrorE.SucessRebootRequired:
                    return "A restart is required to complete the install.";
                case MsiErrorE.E_Fail:
                    return "Unspecified error.";
                default:
                    return msgId.ToString();
           }
        }
        
        #endregion

    }
}
