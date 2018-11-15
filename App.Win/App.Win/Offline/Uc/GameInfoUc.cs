using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfinityChess.Offline.Forms;

namespace InfinityChess
{
    public partial class GameInfoUc : UserControl , IGameUc
    {
        #region DataMembers 

        public Game Game = null;
        public const string Guid = "2d70de28-e3c8-4f1e-bf27-41fa53c4fc78";

        #endregion

        #region Ctor 
                
        public GameInfoUc()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public string EcoDiscription
        {
            get { return lblECO.Text; }
            set { lblECO.Text = value; }
        }

        #endregion


        #region Laod 
                
        private void GameInfoUc_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Helpers

        public void RefreshGameInfo()
        {
            // For Notation Window
            if (this.Game.GameMode == GameMode.OnlineEngineVsEngine || this.Game.GameMode == GameMode.OnlineHumanVsHuman || this.Game.GameMode == GameMode.Kibitzer)
            {
                lblPlayer.Text = this.Game.Player1.PlayerTitle + " - " + this.Game.Player2.PlayerTitle;
                lblDateTime.Text = this.Game.GameData.DateString;
                lblTournament.Text = this.Game.GameData.Tournament;
                lblGameTitle2.Text = "";
                lblECO.Text = "";
            }
            else
            {
                // For Scoring Window
                lblPlayer.Text = this.Game.GameData.WhiteTitle + " - " + this.Game.GameData.BlackTitle;
                lblTournament.Text = this.Game.GameData.Tournament;
                toolTip1.SetToolTip(lblTournament, lblTournament.Text);
                lblDateTime.Text = this.Game.GameData.DateString;
                lblGameTitle2.Text = this.Game.GameBookUserTitle;
                lblECO.Text = this.Game.GameData.EcoTitle;
            }
        }

        public void RefreshEco(string eco)
        {
            if (lblECO.InvokeRequired)
            {
                lblECO.Invoke(new MethodInvoker(delegate { RefreshEco(eco); }));
            }
            else
            {
                this.Game.GameData.EcoCode = eco.Substring(0, 3);
                this.Game.GameData.EcoDescription = eco.Substring(4);
                lblECO.Text = this.Game.GameData.EcoTitle;
            }
        }
                
        #endregion

        #region Events 

        private void lblBlack_Click(object sender, EventArgs e)
        {

        }

        private void lblWhite_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region IGameUc Members

        public void Init()
        {
            
        }

        public void UnInit()
        {
            
        }

        public void NewGame()
        {
            RefreshGameInfo();
        }

        #endregion
    }
}
