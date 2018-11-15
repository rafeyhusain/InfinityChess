using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.ComponentModel;
using App.Model;
using InfinitySettings.Streams;

namespace App.Model
{
    public partial class UCIEngine
    {
        #region Process Output

        private void ProcessUCIInfo(string uciData)
        {
            UCIInfoEventArgs e = null;

            ResetTimer();

            if (string.IsNullOrEmpty(uciData) || !uciData.StartsWith("info"))
            {
                return;
            }

            #region DataMembers

            string currentMove = null;
            int currentMoveNumber = -1;
            int depth = -1;
            long time = -1;
            long nodes = -1;
            long nps = -1;
            int scoreCP = -1;
            string pv = null;
            int multipv = -1;
            int seldepth = -1;
            long cpuload = -1;
            int tbHits = -1;
            int mate = -1;
            bool isLowerBound = uciData.Contains("lowerbound ");
            bool isUpperBound = uciData.Contains("upperbound ");

            string[] infoItemsSeparator = { " " };
            string[] infoItems = uciData.Split(infoItemsSeparator, StringSplitOptions.RemoveEmptyEntries);
            string currentItem;

            #endregion

            #region Parse Analysis

            uciData = uciData.Replace("lowerbound ", "");
            uciData = uciData.Replace("upperbound ", "");

            for (int i = 0; i < infoItems.Length; )
            {
                currentItem = infoItems[i];
                if (currentItem != "info")
                {
                    switch (currentItem)
                    {
                        case "currmove":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    currentMove = infoItems[i + 1];
                                    i += 2;
                                }
                                break;
                            }
                        case "currmovenumber":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    currentMoveNumber = Convert.ToInt32(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        case "depth":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    depth = Convert.ToInt32(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        case "nodes":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    nodes = Convert.ToInt64(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        case "time":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    time = Convert.ToInt64(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        case "nps":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    nps = Convert.ToInt64(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        case "pv":
                            {
                                i += 1;
                                if (i + 2 <infoItems.Length)
                                {
                                    subPonderMove = infoItems[i + 2];
                                }
                                for (; i < infoItems.Length; i++)
                                {
                                     pv += " " + infoItems[i];
                                }
                                
                                break;
                            }
                        case "cp":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    scoreCP = Convert.ToInt32(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        case "multipv":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    multipv = Convert.ToInt32(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        case "seldepth":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    seldepth = Convert.ToInt32(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        case "cpuload":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    cpuload = Convert.ToInt64(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        case "tbhits":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    tbHits = Convert.ToInt32(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        case "mate":
                            {
                                if (i < infoItems.Length - 1)
                                {
                                    mate = Convert.ToInt32(infoItems[i + 1]);
                                    i += 2;
                                }
                                break;
                            }
                        default:
                            {
                                i += 1;
                                break;
                            }
                    }
                }
                else
                {
                    i += 1;
                }
            }

            #endregion

            #region Fire Event

            if (this.IsKibitzer)
            {
                TestDebugger.Instance.WriteEngineOutput(EngineName, uciData);
            }
            e = new UCIInfoEventArgs(currentMove, currentMoveNumber, depth, time, nodes, nps, scoreCP, pv,
                                        multipv, seldepth, cpuload, tbHits, isLowerBound, isUpperBound, mate);
            if (InfoReceived != null)
            {
                InfoReceived(this, e);
            }

            #endregion

        }

        #endregion
    }
}

