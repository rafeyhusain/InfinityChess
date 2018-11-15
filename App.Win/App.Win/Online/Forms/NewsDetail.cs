using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;
namespace App.Win
{
    public partial class NewsDetail : Form
    {

        public NewsDetail()
        {
            InitializeComponent();
        }
       
        private void NewsDetail_Load(object sender, EventArgs e)
        {
            
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (newsDetailUc1.NewsName == string.Empty)
            {
                MessageForm.Show(this, MsgE.ErrorEmptyNewsTitle);
            }
            else
            {
                if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "save", "news") == DialogResult.Yes)
                {
                    newsDetailUc1.SaveNews();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.NewsDetail);
        }
        public static DialogResult Show(Form owner, int NewsID)
        {
            return Show(owner, NewsID, null);
        }

        public static DialogResult Show(Form owner, int NewsID, News News)
        {
            NewsDetail frm = new NewsDetail();
            frm.newsDetailUc1.NewsID = NewsID;
            frm.newsDetailUc1.News = News;
            DialogResult result = frm.ShowDialog(owner);

            return result;
        }

        private void pnlBottom_Paint(object sender, PaintEventArgs e)
        {

        }

       
       
       
    }
}
