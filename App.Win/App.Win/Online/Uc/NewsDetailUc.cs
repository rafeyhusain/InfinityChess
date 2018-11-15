using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;
namespace App.Win
{
    public partial class NewsDetailUc : UserControl
    {
        public int NewsID = 0;
        private News news = null;
        public NewsDetailUc()
        {
            InitializeComponent();
        }
        public string NewsName
        {
            set { txtNewsName.Text = value; }
            get { return txtNewsName.Text; }
        }
        public News News
        {
            //[System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (news == null)
                {
                    try
                    {
                        ProgressForm frm = ProgressForm.Show(this, "Loading News...");

                        news = SocketClient.GetNewsByID(NewsID);

                        frm.Close();
                    }
                    catch (Exception ex)
                    {
                        TestDebugger.Instance.WriteError(ex);
                        MessageForm.Show(ex);
                    }
                    //if (table.Rows.Count > 0)
                    //{
                    //    news = new News(Ap.Cxt, table.Rows[0]);
                    //}
                }

                return news;
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                news = value;
            }
        }

        private void NewsDetailUc_Load(object sender, EventArgs e)
        {
            FillNewsCategoryCombo();

            LoadNews();
        }

        public void LoadNews()
        {
            if (News == null)
            {
                return;
            }

            txtNewsName.Text = this.News.Name;
            editor1.HtmlText = this.News.Description;

            if (this.News.NewsID == 0)
            {
                this.ParentForm.Text = "New News";
            }
        }

        public void FillNewsCategoryCombo()
        {
            try
            {
                DataSet ds = SocketClient.GetAllNewsCategory();
                if (ds != null)
                {
                    cmbNewsType.DataSource = ds.Tables[0];
                    cmbNewsType.DisplayMember = "Name";
                    cmbNewsType.ValueMember = "NewsCategoryID";
                    if (this.News.NewsCategoryID > 0)
                    {
                        cmbNewsType.SelectedValue = this.News.NewsCategoryID;
                    }
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }
        public void SaveNews()
        {
            try
            {
                int newsCategoryID = Convert.ToInt32(cmbNewsType.SelectedValue);
                SocketClient.SaveNews(txtNewsName.Text, editor1.HtmlText, newsCategoryID, NewsID);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        
    }
}
