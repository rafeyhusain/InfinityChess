using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;

namespace App.Win
{
    public partial class NotationTextUc : UserControl, IGameUc
    {
        #region DataMember
        NotationText notationText1; 
        #endregion

        #region Constructor
        public NotationTextUc()
        {
            InitializeComponent();
        } 
        #endregion

        #region Load
        private void NotationTextUc_Load(object sender, EventArgs e)
        {

        } 
        #endregion

        #region Helper
        private void AddToNotation(Move m)
        {
            string notation = string.Empty;
            if (Ap.Options.IsSingleNotation)
            {
                notation = m.SingleNotation;
            }
            else
            {
                notation = m.DoubleNotation;
            }

            switch (m.Flags.VariationType)
            {
                case VariationTypeE.Variation:
                    notationText1.AddVariation(m);
                    break;
                case VariationTypeE.MainLine:
                    break;
                case VariationTypeE.Insert:
                    break;
                case VariationTypeE.Overwrite:
                    break;
                default:
                    notationText1.AddMove(m, 0);
                    break;
            }
        }

        public void SetSelection(Move m)
        {
            notationText1.SetSelection(m);
        } 
        #endregion

        #region IGameUc Members

        public void NewGame()
        {
            //notationText1.RefreshNotationText(0);
        }

        public void Init()
        {
            //System.Windows.Forms.Integration.ElementHost elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            //notationText1 = new NotationText();
            //elementHost1.Child = notationText1;
            //elementHost1.Dock = DockStyle.Fill;
            //pnlBackground.Controls.Add(elementHost1);

            //Ap.Game.Notations.EventOnAddToNotation += new Notations.OnAddToNotation(Notations_EventOnAddToNotation);

            //Ap.Game.Notations.EventToClearNotation += new Notations.OnToClearNotation(Notations_EventToClearNotation);
            //Ap.Game.Notations.EventCommnetsToNotation += new Notations.OnCommnetsToNotation(Notations_EventCommnetsToNotation);
            //Ap.Game.Notations.EventOnResultToNotation += new Notations.OnResultToNotation(Notations_EventOnResultToNotation);

            //Ap.Game.Notations.MoveToEventE += new Notations.MoveToEventHandler(Notations_MoveToEventE);
            //Ap.Game.Notations.MoveToEvent += new EventHandler(Notations_MoveToEvent);
        }

        public void UnInit()
        {
            //Ap.Game.Notations.EventOnAddToNotation -= new Notations.OnAddToNotation(Notations_EventOnAddToNotation);

            //Ap.Game.Notations.EventCommnetsToNotation -= new Notations.OnCommnetsToNotation(Notations_EventCommnetsToNotation);
            //Ap.Game.Notations.EventOnResultToNotation -= new Notations.OnResultToNotation(Notations_EventOnResultToNotation);

            //Ap.Game.Notations.MoveToEventE -= new Notations.MoveToEventHandler(Notations_MoveToEventE);
            //Ap.Game.Notations.MoveToEvent -= new EventHandler(Notations_MoveToEvent);
        }

        #region Events Methods

        void Notations_MoveToEvent(object sender, EventArgs e)
        {
            SetSelection(Ap.Game.CurrentMove);
        }

        void Notations_MoveToEventE(MoveToE moveTo)
        {
            SetSelection(Ap.Game.CurrentMove);
        }

        void Notations_EventToClearNotation(object sender)
        {
            notationText1.ClearNotationText(0);
        }

        void Notations_EventOnResultToNotation(object sender, string result)
        {
            notationText1.Result(result);
        }

        void Notations_EventCommnetsToNotation(object sender, Move m, string comments, bool isbefore)
        {
            if (!string.IsNullOrEmpty(comments))
            {
                if (m != null)
                {
                    SetSelection(m);
                }
                notationText1.AddComments(isbefore, comments + "  ");
            }
            else
            {
                notationText1.RemoveComments();
            }
        }

        void Notations_EventOnAddToNotation(object sender, Move m)
        {
            AddToNotation(m);
        }
        #endregion
        #endregion
    }
}
