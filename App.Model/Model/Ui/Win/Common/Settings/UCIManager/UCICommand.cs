using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    class UciCommand
    {
        public UciCommand()
        {

        }

        public const string LineBreak = "\n";
        public const string UCI = "uci" + LineBreak;
        public const string IsReady = "isready" + LineBreak;
        public const string XBoard = "xboard" + LineBreak;
        public const string New = "new" + LineBreak;
        public const string UCINewGame = "ucinewgame" + LineBreak;
        public const string Go = "go" + LineBreak;
        public const string SetBoard = "setboard ";
        
        // If reuse=1, xboard may reuse your engine for multiple games. 
        // If reuse=0 (or if the user has set the -xreuse option on xboard's command line), 
        // xboard will kill the engine process after every game and start a fresh process for the next game. 
        public const string Reuse = "reuse={0}" + LineBreak;

        // If reuse=1, xboard may reuse your engine for multiple games. 
        // If reuse=0 (or if the user has set the -xreuse option on xboard's command line), 
        // xboard will kill the engine process after every game and start a fresh process for the next game. 
        public const string Colors = "colors={0}" + LineBreak;

        // If ics=1, xboard will use the protocol's new "ics" command to inform the engine of whether or not 
        // it is playing on a chess server; if ics=0, it will not.         
        public const string ICS = "ics={0} " + LineBreak;        

        public string FEN = string.Empty;

        public const string SetOption = "setoption name {0} value {1}" + LineBreak;
        public const string Position = "position fen {0} moves {1}" + LineBreak;

        public const string GoBtimeWtime = "go btime {0} wtime {1}" + LineBreak;//go btime 242000 wtime 242000 
        public const string GoBtimeWtimeAndIncrement = "go btime {0} wtime {1} winc {2} binc {3}" + LineBreak;//go btime 242000 wtime 242000 winc 2000 binc 2000
        public const string GoPonderBtimeWtime = "go ponder btime {0} wtime {1}" + LineBreak;//go ponder btime 243000 wtime 244000 
        public const string GoPonderTimeAndIncrement = "go ponder btime {0} wtime {1} winc {2} binc {3}" + LineBreak;//go ponder btime 243000 wtime 244000 winc 2000 binc 2000
        public const string PositionStartpos = "position startpos";
        public const string PositionAndMove = "position moves {0}";
        public const string PositionStartposAndMove = "position startpos moves {0}" + LineBreak;
        //public const string PositionAndMove = "position {0} moves {1}";
        public const string PositionFENStartPosAndMove = "position {0} statpos {1} moves {2}";        
        public const string GoMoveTime = "go movetime {0}";
        public const string Feature = "feature {0}={1}" + LineBreak;// "feature myname="Miracle Chess 0.9"";        
        public const string PlayOther = "playother" + LineBreak;
        public const string Quit = "quit" + LineBreak;
        public const string Force = "force" + LineBreak;
        public const string White = "white" + LineBreak;
        public const string Black = "black" + LineBreak;
        public const string ExactNumberOfSecondsPerMove = "st {0}" + LineBreak;//"st {seconds} "
        public const string WholeGameInThisTime = "level 0 {0} {1}" + LineBreak;//"level 0 {minutes} {seconds} "
        public const string SecondsPerMove = "st {0}" + LineBreak;//"st {seconds}"
        public const string ThinkToDepth = "sd {0}" + LineBreak;//"sd {depth} "
        public const string Move = "move {0}" + LineBreak;
        public const string UserMove = "usermove {0}" + LineBreak;
        public const string Draw = "draw" + LineBreak;
        public const string Resign = "resign" + LineBreak;
        public const string Result = "result {0} {{1}}" + LineBreak; // result {result} {{comment}}
        public const string Hint = "hint" + LineBreak;
        public const string Undo = "undo" + LineBreak;
        public const string Name = "name {0}" + LineBreak; // "name {name}"
        public const string Analyze = "analyze" + LineBreak;
        public const string GoInfinite = "go infinite" + LineBreak;
        public const string Stop = "stop" + LineBreak;
        public const string Exit = "exit" + LineBreak;// Leave analyze mode. 
        public const string BK = "bk" + LineBreak;// Show book moves from this position, if any. 

        public const string Rating = "rating {0} {1}" + LineBreak; // "rating {2600} {1500} "
        public const string Computer = "computer" + LineBreak; //The opponent is also a computer chess engine. Some engines alter their playing style when they receive this command. 
        public const string Pause = "pause" + LineBreak;
        public const string Resume = "resume" + LineBreak;
        public const string Memory = "memory {0}" + LineBreak; // "memory {0} ", This command informs the engine on how much memory it is allowed to use maximally, in MegaBytes
        public const string Cores = "cores {0}" + LineBreak; // "cores {0} ", This command informs the engine on how many CPU cores it is allowed to use maximally.

        /*
         * This command informs the engine in which directory (given by the PATH argument) it can find end-game tables of the specified TYPE. 
         * The TYPE argument can be any character string which does not contain spaces. Currently nalimov and scorpio are defined types, 
         * for Nalimov tablebases and Scorpio bitbases, respectively, but future developers of other formats are free to define 
         * their own format names. 
        */
        public const string EGTPath = "egtpath {0} {1} " + LineBreak; // "egtpath {type} {path} "

        /*
         * This command changes the setting of the option NAME defined by the engine (through an earlier feature command) 
         * to the given VALUE. XBoard will in general have no idea what the option means, 
         * and will send the command only when a user changes the value of this option through a menu, 
         * or at startup of the engine (before the first 'cores' command or, if that is not sent, the first 'new' command) 
         * in reaction to command-line options. The NAME echoes back to the engine the string that was identified as an option NAME 
         * in the feature command defining the option. The VALUE is of the type (numeric or text or absent) that was implied by the 
         * option type specified in this feature command, i.e. with 'spin' and 'check' options VALUE will be a decimal integer 
         * (in the latter case 0 or 1), with 'combo' and 'string' options VALUE will be a text string, and with 'button' 
         * and 'save' options no VALUE will be sent at all. 
        */
        public const string Option = "option {0}[={0}]" + LineBreak; // "option {name}[={value}] "

        public const string TellOpponent = "tellopponent {0}" + LineBreak;// "tellopponent {message}"
        public const string TellOthers = "tellothers {0}" + LineBreak;// "tellothers {message}"
        public const string TellAll = "tellall {0}" + LineBreak;// "tellall {message}"
        public const string TellUser = "telluser {0}" + LineBreak;// "telluser {message}"
        public const string TellUserError = "tellusererror {0}" + LineBreak;// "tellusererror {message}"
        public const string AskUser = "askuser {0}" + LineBreak;// "askuser {message}"
        public const string TellIcs = "tellics {0}" + LineBreak;// "tellics {message}"
        public const string TellIcsNoAlias = "tellicsnoalias {0}" + LineBreak;// "tellicsnoalias {message}"

        public const string UciOk = "uciok";
        public const string ReadyOk = "readyok";
        public const string IllegalMoveMessagePrefix = "Illegal move" + LineBreak;
        public const string ErrorMessagePrefix = "Error" + LineBreak;
        public const string IdNamePrefix = "id name";
        public const string IdAuthorPrefix = "id author";
        public const string OptionName = "option name";
        
    }

    public enum UCIInfoAnalysisType
    {
        CurrentMove = 1,
        DepthScoreTimeNodesNpsPv = 2,
        DepthTimeNodesNps = 3,
        Depth = 4
    }

    public enum UCIInfoAnalysisItem
    {
        currmove = 1,
        currmovenumber = 2,
        depth = 3,
        nodes = 4,
        time = 5,
        nps = 6,
        pv = 7,
        scoreCP = 8,
        multipv = 9,
        seldepth = 10,
        cpuload = 11,
    }
}
