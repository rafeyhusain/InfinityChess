// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mail;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
#pragma warning disable
namespace App.Model
{
    public class RsMail : Control, INamingContainer
    {
        #region "Data Members"
        private Mailer mail = new Mailer();
        #endregion

        #region "Properties"

        public string From
        {
            [DebuggerStepThrough]
            get { return mail.From; }
            [DebuggerStepThrough]
            set { mail.From = value; }
        }

        public string To
        {
            [DebuggerStepThrough]
            get { return mail.To; }
            [DebuggerStepThrough]
            set { mail.To = value; }
        }

        public string Cc
        {
            [DebuggerStepThrough]
            get { return mail.Cc; }
            [DebuggerStepThrough]
            set { mail.Cc = value; }
        }

        public string Bcc
        {
            [DebuggerStepThrough]
            get { return mail.Bcc; }
            [DebuggerStepThrough]
            set { mail.Bcc = value; }
        }

        public string Subject
        {
            [DebuggerStepThrough]
            get { return mail.Subject; }
            [DebuggerStepThrough]
            set { mail.Subject = value; }
        }

        public string Body
        {
            [DebuggerStepThrough]
            get { return mail.Body; }
            [DebuggerStepThrough]
            set { mail.Body = value; }
        }

        public MailFormat BodyFormat
        {
            [DebuggerStepThrough]
            get { return mail.BodyFormat; }
            [DebuggerStepThrough]
            set { mail.BodyFormat = value; }
        }

        public string SmtpServer
        {
            [DebuggerStepThrough]
            get { return mail.SmtpServer; }
            [DebuggerStepThrough]
            set { mail.SmtpServer = value; }
        }

        public string SmtpUserId
        {
            [DebuggerStepThrough]
            get { return mail.SmtpUserId; }
            [DebuggerStepThrough]
            set { mail.SmtpUserId = value; }
        }

        public string SmtpPassword
        {
            [DebuggerStepThrough]
            get { return mail.SmtpPassword; }
            [DebuggerStepThrough]
            set { mail.SmtpPassword = value; }
        }

        public int SmtpPort
        {
            [DebuggerStepThrough]
            get { return mail.SmtpPort; }
            [DebuggerStepThrough]
            set { mail.SmtpPort = value; }
        }

        public bool SmtpUseSsl
        {
            [DebuggerStepThrough]
            get { return mail.SmtpUseSsl; }
            [DebuggerStepThrough]
            set { mail.SmtpUseSsl = value; }
        }

        
        public bool SmtpAuthenticate
        {
            [DebuggerStepThrough]
            get { return mail.SmtpAuthenticate; }
            [DebuggerStepThrough]
            set { mail.SmtpAuthenticate = value; }
        }

        public MailTemplates Templates
        {
            [DebuggerStepThrough]
            get { return mail.Templates; }
        }

        public MailMessage MailMessage
        {
            [DebuggerStepThrough]
            get { return mail.MailMessage; }
        }

        public MailVerifier MailVerifier
        {
            [DebuggerStepThrough]
            get { return mail.MailVerifier; }
        }

        #endregion

        #region "Events"
        protected override void CreateChildControls()
        {
        }

        protected override void Render(HtmlTextWriter w)
        {
            EnableViewState = false;
            // don't want smtp credentials in viewstate
            EnsureChildControls();
        }

        protected override void OnPreRender(EventArgs e)
        {

        }

        #endregion

        #region "Helpers"

        #endregion

        #region "Public Methods"
        public string GetVerifyResultString(MailVerifyResult result)
        {
            return mail.GetVerifyResultString(result);
        }

        public MailVerifyResult Send()
        {
            return mail.Send("");
        }

        public MailVerifyResult Send(string templateName)
        {
            return mail.Send(templateName);
        }
        #endregion
    }
}
#pragma warning enable