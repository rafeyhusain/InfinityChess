using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using App.Model;
using System.IO;
using InfinitySettings.Streams;
using AppEngine;

namespace App.Model
{
    public class E2eResult
    {
        #region DataMemebers

        public Game Game;

        public string Engine1Name = "";
        public string Engine2Name = "";
        public int Engine1WhiteWin = 0;
        public int Engine1BlackWin = 0;
        public int Engine2WhiteWin = 0;
        public int Engine2BlackWin = 0;
        public int Draw = 0;
        public int NoResult = 0;


        string tab = "\t";
        private string matchesRows = "";

        #endregion

        #region Ctor

        public E2eResult(Game game)
        {
            this.Game = game;
        }

        #endregion

        #region Properties

        #region Calculated 

        public int Engine1WinTotal
        {
            get { return Engine1WhiteWin + Engine1BlackWin; }
        }
                
        public int Engine2WinTotal
        {
            get { return Engine2WhiteWin + Engine2BlackWin; }
        }

        public int WhiteWinTotal
        {
            get { return Engine1WhiteWin + Engine2WhiteWin; }
        }

        public int BlackWinTotal
        {
            get { return Engine1BlackWin + Engine2BlackWin; }
        }

        public int WinTotal
        {
            get { return WhiteWinTotal + BlackWinTotal; }
        }

        public string Engine1Result
        {
            get
            {
                return Engine1Name + tab + Engine1WhiteWin + tab + Engine1BlackWin + tab + Engine1WinTotal;
            }
        }

        public string Engine2Result
        {
            get
            {
                return Engine2Name + tab + Engine2WhiteWin + tab + Engine2BlackWin + tab + Engine2WinTotal;
            }
        }

        public string EnginesTotalResult
        {
            get
            {
                return "Total" + tab + WhiteWinTotal + tab + BlackWinTotal + tab + WinTotal;
            }
        }

        public int TotalMatches
        {
            get { return WinTotal + Draw + NoResult; }
        }

        public int Engine1LoseTotal
        {
            get { return TotalMatches - Engine1WinTotal - Draw - NoResult; }
        }

        public int Engine2LoseTotal
        {
            get { return TotalMatches - Engine2WinTotal - Draw - NoResult; }
        }

        public int Engine1WhiteLoseTotal
        {
            get { return TotalMatches - Engine2BlackWin - Draw - NoResult; }
        }

        public int Engine1BlackLoseTotal
        {
            get { return TotalMatches - Engine2WhiteWin - Draw - NoResult; }
        }

        public int Engine2WhiteLoseTotal
        {
            get { return TotalMatches - Engine1BlackWin - Draw - NoResult; }
        }

        public int Engine2BlackLoseTotal
        {
            get { return TotalMatches - Engine1WhiteWin - Draw - NoResult; }
        }

        public int Engine1LosePercent
        {
            get 
            {
                if (TotalMatches == 0)
                {
                    return 0;
                } 
                return (int)((double)Engine1LoseTotal / TotalMatches * 100);
            }
        }

        public int Engine2LosePercent
        {
            get 
            {
                if (TotalMatches == 0)
                {
                    return 0;
                }
                return (int)((double)Engine2LoseTotal / TotalMatches * 100); 
            }
        }

