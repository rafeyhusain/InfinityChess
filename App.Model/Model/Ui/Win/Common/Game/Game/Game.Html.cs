using System;
using App.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using InfinitySettings.EngineManager;

namespace App.Model
{
    public partial class Game
    {   
        #region GameHtml

        public string ToGameHtml()
        {
            string html = "";

            #region Load Notations 

            string notations = string.Empty;
            foreach (DataRow dr in Moves.DataTable.Rows)
            {
                Move m = new Move(dr);
                m.Game = this;
                notations += m.SingleNotation + " ";
            }

            if (Flags.IsGameFinished)
            {
                notations += "<br/>" + GameResultString;
            }

            #endregion

            #region Prepare Html

            html += @"<html>
                        <head>
                            <title></title>
                        </head>
            
                        <body>
                            <table>
                                <tr>
                                    <td>
                                        <h2>
                                            InfinityChess, Innovative Solutions,</h2>
                                    </td>
                                    <td>
                                        <h3>" + GameData.DateString + @"</h3>
                                    </td>
                                </tr>
                            </table>
                            <hr />
                            <table>
                                <tr>
                                    <td>
                                        <img alt="""" src=""" + Ap.FileWhiteBox + @""" />
                                    </td>
                                    <td>
                                        <h4>" +Player1.PlayerTitle + @" </h4>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img alt="""" src=""" + Ap.FileBlackBox + @""" />
                                    </td>
                                    <td>
                                        <h4>" + Player2.PlayerTitle + @" </h4>
                                    </td>
                                </tr>
                            </table>
                            <h4> " + GameType.ToString() + @" </h4>
                            <p>
                                " + notations + @"
                            </p>
                    </body>
                </html>";
            
            #endregion

            return html;
        }

        public string ToGameDiagram()
        {
            string html = "";

            #region Prepare Html

            html += @"<html>
                        <head>
                            <title></title>
                        </head>            
                        <body>
                            <table>
                                <tr>
                                    <td>
                                        <h2>
                                            InfinityChess, Innovative Solutions,</h2>
                                    </td>
                                    <td>
                                        <h3>" + GameData.DateString + @"</h3>
                                    </td>
                                </tr>
                            </table>
                            <hr />
                            <IMG width=""60%"" height=""90%""  alt="""" align=baseline src=""" + Ap.FilePrintDiagram + @""">
                      </body>
                 </html>";

            #endregion

            return html;
        }

        #endregion
    }
}
