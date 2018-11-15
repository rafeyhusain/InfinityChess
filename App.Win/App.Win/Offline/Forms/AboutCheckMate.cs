using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using InfinityChess.WinForms;

namespace App.Win
{
    public partial class AboutInfinityChess : BaseWinForm
    {
        public AboutInfinityChess()
        {
            InitializeComponent();
        }

        private void AboutInfinityChess_Load(object sender, EventArgs e)
        {
            this.Text += " (" + Config.Version + ")";
            
            LoadCredits();
        }

        private void LoadCredits()
        {
            string creditsSummary = GetCredits();
            if (!string.IsNullOrEmpty(creditsSummary))
            {
                string[] separators = { "\r\n", "\n\r" };
                string[] creditsLines = creditsSummary.Split(separators, StringSplitOptions.None);
                foreach (string credit in creditsLines)
                {
                    lstCredits.Items.Add(credit);
                }
            }
        }

        private string GetCredits()
        {
            string credits = string.Empty;            
            credits = @"
Infinity Chess.

Technical Lead & Project Manager :
   Syed Rafey Husain

Programmers :
    Muhammad Idrees
    Ubaid ur Rehman Lodhi
    Imran Hashmat
    Mohammad Arsalan
    Imran Alam
    Khurram Enam
    Danish Abbas
    Abdul Moiz
  
Design :
   Syed Asad Ali Abidi";

            return credits;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            if (Config.IsDev)
            {
                DevForm frm = new DevForm();
                frm.Show();
            }
        }
    }
}