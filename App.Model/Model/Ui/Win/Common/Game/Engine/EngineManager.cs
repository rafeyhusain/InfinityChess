using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.IO;
using InfinitySettings.Streams;
using System.Collections;
using App.Model;

namespace InfinitySettings.EngineManager
{
    public class EngineManager
    {
        string apDefultEngine = "TogaII";
        XmlDocument xmldoc;
        List<Engine> lstEngine = new List<Engine>();
        private Engine _engineObject;
        public Engine EngineObject
        {
            [DebuggerStepThrough]
            get { return _engineObject; }
            [DebuggerStepThrough]
            set { _engineObject = value; }
        }

        public EngineManager()
        {
            _engineObject = new Engine();
        }

        // if null is passed in excludeEngineList, load all engines
        public List<Engine> LoadEngines(ArrayList excludeEngineList)
        {

            LoadXmlDocument();

            _engineObject = new Engine();

            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes("/Engines").Item(0);
            string _defaultEngine = itemNode.ChildNodes[0].InnerText;
            for (int i = 1; i < itemNode.ChildNodes.Count; i++)
            {
                Engine objEngine = new Engine();
                objEngine.EngineTitle = itemNode.ChildNodes[i].ChildNodes[0].InnerText;
                objEngine.Name = itemNode.ChildNodes[i].ChildNodes[1].InnerText;
                objEngine.Author = itemNode.ChildNodes[i].ChildNodes[2].InnerText;
                objEngine.IsBelowNormal = Convert.ToBoolean(itemNode.ChildNodes[i].ChildNodes[3].InnerText);
                objEngine.IsActive = Convert.ToBoolean(itemNode.ChildNodes[i].ChildNodes[4].InnerText);
                objEngine.FilePath = itemNode.ChildNodes[i].ChildNodes[5].InnerText;

                if (excludeEngineList != null)
                {
                    if (excludeEngineList.Contains(objEngine.EngineTitle))
                    {
                        continue;
                    }
                }

                lstEngine.Add(objEngine);
            }
            return lstEngine;
        }

        public List<Engine> LoadEngines()
        {
            return LoadEngines(null);
        }

        public Engine LoadDefaultEngine()
        {

            LoadXmlDocument();

            Engine objEngine = null;
            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes("/Engines").Item(0);
            string _defaultEngine = itemNode.ChildNodes[0].InnerText;
            for (int i = 1; i < itemNode.ChildNodes.Count; i++)
            {
                if (itemNode.ChildNodes[i].ChildNodes[5].InnerText == _defaultEngine)
                {
                    objEngine = new Engine();
                    objEngine.EngineTitle = itemNode.ChildNodes[i].ChildNodes[0].InnerText;
                    objEngine.Name = itemNode.ChildNodes[i].ChildNodes[1].InnerText;
                    objEngine.Author = itemNode.ChildNodes[i].ChildNodes[2].InnerText;
                    objEngine.IsBelowNormal = Convert.ToBoolean(itemNode.ChildNodes[i].ChildNodes[3].InnerText);
                    objEngine.IsActive = Convert.ToBoolean(itemNode.ChildNodes[i].ChildNodes[4].InnerText);
                    objEngine.FilePath = itemNode.ChildNodes[i].ChildNodes[5].InnerText;
                    CheckAndSetDefaultEngine(objEngine);
                    break;
                }
            }
            return objEngine;
        }

        private void CheckAndSetDefaultEngine(Engine engine)
        {
            if (engine.EngineTitle.Replace(".exe","") == apDefultEngine)
            {
                string filePath = Ap.FolderEngines + apDefultEngine + ".exe";
                if (engine.FilePath != filePath)
                {
                    UpdateEnginePath(engine.EngineTitle, filePath);
                    SaveDefaultEngine(filePath);
                    engine.FilePath = filePath;
                }
            }
        }

        public Engine LoadEngineByName(string engineName)
        {
            engineName = engineName.Replace(".exe", "");

            LoadXmlDocument();

            Engine objEngine = null;
            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes("/Engines").Item(0);

            for (int i = 1; i < itemNode.ChildNodes.Count; i++)
            {
                if (itemNode.ChildNodes[i].ChildNodes[1].InnerText.Trim() == engineName.Trim())
                {
                    objEngine = new Engine();
                    objEngine.EngineTitle = itemNode.ChildNodes[i].ChildNodes[0].InnerText;
                    objEngine.Name = itemNode.ChildNodes[i].ChildNodes[1].InnerText;
                    objEngine.Author = itemNode.ChildNodes[i].ChildNodes[2].InnerText;
                    objEngine.IsBelowNormal = Convert.ToBoolean(itemNode.ChildNodes[i].ChildNodes[3].InnerText);
                    objEngine.IsActive = Convert.ToBoolean(itemNode.ChildNodes[i].ChildNodes[4].InnerText);
                    objEngine.FilePath = itemNode.ChildNodes[i].ChildNodes[5].InnerText;
                    break;
                }
            }
            return objEngine;
        }

