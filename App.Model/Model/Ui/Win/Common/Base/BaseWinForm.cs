using System;
using System.Diagnostics;

using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using App.Model;
using App.Model.Db;
using System.Windows.Forms;
namespace App.Win
{
    public class BaseWinForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.HelpProvider helpProvider1;

        #region Constructor
        public BaseWinForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // BaseWinForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "BaseWinForm";
            this.Load += new System.EventHandler(this.BaseWinForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public virtual string HelpTopicId
        {
            get { return "0"; }
        }

        private void BaseWinForm_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = Ap.FileHelpChm;
            helpProvider1.SetHelpKeyword(this, HelpTopicId);
            helpProvider1.SetHelpNavigator(this, HelpNavigator.TopicId);
            helpProvider1.SetShowHelp(this, true);
        }
    }
}