﻿using System;
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
    public partial class Notations
    {
        #region DataMember
       

        #endregion

        #region Helpers
        private string GetGameResult(string result)
        {
            switch (result)
            {
                case "1-0":
                    return "WhiteWin";
                case "0-1":
                    return "WhiteLose";
                default:
                    return null;

            }
        }
        #endregion

    }
}
