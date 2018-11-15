using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model.Db;

namespace InfinityChess.Online.Forms
{
    public partial class BrowserForm : Form
    {
        public bool IsNew 
        {
            get { return browserUC.IsNew; }
            set { browserUC.IsNew = value; }
        }

        public KeyValueE KeyValueID
        {
            get { return browserUC.KeyValueID; }
            set { browserUC.KeyValueID = value; }
        }
       
        public BrowserForm()
        {
            InitializeComponent();
        }

        public BrowserForm(KeyValueE keyValueID, bool isNew)
        {
            InitializeComponent();

            this.IsNew = isNew;
            this.KeyValueID = keyValueID;
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            this.Text = KeyValues.GetTitle(this.KeyValueID);
            browserUC.IsNew = IsNew;
            browserUC.Navigate(this.KeyValueID);
        }

        internal static void Navigate(Form parent, KeyValueE keyValueE, bool isNew)
        {
            BrowserForm BrowserForm = new BrowserForm(keyValueE, isNew);
            BrowserForm.Show(parent);
        }
    }
}
