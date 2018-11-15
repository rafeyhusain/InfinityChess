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
using InfinityChess.InfinityChesshelp;

namespace App.Win
{
    public partial class Formula : BaseWinForm
    {
        public Formula()
        {
            InitializeComponent();
        }

        private void Formula_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Key",Type.GetType("System.String"));
            dt.Columns.Add("Value",Type.GetType("System.String"));

            dt.Rows.Add(new object[] { "Pawn", "1" });
            dt.Rows.Add(new object[] { "Knight", "2" });
            dt.Rows.Add(new object[] { "Bishop", "3" });
            dt.Rows.Add(new object[] { "Rook", "4" });
            dt.Rows.Add(new object[] { "Queen", "5" });
            dt.Rows.Add(new object[] { "King", "6" });
            dt.Rows.Add(new object[] { "Guest", "7" });

            comboBoxMinRank.DisplayMember = "Key";
            comboBoxMinRank.ValueMember = "Value";
            comboBoxMinRank.DataSource = dt;
            comboBoxMinRank.SelectedIndex = 6;

            Init();
        }

        private void Init()
        {
            if (UserFormulas.Instance == null)
            {
                return ;
            }

            UserFormula formula = UserFormulas.Instance.GetUserFormula();
            if (formula == null)
            {
                return;
            }

            chkUnrated.Checked = formula.IsUnrated;
            chkRated.Checked = formula.IsRated;
            chkDucats.Checked = formula.IsDucate;

            chkNoComputer.Checked = formula.IsNoComputer;
            chkNoCentaur.Checked = formula.IsNoCentaur;
            chkFastInternet.Checked = formula.IsFastInternetOnly;

            numericMinElo.Value = formula.MinElo;
            numericMaxElo.Value = formula.MaxElo;

            numericMinTime.Value = formula.MinTime;
            numericMaxTime.Value = formula.MaxTime;

            numericMinGain.Value = formula.MinGainPerMove;
            numericMaxGain.Value = formula.MaxGainPerMove;

            comboBoxMinRank.SelectedValue = formula.RankID;
            numericMinDucats.Value = formula.DucatesToOverride;
            chkActivate.Checked = formula.IsActive;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UserFormulas.Instance = null;
            UserFormulaDataKv formula = new UserFormulaDataKv();
            
            formula.UserID = Ap.CurrentUserID;
            
            formula.IsUnrated = chkUnrated.Checked;
            formula.IsRated = chkRated.Checked;
            formula.IsDucate = chkDucats.Checked;

            formula.IsNoComputer = chkNoComputer.Checked;
            formula.IsNoCentaur = chkNoCentaur.Checked;
            formula.IsFastInternetOnly = chkFastInternet.Checked;

            formula.MinElo = UData.ToInt32(numericMinElo.Value);
            formula.MaxElo = UData.ToInt32(numericMaxElo.Value);

            formula.MinTime = UData.ToInt32(numericMinTime.Value);
            formula.MaxTime = UData.ToInt32(numericMaxTime.Value);

            formula.MinGainPerMove = UData.ToInt32(numericMinGain.Value);
            formula.MaxGainPerMove = UData.ToInt32(numericMaxGain.Value);

            formula.RankID = UData.ToInt32(comboBoxMinRank.SelectedValue);
            formula.DucatesToOverride = UData.ToInt32(numericMinDucats.Value);
            formula.IsActive = chkActivate.Checked;

            try
            {
                DataSet ds = SocketClient.UpdateFormula(formula);
                if (ds != null && ds.Tables.Count > 0)
                {
                    ChallengesUc.Instance.LoadChallenges(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            chkUnrated.Checked = true;
            chkRated.Checked = true;
            //chkDucats.Checked = true;
            
            chkNoComputer.Checked = false;
            chkNoCentaur.Checked = false;
            chkFastInternet.Checked = false;

            numericMinElo.Value = 0;
            numericMaxElo.Value = 3000;

            numericMinTime.Value = 1;
            numericMaxTime.Value = 120;

            numericMinGain.Value = 0;
            numericMaxGain.Value = 100;

            comboBoxMinRank.SelectedIndex = 6;

            numericMinDucats.Value = 1;

            chkActivate.Checked = false;
        }
        public override string HelpTopicId
        {
            get { return "230"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.Formula);
        }

    }
}
