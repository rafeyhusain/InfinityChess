using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using System.IO;
using InfinitySettings.Streams;
using App.Model;
using System.Diagnostics;
namespace InfinitySettings.BookOptionsManager
{
    public class BookData
    {
        XmlDocument xmldoc;

        private BookOptions _bookOptionsObject;
        public BookOptions BookOptionsObject
        {
            [DebuggerStepThrough]
            get { return _bookOptionsObject; }
            [DebuggerStepThrough]
            set { _bookOptionsObject = value; }
        }

        public BookData()
        {
            
        }

        public void Load()
        {
            LoadXmlDocument();

            _bookOptionsObject = new BookOptions();
            _bookOptionsObject.Load(xmldoc);
        }

        public void LoadOptimize()
        {
            LoadXmlDocument();

            _bookOptionsObject = new BookOptions();
            _bookOptionsObject.LoadOptimize(xmldoc);
        }

        public void LoadNormal()
        {
            LoadXmlDocument();

            _bookOptionsObject = new BookOptions();
            _bookOptionsObject.LoadNormal(xmldoc);
        }

        public void LoadHandicap()
        {
            LoadXmlDocument();

            _bookOptionsObject = new BookOptions();
            _bookOptionsObject.LoadHandicap(xmldoc);
        }

        public void LoadXmlDocument()
        {   
            try
            {   
                MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(Ap.FileBookOptions);
                xmldoc = new XmlDocument();
                xmldoc.Load(memoryStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseXmlDocument()
        {
            xmldoc = null;
        }

        public void Save()
        {   
            _bookOptionsObject.Save(ref xmldoc);

            string xmlContent = xmldoc.InnerXml;

            InfinityStreamsManager.WriteFile(Ap.FileBookOptions, xmlContent);

            CloseXmlDocument();
        }
    }
}
