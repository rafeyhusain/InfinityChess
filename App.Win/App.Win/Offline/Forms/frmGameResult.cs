using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InfinityChess;
namespace App.Win
{
    public partial class frmGameResult : BaseWinForm
    {
        #region DataMembers

        public Game Game = null;

        #endregion
        
        #region Ctor 
                
        public frmGameResult(Game game)
        {
            this.Game = game;
            InitializeComponent();
        }

        #endregion

        #region Load 

        private void frmGameResult_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            rdb12_12.Checked = true;
        }

        #endregion

        #region Helpers 
                
        private void LoadComboBoxes()
        {
            try
            {
                Kv kv = new Kv(KvType.ResultSymbols);
                DataTable dt = kv.DataTable.Copy();
                if (dt.Rows.Count > 0 && string.IsNullOrEmpty(dt.Rows[0]["k"].ToString()))
                {
                    dt.Rows[0]["k"] = "No Result";
                }

                cmbResult.DisplayMember = "k";
                cmbResult.ValueMember = "k";
                cmbResult.DataSource = dt;
            }
            catch(Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                throw ex;
            }
        }

        private void SaveGameResult()
        {
            if (rdb1_0.Checked)
            {
                this.Game.GameData.Result = "1-0";
                this.Game.Finish(GameResultE.WhiteWin);
            }
            else if (rdb0_1.Checked)
            {
                this.Game.GameData.Result = "0-1";
                this.Game.Finish(GameResultE.WhiteLose);
            }
            else if (rdb12_12.Checked)
            {
                this.Game.GameData.Result = "1/2-1/2";
                this.Game.Finish(GameResultE.Draw);
            }
            else
            {
                this.Game.GameData.Result = cmbResult.SelectedValue.ToString();
                this.Game.Finish(GameResultE.NoResult);
            }

            this.Game.GameData.Save();
        }

        #endregion

        #region Events 
                
        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveGameResult();
            //System.Windows.Forms.Clipboard.Clear(); 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();            
        }

        private void rdb1_0_Click(object sender, EventArgs e)
        {
            if (rdb1_0.Checked)
            {
                cmbResult.Enabled = false;
            }
        }

        private void rdb12_12_Click(object sender, EventArgs e)
        {
            if (rdb12_12.Checked)
            {
                cmbResult.Enabled = false;
            }
        }

        private void rdb0_1_Click(object sender, EventArgs e)
        {
            if (rdb0_1.Checked)
            {
                cmbResult.Enabled = false;
            }
        }

        private void rdbElse_Click(object sender, EventArgs e)
        {
            if (rdbElse.Checked)
            {
                cmbResult.Enabled = true;
            }
        }
        
        #endregion

        #region Popup

        public static bool AdjudicateGame(Game game)
        {
            bool isAdjudicate = true;
            if (game.Flags.IsAdjudicateRequired)
            {
                frmGameResult obj = new frmGameResult(game);
                if (obj.ShowDialog() != DialogResult.OK)
                {
                    isAdjudicate = false;
                }
            }
            return isAdjudicate;
        }

        #endregion

    }
}