using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using App.Model;
using InfinitySettings.Streams;

namespace InfinitySettings.OptionsManager
{
    public class OptionsSetupsReader
    {
        XmlDocument xmldoc;

        public OptionsSetupsReader()
        {
            
        }

        public void LoadXmlDocument()
        {
            MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(Ap.FileOptionsSetups);
            xmldoc = new XmlDocument();
            xmldoc.Load(memoryStream);
            memoryStream.Close();
        }

        public void CloseXmlDocument()
        {            
            xmldoc = null;
        }

        public DataTable GetDataItemsFromNode(string nodePath)
        {
            XmlElement root = xmldoc.DocumentElement;
            XmlNodeList xmlnode = root.SelectNodes(nodePath).Item(0).ChildNodes;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            for (int i = 0; i < xmlnode.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = xmlnode[i].InnerText;
                dr["Value"] = xmlnode[i].InnerText;

                dt.Rows.Add(dr);
            }
            return dt;
        }

        public DataTable GetKeyValuesFromNode(string nodePath)
        {
            XmlElement root = xmldoc.DocumentElement;
            XmlNodeList xmlnode = root.SelectNodes(nodePath).Item(0).ChildNodes;
            DataTable dt = new DataTable();
            dt.Columns.Add("Key", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            for (int i = 0; i < xmlnode.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Key"] = xmlnode[i].Attributes["Key"].InnerText;
                dr["Value"] = xmlnode[i].Attributes["Value"].InnerText;

                dt.Rows.Add(dr);
            }
            return dt;
        } 
    }
}
