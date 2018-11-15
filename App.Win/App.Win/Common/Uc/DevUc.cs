using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using InfinitySettings.Streams;
using App.Model;
using App.Win;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Model
{
    public partial class DevUc : DockContent
    {
        #region Data Members

        public Game Game = null;
        public const string Guid = "6C3D817B-3E5A-4c34-8B83-C4476E0BF812";

        #endregion

        #region Ctor
        public DevUc()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void DevUc_Load(object sender, EventArgs e)
        {
            InitTabObjects();
            InitTabData();
        }

        #endregion

        #region Tabs

        #region Objects

        private void InitTabObjects()
        {
            lbData.Items.Add("CurrentMove");
            lbData.Items.Add("Moves");
            lbData.Items.Add("NotationData");
            lbData.Items.Add("NotationView");
            lbData.Items.Add("ScoringData");
            lbData.Items.Add("ScoringView");
            lbData.Items.Add("BookData");

            tabControl1.SelectedIndex = 1;
        }

        private void lbData_Click(object sender, EventArgs e)
        {
            RefreshObject();
        }

        private void RefreshObject()
        {
            try
            {
                switch (lbData.SelectedIndex)
                {
                    case 0:
                        Show(this.Game.CurrentMove.DataRow.Table);
                        break;
                    case 1:
                        Show(this.Game.Moves.DataTable);
                        break;
                    case 2:
                        Show(this.Game.Notations.NotationData);
                        break;
                    case 3:
                        Show(this.Game.Notations.NotationView);
                        break;
                    case 4:
                        Show(this.Game.Notations.Scoring.ScoringData);
                        break;
                    case 5:
                        Show(this.Game.Notations.Scoring.ScoringView);
                        break;
                    case 6:
                        Show(this.Game.Book.BookMoves.DataTable);
                        break;
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private void Show(DataTable table)
        {
            this.dgData.DataSource = table;
            toolStripStatusLabel1.Text = "Count = " + table.Rows.Count;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RefreshObject();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            SaveObject();
        }

        private void SaveObject()
        {
            string path = Ap.FolderDataKv + "Obj.xml";

            UData.WriteXmlDecrypted((DataTable) this.dgData.DataSource, path);

            MessageForm.Show("File saved successfully.\n\n" + path);
        }
        #endregion

        #region Data

        #region Init
        private void InitTabData()
        {
            LoadFolder(Ap.FolderData);
        }

        private void LoadFolder(string folder)
        {
            treeView1.Nodes.Clear();

            LoadFolder(null, folder);

            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes[0].Expand();
            }
        }

        private void LoadFolder(TreeNode n, string folder)
        {
            if (!Directory.Exists(folder))
            {
                return;
            }

            DirectoryInfo di = new DirectoryInfo(folder);

            if (n == null)
            {
                n = treeView1.Nodes.Add(di.FullName, di.Name);
            }
            else
            {
                n = n.Nodes.Add(di.FullName, di.Name);
            }

            n.Tag = di.FullName;

            foreach (DirectoryInfo subfolder in di.GetDirectories())
            {
                LoadFolder(n, subfolder.FullName);
            }

            foreach (FileInfo file in di.GetFiles())
            {
                n.Nodes.Add(file.FullName, file.Name);

                n.Tag = file.FullName;
            }
        }
        #endregion

        #region Helpers
        private string ReadAllText(string path)
        {
            if (UFile.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
            {
                toolStripStatusLabel1.Text = "File does not exists\n\n" + path;
            }

            return "";
        }

        private void Decrypt(string s)
        {
            try
            {
                rtbFileContent.Text = UCrypto.Decrypt(s);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private void Encrypt(string s)
        {
            try
            {
                rtbFileContent.Text = Encoding.ASCII.GetString(UZip.ZipString(s));
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }
        #endregion

        #region Toolbar

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            LoadFolder(treeView1.Nodes[0].Tag.ToString());
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;

            folderBrowserDialog1.ShowNewFolderButton = true;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadFolder(folderBrowserDialog1.SelectedPath);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Ap.FolderData;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbFileContent.Text = ReadAllText(openFileDialog1.FileName);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            rtbFileContent.Text = "";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Decrypt(rtbFileContent.Text);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Encrypt(rtbFileContent.Text);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                Ap.ResetFactorySettings();
                MessageForm.Show("Reset factory setttings successfully.");
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(rtbFileContent.SelectedText))
            {
                System.Windows.Forms.Clipboard.SetText(rtbFileContent.Text);
            }
            else
            {
                System.Windows.Forms.Clipboard.SetText(rtbFileContent.SelectedText);
            }
        }


        #endregion

        #region Treeview
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                rtbFileContent.Text = ReadAllText(e.Node.Name);

                toolStripStatusLabel1.Text = e.Node.Text;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }
        #endregion

        #endregion

        #region Engine

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RefreshLog();
        }

        private void RefreshLog()
        {
            webBrowser1.Navigate(Ap.FileLogTxt);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                TestDebugger.Instance.Clear();

                TestDebugger.Instance.Write("File Created At: " + System.DateTime.Now.ToLongTimeString());

                RefreshLog();
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex, "File may be in use, please try again.");
            }
        }

        #endregion


        #endregion

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #endregion
    }
}
