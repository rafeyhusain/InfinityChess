using System;
using App.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InfinityChess;
using System.Windows.Forms;
using ChessLibrary;
using System.Diagnostics;

namespace App.Model
{
    public class BaseFlags
    {
        #region Data Members

        protected string flags = string.Empty;

        #endregion

        #region Ctor

        public BaseFlags()
        {
           
        }

        public BaseFlags(string moveFlags)
        {
            this.Flags = moveFlags;
        }

        #endregion

        #region Properties

        #region Core
        public virtual string Flags
        {
            [DebuggerStepThrough]
            get { return flags; }
            [DebuggerStepThrough]
            set { flags = value; } 
        }

        #endregion
     
        #endregion

        #region Methods 

        protected void SetMoveFlag(string flag, bool enable)
        {
            if (enable)
            {
                if (!Flags.Contains(flag))
                {
                    Flags += flag;
                }
            }
            else
            {
                Flags = Flags.Replace(flag, "");
            }
        }

        #endregion

        #region Methods
        public void SetFlags(string value)
        {
            flags = value;
        }

        public virtual void Reset()
        {
            flags = "";
        } 
        #endregion

        public override string ToString()
        {
            return Flags;
        }
    }
}