        public int Engine1WinPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                } 
                return (int)((double)Engine1WinTotal / TotalMatches * 100);
            }
        }

        public int Engine2WinPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                } 
                return (int)((double)Engine2WinTotal / TotalMatches * 100);
            }
        }

        public int Engine1WhiteWinPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                }
                return (int)((double)Engine1WhiteWin / TotalMatches * 100);
            }
        }

        public int Engine2WhiteWinPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                }
                return (int)((double)Engine2WhiteWin / TotalMatches * 100);
            }
        }

        public int Engine1WhiteLostPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                }
                return (int)((double)Engine2BlackWin / TotalMatches * 100);
            }
        }

        public int Engine2WhiteLostPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                }
                return (int)((double)Engine1BlackWin / TotalMatches * 100);
            }
        }

        public int Engine1BlackWinPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                }
                return (int)((double)Engine1BlackWin / TotalMatches * 100);
            }
        }

        public int Engine2BlackWinPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                }
                return (int)((double)Engine2BlackWin / TotalMatches * 100);
            }
        }

        public int Engine1BlackLostPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                }
                return (int)((double)Engine2WhiteWin / TotalMatches * 100);
            }
        }

        public int Engine2BlackLostPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                }
                return (int)((double)Engine1WhiteWin / TotalMatches * 100);
            }
        }

        public int DrawPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                } 
                return (int)((double)Draw / TotalMatches * 100);
            }
        }

        public int NoResultPercent
        {
            get
            {
                if (TotalMatches == 0)
                {
                    return 0;
                } 
                return (int)((double)NoResult / TotalMatches * 100);
            }
        }

        #endregion

        #endregion

        #region Helper Methods

        public void Reset()
        {
            Engine1Name = "";
            Engine2Name = "";
            Engine1WhiteWin = 0;
            Engine1BlackWin = 0;
            Engine2WhiteWin = 0;
            Engine2BlackWin = 0;
            Draw = 0;
            NoResult = 0;
            matchesRows = "";
        }

        public string GetResultString()
        {
            string html = "";

            #region Prepare Html

            html += @"<html>
<head>
    <title></title>
</head>
<body style='background-color: #FFFFD2'>
    <h2>
        Result Summary</h2>
    <table style='font-family: Calibri; font-size: 12px;'  border='1'>
        <tr style='font-weight: bold;'>
            <td>
                Engine
            </td>
            <td>
                Total Matches
            </td>
            <td>
                Win
            </td>
            <td>
                Lost
            </td>
            <td>
                Draw
            </td>
            <td>
                No Result
            </td>
        </tr>
        <tr>
            <td>
                " + Engine1Name + @"
            </td>
            <td bgcolor='Silver'>
                " + TotalMatches + @"
            </td>
            <td>
                " + Engine1WinTotal + " (" + Engine1WinPercent + "%)" + @"
            </td>
            <td>
                " + Engine1LoseTotal + " (" + Engine1LosePercent + "%)" + @"
            </td>
            <td>
                " + Draw + " (" + DrawPercent + "%)" + @"
            </td>
            <td>
                " + NoResult + " (" + NoResultPercent + "%)" + @"
            </td>
        </tr>
        <tr>
            <td>
                " + Engine2Name + @"
            </td>
            <td bgcolor='Silver'>
                " + TotalMatches + @"
            </td>
            <td>
                " + Engine2WinTotal + " (" + Engine2WinPercent + "%)" + @"
            </td>
            <td>
                " + Engine2LoseTotal + " (" + Engine2LosePercent + "%)" + @"
            </td>
            <td>
                " + Draw + " (" + DrawPercent + "%)" + @"
            </td>
            <td>
                " + NoResult + " (" + NoResultPercent + "%)" + @"
            </td>
        </tr>
    </table>
    <p />
    <h2>
        Result Detail</h2>
    <table style='font-family: Calibri; font-size: 12px;' border='1'>
        <tr style='font-weight: bold;'>
            <td>
                Engine
            </td>
            <td>
                Total Matches
            </td>
            <td>
                Win Count When White
            </td>
            <td>
                Win Count When Black
            </td>
            <td>
                Total Wins
            </td>
            <td>
                Lost Count When White
            </td>
            <td>
                Lost Count When Black
            </td>
            <td>
                Total Lost
            </td>
            <td>
                Draw
            </td>
            <td>
                No Result
            </td>
        </tr>
        <tr>
            <td>
                " + Engine1Name + @"
            </td>
            <td bgcolor='Silver'>
                " + TotalMatches + @"
            </td>
            <td>
                " + Engine1WhiteWin + " (" + Engine1WhiteWinPercent + "%)" + @"
            </td>
            <td>
                " + Engine1BlackWin + " (" + Engine1BlackWinPercent + "%)" + @"
            </td>
            <td bgcolor='#E0E0E0'>
                " + Engine1WinTotal + " (" + Engine1WinPercent + "%)" + @"
            </td>
            <td>
                " + Engine2BlackWin + " (" + Engine1WhiteLostPercent + "%)" + @"
            </td>
            <td>
                " + Engine2WhiteWin + " (" + Engine1BlackLostPercent + "%)" + @"
            </td>
            <td bgcolor='#E0E0E0'>
                " + Engine1LoseTotal + " (" + Engine1LosePercent + "%)" + @"
            </td>
            <td>
                " + Draw + " (" + DrawPercent + "%)" + @"
            </td>
            <td>
                " + NoResult + " (" + NoResultPercent + "%)" + @"
            </td>
        </tr>
        <tr>
            <td>
                " + Engine2Name + @"
            </td>
            <td bgcolor='Silver'>
                " + TotalMatches + @"
            </td>
            <td>
                " + Engine2WhiteWin + " (" + Engine2WhiteWinPercent + "%)" + @"
            </td>
            <td>
                " + Engine2BlackWin + " (" + Engine2BlackWinPercent + "%)" + @"
            </td>
            <td bgcolor='#E0E0E0'>
                " + Engine2WinTotal + " (" + Engine2WinPercent + "%)" + @"
            </td>
            <td>
                " + Engine1BlackWin + " (" + Engine2WhiteLostPercent + "%)" + @"
            </td>
            <td>
                " + Engine1WhiteWin + " (" + Engine2BlackLostPercent + "%)" + @"
            </td>
            <td bgcolor='#E0E0E0'>
                " + Engine2LoseTotal + " (" + Engine2LosePercent + "%)" + @"
            </td>
            <td>
                " + Draw + " (" + DrawPercent + "%)" + @"
            </td>
            <td>
                " + NoResult + " (" + NoResultPercent + "%)" + @"
            </td>
        </tr>
    </table>
    " + GetMatchesString() + @"
</body>
</html>";
            #endregion

            return html;
        }

        private string GetMatchesString()
        {
            string html = "";

            #region Prepare Html 

            html += @"
             <p />
    <h2>
        Match Results </h2>
    <table style='font-family: Calibri; font-size: 12px;' border='1'>
        <tr style='font-weight: bold;'>
            <td>
                " + Engine1Name + @"
            </td>
            <td>
                " + Engine2Name + @"
            </td>                 
        </tr>        
        " + matchesRows + @"
    </table>";

            #endregion

            return html;
        }

        public void AddMatch(string engine1Result, string engine2Result, bool isEngine1White)
        {
            if (isEngine1White)
            {
                matchesRows += @"
            <tr>
                <td >
                     " + engine1Result + @"
                </td>
                <td bgcolor='#E0E0E0' >
                    " + engine2Result + @"
                </td>
            </tr>
            ";
            }
            else
            {
                matchesRows += @"
            <tr >
                <td bgcolor='#E0E0E0' >
                     " + engine1Result + @"
                </td>
                <td >
                    " + engine2Result + @"
                </td>                       
            </tr>
            ";
            }            
        }

        #endregion

    }
}
