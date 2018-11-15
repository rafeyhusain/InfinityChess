using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using System.Configuration;
using App.Model.Db;

namespace App.Win
{
    public partial class BrowserUc : UserControl
    {
        public bool IsNew = false;
        private string Title = string.Empty;
        public KeyValueE KeyValueID;

        public BrowserUc()
        {
            InitializeComponent();
        }
        
        public void Navigate(KeyValueE keyValueID)
        {            
            this.KeyValueID = keyValueID;
            this.Title = KeyValues.GetTitle(keyValueID);
            webBrowser1.Navigate(KeyValues.GetUrl(keyValueID));
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.ParentForm.Text = Title + " - Please wait, Loading...";
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.ParentForm.Text = Title;
        }
    }
}
