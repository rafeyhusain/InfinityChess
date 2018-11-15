using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using System.IO;
using InfinitySettings.Streams;
using App.Win;

namespace InfinityChess.WinForms
{
    public partial class DevForm : Form
    {
      
        public DevForm()
        {
            InitializeComponent();
        }

        private void DevForm_Load(object sender, EventArgs e)
        {
            TestAppEngine();
        }

        #region AppEngine
        
        private void TestAppEngine()
        {
            
        }

        #endregion        
    }
}
