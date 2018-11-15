using System;
using App.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChessLibrary;
using InfinityChess.Offline.Forms;
using App.Win;
using WeifenLuo.WinFormsUI.Docking;
using InfinityChess.WinForms;

namespace InfinityChess
{
    public partial class NotationUc : DockContent, App.Model.IGameUc
    {
        #region Data Members

        public Game Game = null;
        public MainForm MainForm = null;

        public const string Guid = "58b61cee-182b-4a7b-b7b9-9829a36e6511";

        #endregion

        #region Property

        public ScoringUc ScoringUc
        {
            get
            {
                return this.MainForm.ScoringUc;
            }
        }

        public CapturePieceUc CapturePieceUc
        {
            get
            {
                return capturePieceUc1;
            }
        }

        public GameInfoUc GameInfoUc
        {
            get
            {
                return gameInfoUc1;
            }
        }

        public DataGridView Grid
        {
            get
            {
                return dgvNotation;
            }
        }

        public int SelectedRowIndex
        {
            get
            {
                if (dgvNotation.SelectedCells.Count == 0)
                {
                    return -1;
                }

                return dgvNotation.SelectedCells[0].RowIndex;
            }
        }

        public int SelectedColumnIndex
        {
            get
            {
                if (dgvNotation.SelectedCells.Count == 0)
                {
                    return -1;
                }

                return dgvNotation.SelectedCells[0].ColumnIndex;
            }
        }

        bool IsProcessSelectionBlocked
        {
            get
            {
                //if (dgvNotation.CurrentCell == null || this.Game.Flags.IsFirtMove || this.Game.Notations.IsFromAdd || this.Game.Flags.IsSelectNotationBlocked)
                if (dgvNotation.CurrentCell == null || this.Game.Flags.IsFirtMove || this.Game.Flags.IsSelectNotationBlocked)
                {
                    return true;
                }
                return false;
            }
        }

        #endregion

        #region Ctor
        public NotationUc(Game game,MainForm mainForm)
        {
            this.Game = game;
            this.MainForm = mainForm;
            InitializeComponent();
        }
        #endregion

        #region Events
        public event EventHandler OnRefresh;
       
            
        #region Load
        private void NotationUc_Load(object sender, EventArgs e)
        {
            //this.dgvNotation.DataSource = this.Game.Notations.NotationView;
            tsMoveLog.Checked = Ap.Options.ShowDisconnectionLog;
            tsMoveComments.Checked = Ap.Options.ShowComments;
            this.Focus();
        }

        #endregion

        #region Game

        void Game_AddNewVariation(object sender, FormClosingEventArgs e)
        {
            frmInsertNewVariation frm = new frmInsertNewVariation(this.Game);            
            frm.ParentMove = this.Game.CurrentMove;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Game.VariationType = frm.VariationType;
            }
            else
            {
                e.Cancel = true;
            }
        }

        void Notations_AfterPaste(object sender, EventArgs e)
        {
            //this.Game.Notations.IsFromAdd = true;
            ////dgvNotation.DataSource = this.Game.Notations.NotationView;
            //if (this.Game.Moves.Count > 0)
            //{
            //    notationText1.SetSelection(this.Game.Moves[0]);
            //}
            //this.Game.Notations.IsFromAdd = false;
        }

        void Notations_BeforePaste(object sender, EventArgs e)
        {
            notationText1.ClearNotationText(0, false);
            //dgvNotation.DataSource = null;
        }
        #endregion

        #region Grid
        private void dgvNotation_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //string value = string.Empty;

            //if (e.Value == null)
            //{
            //    return;
            //}

            //value = e.Value.ToString();

            //if (value.Contains(":"))
            //{
            //    string[] flags = UStr.Split(e.Value.ToString(), ":");

            //    value = value.Replace(":" + flags[1], "");

            //    MoveFlags mf = new MoveFlags(flags[1]);

            //    switch (mf.VariationType)
            //    {
            //        case VariationTypeE.Variation:
            //            e.CellStyle.Font = new Font(this.Font, FontStyle.Regular);
            //            break;
            //        case VariationTypeE.MainLine:
            //            break;
            //        case VariationTypeE.Insert:
            //            break;
            //        case VariationTypeE.Overwrite:
            //            e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
            //            break;
            //        default:
            //            e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
            //            break;
            //    }
            //}

