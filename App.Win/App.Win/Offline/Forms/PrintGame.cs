using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfinityChess.Data.Report;
using InfinityChess.Print;
using App.Win;

namespace InfinityChess
{
    public partial class PrintReport : Form
    {
        private bool _isDiagram;
        public bool IsDiagram
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return _isDiagram; }
            [System.Diagnostics.DebuggerStepThrough]
            set { _isDiagram = value; }
        }

        public PrintReport()
        {
            InitializeComponent();
        }

        private void PrintGame_Load(object sender, EventArgs e)
        {
            if (_isDiagram == true)
            {
                PrintManager objPrintManager = new PrintManager();
                objPrintManager.PrintDiagram();
                PrintDiagram objPrintDiagram = new PrintDiagram();
                objPrintManager.dsPrintGame.Tables.RemoveAt(0);
                objPrintDiagram.SetDataSource(objPrintManager.dsPrintGame);
                crystalReportViewer1.ReportSource = objPrintDiagram;
            }
            else
            {
                PrintManager objPrintManager = new PrintManager();
                objPrintManager.PrintGame();
                PrintGameReport printGameReport = new PrintGameReport();
                printGameReport.SetDataSource(objPrintManager.dsPrintGame);
                crystalReportViewer1.ReportSource = printGameReport;
            }
        }

        private void PrintReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApWin.MainForm.Visible = true;
        }

        private void crystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            this.Text = "Infinity Chess - Print Game";
        }
    }
}
