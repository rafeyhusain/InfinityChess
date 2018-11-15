using System;
using System.Collections.Generic;
using System.Text;
using App.Model;
using InfinitySettings.UCIManager;
using System.Diagnostics;
namespace App.Model
{
    public enum PlayerColorE
    { 
        None,
        White,
        Black
    }

    public class Player : ICloneable
    {
        #region Data Members
        public Game Game = null;
        public bool Resigned = false;
        public bool Draw = false;
        public Book Book = null;
        public string Title = "";

        public event UCIEngine.MoveReceivedHandler MoveReceived;        
        #endregion

        #region Ctor

        public Player(Game game, PlayerColorE color)
        {
            Game = game;
            Color = color;
        }

        #endregion

        #region Properties
        public PlayerColorE Color;

        private string _playerTitle = string.Empty;
        public string PlayerTitle
        {
            [DebuggerStepThrough]
            get
            {

                //if (_engine != null && _engine.IsClosed == false)
                //{
                //    _playerTitle = _engine.EngineName;
                //}
                //else if (InfinitySettings.Settings.UserProfile != null)
                //{
                //    _playerTitle = InfinitySettings.Settings.UserProfile.LastName;
                //}
                //else
                //{
                //    _playerTitle = _title;
                //}

                return _playerTitle;
            }
            [DebuggerStepThrough]
            set
            {
                _playerTitle = value;
            }
        }

        public PlayerType PlayerType
        {
            [DebuggerStepThrough]
            get { return HasEngine ? PlayerType.Engine : PlayerType.Human; }
        }

        private UCIEngine _engine;
        public UCIEngine Engine
        {
            [DebuggerStepThrough]
            get { return _engine; }
            [DebuggerStepThrough]
            set
            {
                _engine = value;
                if (_engine != null)
                {
                    _engine.MoveReceived += new UCIEngine.MoveReceivedHandler(_engine_MoveReceived);                    
                    _engine.IllegalMove += new UCIEngine.IllegalMoveHandler(_engine_IllegalMove);
                    _engine.Error += new UCIEngine.ErrorHandler(_engine_Error);                    
                }
            }
        }

        public bool HasEngine
        {
            [DebuggerStepThrough]
            get { return Engine != null; }
        }

        public bool IsWhite
        {
            [DebuggerStepThrough]
            get { return Color == PlayerColorE.White; }
        }

        public bool IsBlack
        {
            [DebuggerStepThrough]
            get { return Color == PlayerColorE.Black; }
        }

        public bool IsEngine
        {
            [DebuggerStepThrough]
            get { return PlayerType == PlayerType.Engine; }
        }

        public bool IsHuman
        {
            [DebuggerStepThrough]
            get { return PlayerType == PlayerType.Human; }
        }

        public bool IsBookAvailable
        {
            [DebuggerStepThrough]
            get { return Book != null && Book.IsAvailable; }
        }

        
        #endregion

        #region Events

        void _engine_Error(object sender, UCIErrorEventArgs e)
        {

        }

        void _engine_IllegalMove(object sender, UCIIllegalMoveEventArgs e)
        {

        }

        void _engine_UndoMoveReceived(object sender, UCIUndoMoveEventArgs e)
        {

        }

        void _engine_MoveReceived(object sender, UCIMoveEventArgs e)
        {
            if (MoveReceived != null)
            {
                MoveReceived(sender, e);
            }
        }
    
        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Player Clone() 
        { 
            return (Player)this.MemberwiseClone(); 
        }

        public void ResetTitle(string newTitle)
        {
            this.Title = newTitle;
        }

        #endregion

        #region CloseEngine
        public void CloseEngine()
        {
            if (HasEngine)
            {
                Engine.Close();
            }
        } 
        #endregion

        #region PauseEngine
        public void PauseEngine()
        {
            if (HasEngine)
            {
                Engine.Pause();
            }
        } 
        #endregion

        #region ResumeEngine
        internal void ResumeEngine()
        {
            if (HasEngine)
            {
                Engine.Resume();
            }
        } 
        #endregion
    }
}
