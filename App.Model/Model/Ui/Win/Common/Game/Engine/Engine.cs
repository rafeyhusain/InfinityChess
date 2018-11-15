using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using System.Diagnostics;
namespace InfinitySettings.EngineManager
{
    public class Engine
    {
        #region Properties

        string _nodePath;

        private string _engineTitle;
        public string EngineTitle
        {
            [DebuggerStepThrough]
            get { return _engineTitle; }
            [DebuggerStepThrough]
            set { _engineTitle = value; }
        }

        private string _name;
        public string Name
        {
            [DebuggerStepThrough]
            get { return _name; }
            [DebuggerStepThrough]
            set { _name = value; }
        }
       
        public string TitleOnly
        {
            [DebuggerStepThrough]
            get { return _engineTitle.Replace(".exe", ""); }
            
        }
        private string _author;
        public string Author
        {
            [DebuggerStepThrough]
            get { return _author; }
            [DebuggerStepThrough]
            set { _author = value; }
        }

        private bool _isBelowNormal;
        public bool IsBelowNormal
        {
            [DebuggerStepThrough]
            get { return _isBelowNormal; }
            [DebuggerStepThrough]
            set { _isBelowNormal = value; }
        }

        private bool _isActive;
        public bool IsActive
        {
            [DebuggerStepThrough]
            get { return _isActive; }
            [DebuggerStepThrough]
            set { _isActive = value; }
        }

        private string _filePath;
        public string FilePath
        {
            [DebuggerStepThrough]
            get { return _filePath; }
            [DebuggerStepThrough]
            set { _filePath = value; }
        }

        #endregion

        #region Methods

        public bool CheckEngineExistance(XmlDocument xmldoc)
        {
            bool isExist = false;
            try
            {
                _nodePath = "/Engines";
                XmlElement root = xmldoc.DocumentElement;

                XmlNode itemNode = root.SelectNodes(_nodePath).Item(0);
                foreach (XmlNode item in itemNode.ChildNodes)
                {
                    if (item.ChildNodes[0].InnerText == _engineTitle)
                    {
                        isExist = true;
                        break;
                    }
                }
                return isExist;
            }
            catch
            {
                return isExist;
            }
        }

        public void AddEngineNode(ref XmlDocument xmldoc)
        {
            if (string.IsNullOrEmpty(_name))
                _name = _engineTitle.Replace(".exe","");
            if (string.IsNullOrEmpty(_author))
                _author = _engineTitle.Replace(".exe", "");

            XmlNode node = xmldoc.CreateNode(XmlNodeType.Element, "Engine", null);

            XmlNode nodeEngineTitle = xmldoc.CreateElement("EngineTitle");
            nodeEngineTitle.InnerText = _engineTitle;

            XmlNode nodeName = xmldoc.CreateElement("Name");
            nodeName.InnerText = _name;

            XmlNode nodeAuthor = xmldoc.CreateElement("Author");
            nodeAuthor.InnerText = _author;

            XmlNode nodeIsBelowNormal = xmldoc.CreateElement("IsBelowNormal");
            nodeIsBelowNormal.InnerText = _isBelowNormal.ToString();

            XmlNode nodeIsActive = xmldoc.CreateElement("IsActive");
            nodeIsActive.InnerText = _isActive.ToString();

            XmlNode nodeFilePath = xmldoc.CreateElement("FilePath");
            nodeFilePath.InnerText = _filePath;

            node.AppendChild(nodeEngineTitle);
            node.AppendChild(nodeName);
            node.AppendChild(nodeAuthor);
            node.AppendChild(nodeIsBelowNormal);
            node.AppendChild(nodeIsActive);
            node.AppendChild(nodeFilePath);

            xmldoc.DocumentElement.AppendChild(node);
        }

        #endregion
    }
}