            //e.Value = value;
        }

        private void dgvNotation_SelectionChanged(object sender, EventArgs e)
        {
            //if (IsProcessSelectionBlocked)
            //{
            //    return;
            //}

            //NotationDataRow nd = this.Game.Notations.GetNotationDataRow(dgvNotation.CurrentCell.RowIndex, dgvNotation.CurrentCell.ColumnIndex);

            //if (nd == null)
            //{
            //    return;
            //}

            //Move m = this.Game.Moves.GetById(nd.Id);

            //this.Game.MoveTo(m);

            //notationTextUc1.SetSelection(m);
        }

        private void dgvNotation_KeyDown(object sender, KeyEventArgs e)
        {
            //switch ((Keys)e.KeyValue)
            //{
            //    case Keys.Left:
            //        //this.Game.MoveTo(MoveToE.Previous);
            //        e.Handled = true;
            //        break;
            //    case Keys.Right:
            //        //this.Game.MoveTo(MoveToE.Next);
            //        e.Handled = true;
            //        break;
            //}
        }

        #endregion

        #endregion

        #region Helper

        public void SetSelection(Move m)
        {
            //this.Game.Notations.IsFromAdd = true;

            //NotationDataRow nd = this.Game.Notations.GetNotationDataRow(m.Id);
            //if (nd == null)
            //{
            //    return;
            //}

            //if (nd.R < dgvNotation.Rows.Count && nd.C < dgvNotation.ColumnCount)
            //{
            //    dgvNotation.CurrentCell = dgvNotation[nd.C, nd.R];
            //    dgvNotation.Refresh();
            //}
            
            //this.Game.Notations.IsFromAdd = false;
            notationText1.SetSelection(m);
            this.Focus();
        }

        private void AddToNotation(Move m, bool isOverwrite)
        {
            //string notation = string.Empty;
            //if (Ap.Options.IsSingleNotation)
            //{
            //    notation = m.SingleNotation;
            //}
            //else
            //{
            //    notation = m.DoubleNotation;
            //}

            switch (m.Flags.VariationType)
            {
                case VariationTypeE.Variation:
                    notationText1.AddVariation(m);
                    break;
                case VariationTypeE.MainLine:
                    notationText1.AddNewMainLine(m);
                    break;
                case VariationTypeE.Insert:
                    if (isOverwrite)
                    {
                        Overwrite(m);
                    }
                    else
                    {
                        notationText1.AddMove(m, notationText1.SelectedIndex);
                    }
                    break;
                case VariationTypeE.Overwrite:
                    if (isOverwrite)
                    {
                        Overwrite(m);
                    }
                    else
                    {
                        notationText1.AddMove(m, notationText1.SelectedIndex);
                    }
                    break;
                default:

                    if (notationText1.SelectedMove != null && m.Pid != notationText1.SelectedMove.Id)
                    {
                        Move move = this.Game.Moves.GetById(m.Pid);
                        SetSelection(m);
                    }
                    notationText1.AddMove(m, notationText1.SelectedIndex);
                    break;
            }
        }

        public void Overwrite(Move move)
        {
            notationText1.ClearNotationText(0, true);
            
            for (int i = 0; i < this.Game.Moves.MoveCount; i++)
            {
                Move m = this.Game.Moves[i];
                AddToNotation(m, false);
            }

            notationText1.AddMove(move, notationText1.SelectedIndex);
        }
        #endregion

        #region IGameUc Members

        public void NewGame()
        {
            if (this.Game.Flags.IsGameFinished)
            {
                notationText1.ToggleEnableDisable(true);
            }
            else
            {
                notationText1.ToggleEnableDisable(false);
            }

            switch (this.Game.GameMode)
            {
                case GameMode.None:
                case GameMode.EngineVsEngine:
                case GameMode.OnlineHumanVsHuman:
                case GameMode.OnlineHumanVsEngine:
                case GameMode.OnlineEngineVsEngine:
                    notationText1.ToggleEnableDisable(false);
                    break;
                case GameMode.HumanVsHuman:
                case GameMode.HumanVsEngine:
                case GameMode.Kibitzer:
                    notationText1.ToggleEnableDisable(true);
                    break;
                default:
                    break;
            }

            notationText1.ClearNotationText(0, false);

            //this.dgvNotation.ClearSelection();

            //foreach (DataGridViewColumn dc in dgvNotation.Columns)
            //{
            //    dc.Width = 500;
            //}
        }

        public void Init()
        {
            //this.dgvNotation.DataSource = this.Game.Notations.NotationView;
            //this.dgvNotation.ClearSelection(); 
            //this.dgvNotation.Focus();
            //this.dgvNotation.Select();

            this.Game.SelectCurrentMoveChildren += new Game.SelectCurrentMoveChildrenEventHandler(Game_SelectCurrentMoveChildren);
            this.Game.AddNewVariation += new Game.FormClosingEventHandler(Game_AddNewVariation);
            this.Game.Notations.EventOnAddToNotation += new Notations.OnAddToNotation(Notations_EventOnAddToNotation);

            this.Game.Notations.EventToClearNotation += new Notations.OnToClearNotation(Notations_EventToClearNotation);
            this.Game.Notations.EventCommnetsToNotation += new Notations.OnCommnetsToNotation(Notations_EventCommnetsToNotation);
            this.Game.Notations.EventOnResultToNotation += new Notations.OnResultToNotation(Notations_EventOnResultToNotation);

            this.Game.BeforePaste += new EventHandler(Notations_BeforePaste);
            this.Game.AfterPaste += new EventHandler(Notations_AfterPaste);

            this.Game.Notations.MoveToEventE += new Notations.MoveToEventHandler(Notations_MoveToEventE);
            this.Game.Notations.MoveToEvent += new EventHandler(Notations_MoveToEvent);

            if (this.Game != null)
            {
                notationText1.Game = this.Game;
                GameInfoUc.Game = this.Game;
                CapturePieceUc.Game = this.Game;
            }
        }

        void Notations_EventOnResultToNotation(object sender, string result)
        {
            notationText1.Result(result);
            if (this.Game.Flags.IsGameFinished)
            {
                notationText1.ToggleEnableDisable(true);
            }
        }

        void Notations_EventCommnetsToNotation(object sender, Move m, string comments, bool isbefore,bool isdeleteAllCommentary)
        {
            if (!string.IsNullOrEmpty(comments))
            {
                if (Ap.Options.ShowComments)
                {
                    if (m != null)
                    {
                        SetSelection(m);
                    }
                    notationText1.AddComments(isbefore, comments + "  ");
                }               
            }
            else
            {
                if (isdeleteAllCommentary)
                {
                    notationText1.RemoveComments();
                }
                else
                {
                    notationText1.RemoveMoveComments();
                }
            }
        }

        void Notations_EventToClearNotation(object sender)
        {
            notationText1.ClearNotationText(0, false);
        }

        void Notations_EventOnAddToNotation(object sender, Move m)
        {
            //SetSelection(m);
            AddToNotation(m, true);
        }

        public void UnInit()
        {
            this.Game.SelectCurrentMoveChildren -= new Game.SelectCurrentMoveChildrenEventHandler(Game_SelectCurrentMoveChildren);
            this.Game.AddNewVariation -= new Game.FormClosingEventHandler(Game_AddNewVariation);
            this.Game.Notations.EventOnAddToNotation -= new Notations.OnAddToNotation(Notations_EventOnAddToNotation);

            this.Game.Notations.EventToClearNotation -= new Notations.OnToClearNotation(Notations_EventToClearNotation);
            this.Game.Notations.EventCommnetsToNotation -= new Notations.OnCommnetsToNotation(Notations_EventCommnetsToNotation);
            this.Game.Notations.EventOnResultToNotation -= new Notations.OnResultToNotation(Notations_EventOnResultToNotation);

            this.Game.BeforePaste -= new EventHandler(Notations_BeforePaste);
            this.Game.AfterPaste -= new EventHandler(Notations_AfterPaste);

            this.Game.Notations.MoveToEventE -= new Notations.MoveToEventHandler(Notations_MoveToEventE);
            this.Game.Notations.MoveToEvent -= new EventHandler(Notations_MoveToEvent);
        }

        #endregion

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    return true;
                case Keys.Right:
                    return true;
                case Keys.Up:
                    return true;
                case Keys.Down:
                    return true;
                default:
                    break;
            }
            return false;
        }
        #endregion

        #region ContextMenuItemEventHandlers
        private void tsMoveComments_Click(object sender, EventArgs e)
        {
            Ap.Options.ShowComments = !tsMoveComments.Checked;
            tsMoveComments.Checked = !tsMoveComments.Checked;
            Ap.Options.Save();
            this.Refresh(tsMoveComments.Checked, tsMoveLog.Checked);
            if (OnRefresh != null)
            {
                OnRefresh(this, null);
            }
        }
        private void tsMoveLog_Click(object sender, EventArgs e)
        {
            Ap.Options.ShowDisconnectionLog = !tsMoveLog.Checked;
            tsMoveLog.Checked = !tsMoveLog.Checked;
            Ap.Options.Save();
            this.Refresh(tsMoveComments.Checked, tsMoveLog.Checked);
            if (OnRefresh != null)
            {
                OnRefresh(this, null);
            }
        } 
        public void SetContextMenu(bool isChecked,bool isUpdateShowComments)
        {
            if (isUpdateShowComments)
            {
                tsMoveComments.Checked = isChecked;
            }
            else
            {
                tsMoveLog.Checked = isChecked;
            }
        }
        public void Refresh(bool showComments, bool showMoveLog)
        {
            notationText1.ClearNotationText(0, true);
            for (int i = 0; i < this.Game.Moves.Count; i++)
            {
                Move m = this.Game.Moves[i];
                m.Game = this.Game;
                AddToNotation(m, false);
            }
            this.notationText1.SetSelection(this.Game.CurrentMove);
        }
        #endregion
    }
}