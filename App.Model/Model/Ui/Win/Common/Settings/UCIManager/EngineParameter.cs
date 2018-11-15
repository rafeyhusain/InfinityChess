using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using App.Model;
using System.IO;
using InfinitySettings.Streams;

namespace InfinitySettings.UCIManager
{
    public class EngineParameters
    {
        #region Deletegates/Events 

        public event EventHandler ParametersLoaded;
        public delegate void ParameterErrorHandler(object sender, string error);
        public event ParameterErrorHandler ParameterError;

        #endregion

        #region DataMemebers

        public Game Game = null;
        public DataTable EngineParameterData = null;
        public string EngineFilePath = "";
        UCIEngine uciEngine;
        public bool IsLoaded = false;
        #endregion

        #region Ctor 

        public EngineParameters(Game game)
        {
            // ValidValue
            // min,max
            // list 1,2,3,4
            this.Game = game;
            EngineParameterData = UData.ToTable2("EngineParameterData", "Name", "Value", "Type", "Default", "ValidValue");
        }

        #endregion

        #region Properties 

        public UCIEngine UCIEngine
        {
            get { return uciEngine; }
        }

        public string EngineParameterFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(EngineFilePath))
                {
                    return "";
                }

                return GetEngineParameterFilePath(Path.GetFileNameWithoutExtension(EngineFilePath));
            }
        }

        public string EngineName
        {
            get
            {
                if (string.IsNullOrEmpty(EngineFilePath))
                {
                    return "";
                }

                return Path.GetFileNameWithoutExtension(EngineFilePath);
            }
        }

        #endregion

        #region Helper Methods

        public static string GetEngineParameterFilePath(string engineName)
        {
            string s = Ap.ParametersFiles.Get(engineName);

            if (string.IsNullOrEmpty(s))
            {
                s = Ap.FolderEngineParameter + engineName + ".param";
            }
            return s;
        }

        public void Init(string engineFilePath)
        {
            EngineFilePath = engineFilePath;
            bool isLoaded = Load(EngineParameterFilePath);
            if (!isLoaded)
            {
                EngineParameterData.Rows.Clear();
                LoadEngine();
            }            
        }

        public void Init(UCIEngine engine)
        {
            if (engine != null)
            {
                EngineFilePath = engine.EngineFile;
                if (engine.HasParametersLoaded)
                {
                    this.EngineParameterData = engine.Parameters.EngineParameterData.Copy();
                    OnParametersLoaded();
                }
                else
                {
                    Init(EngineFilePath);
                }
            }
        }

        #region Engine Events 

        void uciEngine_UciOkReceived(object sender, EventArgs e)
        {
            OnParametersLoaded();
         
            if (EngineParameterData.Rows.Count == 0)
            {
                Save();
            }
        }

        void uciEngine_OptionReceived(object sender, UCIMessageEventArgs e)
        {
            AddParameter(e.Message);
        }

        #endregion

        public bool Load(string engineParameterFilePath)
        {
            if (UFile.Exists(engineParameterFilePath))
            {
                EngineParameterData.Rows.Clear();
                MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(engineParameterFilePath);
                EngineParameterData.ReadXml(memoryStream);
                memoryStream.Close();
                SortParameters();
                OnParametersLoaded();
                return true;
            }
            return false;
        }

        public void LoadEngineParameters(string engineName)
        {
            string path = GetEngineParameterFilePath(engineName);
            Load(path);
        }

        private void SortParameters()
        {
            EngineParameterData.DefaultView.Sort = "Name asc";
            EngineParameterData = EngineParameterData.DefaultView.ToTable(EngineParameterData.TableName);
        }

        public void LoadDefault()
        {
            foreach (DataRow dr in EngineParameterData.Rows)
            {
                dr["Value"] = dr["Default"];
            }
            OnParametersLoaded();
        }

        public void OnParametersLoaded()
        {
            IsLoaded = true;
            if (ParametersLoaded != null)
            {
                ParametersLoaded(this, EventArgs.Empty);
            }
        }

        private void OnParameterError(string error)
        {
            if (ParameterError != null)
            {
                ParameterError(this, error);
            }
        }

        public void Save()
        {
            Save(EngineParameterFilePath);
        }

        public void Save(string paramsFilePath)
        {
            UFile.RemoveReadOnly(paramsFilePath);
            MemoryStream memoryStream = new MemoryStream();
            EngineParameterData.WriteXml(memoryStream);
            InfinityStreamsManager.WriteStreamToFile(paramsFilePath, memoryStream);
            memoryStream.Close();

            Ap.ParametersFiles.Set(EngineName, paramsFilePath);
            Ap.ParametersFiles.Save();
        }

        private DataRow GetRow(string parameterName)
        {
            DataRow[] rows = EngineParameterData.Select("Name='" + parameterName + "'");

            if (rows.Length > 0)
                return rows[0];

            return null;
        }

        public void SetEngineParameters(UCIEngine engine)
        {
            string parameterName = string.Empty;
            string parameterValue = string.Empty;
            string defaultValue = string.Empty;

            foreach (DataRow dr in EngineParameterData.Rows)
            {
                parameterName = dr["Name"].ToString().Trim();
                parameterValue = dr["Value"].ToString().Trim();
                defaultValue = dr["Default"].ToString().Trim();
                
                if (parameterValue != defaultValue)
                {
                    engine.SendOption(parameterName, parameterValue);
                }
            }
        }

        public void AddParameter(string optionItem)
        {
            DataRow dr = CreateRow(optionItem);
            EngineParameterData.Rows.Add(dr);
        }

        private DataRow CreateRow(string optionItem)
        {
            DataRow dr = EngineParameterData.NewRow();
            int itemsIndex = 0;

            string name;
            string type;
            string defaultValue;
            string varItems;
            string currentValue;

            //// name
            itemsIndex = optionItem.IndexOf(ParameterNames.Name);
            name = optionItem.Substring(itemsIndex + ParameterNames.Name.Length + 1);
            name = name.Substring(0, name.IndexOf(ParameterNames.Type));
            dr["Name"] = name;

            //// type
            itemsIndex = optionItem.IndexOf(ParameterNames.Type);
            type = optionItem.Substring(itemsIndex + ParameterNames.Type.Length + 1);
            if (type.Contains(ParameterNames.Space))
                type = type.Substring(0, type.IndexOf(ParameterNames.Space));
            dr["Type"] = type;

            switch (type)
            {
                case "spin":
                    //// min
                    itemsIndex = optionItem.IndexOf(ParameterNames.Min);
                    string minimum = optionItem.Substring(itemsIndex + ParameterNames.Min.Length + 1);
                    if (minimum.Contains(ParameterNames.Space))
                        minimum = minimum.Substring(0, minimum.IndexOf(ParameterNames.Space));

                    //// max
                    itemsIndex = optionItem.IndexOf(ParameterNames.Max);
                    string maximum = optionItem.Substring(itemsIndex + ParameterNames.Max.Length + 1);
                    if (maximum.Contains(ParameterNames.Space))
                        maximum = maximum.Substring(0, maximum.IndexOf(ParameterNames.Space));

                    //// default value
                    itemsIndex = optionItem.IndexOf(ParameterNames.Default);
                    defaultValue = optionItem.Substring(itemsIndex + ParameterNames.Default.Length + 1);
                    if (defaultValue.Contains(ParameterNames.Min))
                        defaultValue = defaultValue.Substring(0, defaultValue.IndexOf(ParameterNames.Min));
                    currentValue = defaultValue;
                    dr["Default"] = defaultValue;
                    dr["Value"] = currentValue;
                    dr["ValidValue"] = minimum + "," + maximum;
                    break;
                case "combo":
                    //// default value
                    itemsIndex = optionItem.IndexOf(ParameterNames.Default);
                    defaultValue = optionItem.Substring(itemsIndex + ParameterNames.Default.Length + 1);
                    if (defaultValue.Contains(ParameterNames.Var))
                        defaultValue = defaultValue.Substring(0, defaultValue.IndexOf(ParameterNames.Var));
                    currentValue = defaultValue;
                    dr["Default"] = defaultValue;
                    dr["Value"] = currentValue;

                    //// var items
                    itemsIndex = optionItem.IndexOf(ParameterNames.Var);
                    varItems = optionItem.Substring(itemsIndex + ParameterNames.Var.Length + 1);
                    varItems = varItems.Replace(" var ", ",");
                    dr["ValidValue"] = varItems;
                    break;
                default:
                    //// default value
                    itemsIndex = optionItem.IndexOf(ParameterNames.Default);
                    if (itemsIndex != -1)
                    {
                        defaultValue = optionItem.Substring(itemsIndex + ParameterNames.Default.Length + 1);
                        currentValue = defaultValue;
                        dr["Default"] = defaultValue;
                        dr["Value"] = currentValue;
                    }
                    break;
            }
            return dr;
        }

        public bool IsValidValue(string parameterName, object value)
        {
            DataRow row = GetRow(parameterName);
            if (row == null)
                return false;

            bool isValid = true;
            string type = row["Type"].ToString();
            string message = string.Empty;

            switch (type)
            {
                case "spin":
                    int iParameterValue;
                    if (Int32.TryParse(value.ToString(), out iParameterValue))
                    {
                        string min_Max = row["ValidValue"].ToString();
                        int min = Convert.ToInt32(min_Max.Substring(0, min_Max.IndexOf(",")));
                        int max = Convert.ToInt32(min_Max.Substring(min_Max.IndexOf(",")+1));
                        if (iParameterValue < min || iParameterValue > max)
                        {
                            message = "Value should be in range : " + min + " - " + max;
                            isValid = false;
                        }
                    }
                    else
                    {
                        message = "please enter an integer value";
                        isValid = false;
                    }
                    break;
                case "check":
                    bool bParameterValue;
                    if (!Boolean.TryParse(value.ToString(), out bParameterValue))
                    {
                        message = "please enter 'true' or 'false'";
                        isValid = false;
                    }
                    break;
                case "combo":
                    bool isFounded = false;
                    string[] items = row["ValidValue"].ToString().Split(",".ToCharArray());
                    foreach (string item in items)
                    {
                        if (item.ToLower() == value.ToString().ToLower())
                        {
                            isFounded = true;
                            break;
                        }
                    }
                    if (!isFounded)
                    {
                        message = "Value must be from these items : " + Environment.NewLine + Environment.NewLine;
                        foreach (string item in items)
                        {
                            message += item + Environment.NewLine;
                        }
                    }
                    isValid = isFounded;
                    break;
                default:
                    break;
            }
            if (!isValid)
            {
                OnParameterError(message);                
            }
            return isValid;            
        }

        #endregion

        #region Value 

        #region Get 
        
        public bool GetValueBool(string parameterName)
        {
            return BaseItem.ToBool(GetValue(parameterName));
        }

        public int GetValueInt32(string parameterName)
        {
            return BaseItem.ToInt32(GetValue(parameterName));
        }

        public string GetValue(string parameterName)
        {
            DataRow row = GetRow(parameterName);

            return BaseItem.GetCol(row, "Value");
        }
        
        #endregion

        #region Set 

        public void SetValue(string parameterName, object value)
        {
            DataRow row = GetRow(parameterName);

            if (row != null)
            {
                row["Value"] = value;
            }
        }

        private void LoadEngine()
        {
            uciEngine = new UCIEngine(EngineFilePath, Options.DefaultHashTableSize, this.Game);
            uciEngine.OptionReceived += new UCIEngine.OptionReceivedHandler(uciEngine_OptionReceived);
            uciEngine.UciOkReceived += new EventHandler(uciEngine_UciOkReceived);
            uciEngine.Load();
        }

        #endregion
        
        #endregion
    }

    public struct ParameterNames
    {
        public const string Name = "name";
        public const string Type = "type";
        public const string Default = "default";
        public const string Min = "min";
        public const string Max = "max";
        public const string Var = "var";
        public const string Space = " ";
    }
}
