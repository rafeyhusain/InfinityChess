using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace InfinityChess
{
    public partial class frmInsertNewVariation : Form
    {
        #region Data members

        public Game Game = null;        
        public Move ParentMove = null;
        public VariationTypeE VariationType = VariationTypeE.None; 

        #endregion

        #region Properties
        public bool IsVariation
        {
            get { return panel1.Visible; }
            set { panel1.Visible = value; }
        }

        public int SelectedMoveId
        {
            get { return BaseItem.ToInt32(lstLines.SelectedValue); }
            set { lstLines.SelectedValue = value; }
        }

        public Move SelectedMove
        {
            get { return this.Game.Moves.GetByID(SelectedMoveId); }
            set { SelectedMoveId = value.Id; }
        } 
        #endregion

        #region ctor
        public frmInsertNewVariation(Game game)
        {
            this.Game = game;
            InitializeComponent();
        }

        #endregion

        #region Load
        private void frmInsertNewVariation_Load(object sender, EventArgs e)
        {
            if (ParentMove != null)
            {
                lstLines.DataSource = this.Game.Moves.GetChildLine(ParentMove.Id);
                lstLines.ValueMember = "Id";
                lstLines.DisplayMember = "Line";
            }
        }

        #endregion

        #region Click events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetVariationType(VariationTypeE variationType)
        {
            VariationType = variationType;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNewVariant_Click(object sender, EventArgs e)
        {
            this.SetVariationType(VariationTypeE.Variation);
        }

        private void btnNewMainLine_Click(object sender, EventArgs e)
        {
            this.SetVariationType(VariationTypeE.MainLine);
        }

        private void btnOverwrite_Click(object sender, EventArgs e)
        {
            this.SetVariationType(VariationTypeE.Overwrite);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.SetVariationType(VariationTypeE.Insert);
        }

        private void lstLines_DoubleClick(object sender, EventArgs e)
        {
            if (!IsVariation)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void lstLines_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsVariation)
            {
                switch ((Keys)e.KeyValue)
                {
                    case Keys.Left:
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    case Keys.Right:
                        this.DialogResult = DialogResult.OK;
                        e.Handled = true;
                        this.Close();
                        break;
                }
            }
        }

        #endregion
    }
}