using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;

namespace App.Win
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        public string ProgressText
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return label1.Text; }
            [System.Diagnostics.DebuggerStepThrough]
            set { label1.Text = value; }
        }

        public int ProgressInterval
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return timer1.Interval; }
            [System.Diagnostics.DebuggerStepThrough]
            set { timer1.Interval = value; }
        }

        public Timer Timer
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return timer1; }
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); 
            this.Close();
        }

        public static ProgressForm Show(IWin32Window owner, string text)
        {
            return Show(owner, text, 1);
        }

        public static ProgressForm Show(IWin32Window owner, string text, int interval)
        {
            ProgressForm frm = new ProgressForm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ProgressInterval = interval;

            frm.ProgressText = text;

            frm.Show(owner);            
            
            if (interval != 1)
            {
                frm.Timer.Start();
            }

            frm.Update();

            return frm;
        }
    }
}