        public void SaveDefaultEngine(string engineFilePath)
        {
            LoadXmlDocument();

            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes("/Engines").Item(0);

            itemNode.ChildNodes[0].InnerText = engineFilePath;

            UFile.RemoveReadOnly(Ap.FileEngineData);
            //xmldoc.Save(_filePath);
            string xmlContent = xmldoc.InnerXml;
            InfinityStreamsManager.WriteFile(Ap.FileEngineData, xmlContent);

            CloseXmlDocument();
        }

        public void UpdateEnginePath(string engineName,string filePath)
        {
            LoadXmlDocument();
            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes("/Engines").Item(0);
            for (int i = 1; i < itemNode.ChildNodes.Count; i++)
            {
                if (itemNode.ChildNodes[i].ChildNodes[0].InnerText == engineName)
                {
                    XmlNode itemChildNode = itemNode.ChildNodes[i];
                    itemChildNode.ChildNodes[5].InnerText = filePath;                    
                    break;
                }
            }
            UFile.RemoveReadOnly(Ap.FileEngineData);            
            string xmlContent = xmldoc.InnerXml;
            InfinityStreamsManager.WriteFile(Ap.FileEngineData, xmlContent);
        }

        public bool DeActivateEngine(string engineName)
        {
            bool hasDeActivate = false;

            LoadXmlDocument();
            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes("/Engines").Item(0);
            for (int i = 1; i < itemNode.ChildNodes.Count; i++)
            {
                if (itemNode.ChildNodes[i].ChildNodes[0].InnerText == engineName)
                {
                    XmlNode itemChildNode = itemNode.ChildNodes[i];
                    itemChildNode.ChildNodes[4].InnerText = "False";
                    hasDeActivate = true;
                    break;
                }
            }
            UFile.RemoveReadOnly(Ap.FileEngineData);
            //xmldoc.Save(_filePath);
            string xmlContent = xmldoc.InnerXml;
            InfinityStreamsManager.WriteFile(Ap.FileEngineData, xmlContent);


            return hasDeActivate;
        }

        public bool ActivateEngine(string engineName)
        {
            bool hasActivate = false;

            LoadXmlDocument();
            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes("/Engines").Item(0);
            for (int i = 1; i < itemNode.ChildNodes.Count; i++)
            {
                if (itemNode.ChildNodes[i].ChildNodes[0].InnerText == engineName)
                {
                    XmlNode itemChildNode = itemNode.ChildNodes[i];
                    itemChildNode.ChildNodes[4].InnerText = "True";
                    hasActivate = true;
                    break;
                }
            }
            UFile.RemoveReadOnly(Ap.FileEngineData);

            //xmldoc.Save(_filePath);
            string xmlContent = xmldoc.InnerXml;
            InfinityStreamsManager.WriteFile(Ap.FileEngineData, xmlContent);

            return hasActivate;
        }

        public void LoadXmlDocument()
        {
            //FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read,
            //                   FileShare.ReadWrite);
            //xmldoc = new XmlDocument();
            //xmldoc.Load(fs);

            MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(Ap.FileEngineData);
            xmldoc = new XmlDocument();
            xmldoc.Load(memoryStream);
            memoryStream.Close();
        }

        public bool AddEngineNode()
        {
            LoadXmlDocument();
            if (_engineObject.CheckEngineExistance(xmldoc) != true)
            {
                _engineObject.AddEngineNode(ref xmldoc);
                UFile.RemoveReadOnly(Ap.FileEngineData);

                string xmlContent = xmldoc.InnerXml;
                InfinityStreamsManager.WriteFile(Ap.FileEngineData, xmlContent);

                CloseXmlDocument();
                return true;
            }
            else
            {
                CloseXmlDocument();
                return false;
            }
        }

        public void CloseXmlDocument()
        {
            xmldoc = null;
        }

        public void Save()
        {
            string xmlContent = xmldoc.InnerXml;
            InfinityStreamsManager.WriteFile(Ap.FileEngineData, xmlContent);

            CloseXmlDocument();
        }
    }
}
