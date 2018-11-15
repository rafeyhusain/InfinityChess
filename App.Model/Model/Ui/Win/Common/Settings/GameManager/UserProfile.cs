using System; using App.Model;
using System.Collections.Generic;
using System.Text;
using System.IO;
using InfinitySettings.Streams;
using System.Diagnostics;
namespace InfinitySettings.GameManager
{
    public class UserProfile
    {        
        
        #region Ctor 
        public UserProfile()
        {
            this.LoadUserProfile();
        }
        #endregion

        #region Instance 
        private static UserProfile instance = null;
        public static UserProfile Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserProfile();
                }

                return instance;
            }
            set { instance = value; }
        }
        #endregion

        #region Properties 

        bool _skipOnProgramStart;
        public bool SkipOnProgramStart
        {
            [DebuggerStepThrough]
            get { return _skipOnProgramStart; }
            [DebuggerStepThrough]
            set { _skipOnProgramStart = value; }
        }

        string _lastName;
        public string LastName
        {
            [DebuggerStepThrough]
            get { return _lastName; }
            [DebuggerStepThrough]
            set { _lastName = value; }
        }

        string _firstName;
        public string FirstName
        {
            [DebuggerStepThrough]
            get { return _firstName; }
            [DebuggerStepThrough]
            set { _firstName = value; }
        }

        string _town;
        public string Town
        {
            [DebuggerStepThrough]
            get { return _town; }
            [DebuggerStepThrough]
            set { _town = value; }
        }

        string _computer;
        public string Computer
        {
            [DebuggerStepThrough]
            get { return _computer; }
            [DebuggerStepThrough]
            set { _computer = value; }
        }

        string _playerStatus;
        public string PlayerStatus
        {
            [DebuggerStepThrough]
            get { return _playerStatus; }
            [DebuggerStepThrough]
            set { _playerStatus = value; }
        }

        string _title;
        public string Title
        {
            [DebuggerStepThrough]
            get { return _title; }
            [DebuggerStepThrough]
            set { _title = value; }
        }

        public string FullName
        {
            [DebuggerStepThrough]
            get { return FirstName + " " + LastName; }
          
        }

        #endregion

        #region Methods 

        public void LoadUserProfile()
        {
            string profile = GetProfile();
            if (!string.IsNullOrEmpty(profile))
            {
                LoadValues(profile);
            }
        }
     
        private void LoadValues(string profile)
        {
            string[] separators = { ",", "\n\r", "\r\n" };
            string[] valuePairs = profile.Split(separators,StringSplitOptions.RemoveEmptyEntries );
            string[] singlePair ;
            string name = string.Empty;
            string value = string.Empty;
            foreach (string  valuePair in valuePairs)
            {
                if (!string.IsNullOrEmpty(valuePair))
                {
                    singlePair = valuePair.Split(":".ToCharArray());
                    switch (singlePair[0])
                    {
                        case "SkipOnProgramStart":
                            {
                                _skipOnProgramStart = Convert.ToBoolean(singlePair[1]);
                                break;
                            }
                            case "LastName":
                            {
                                _lastName = singlePair[1];
                                break;
                            }
                            case "FirstName":
                            {
                                _firstName= singlePair[1];                                
                                break;
                            }
                            case "Town":
                            {
                                _town= singlePair[1];
                                break;
                            }
                            case "Computer":
                            {
                                _computer = singlePair[1];                                
                                break;
                            }
                            case "PlayerStatus":
                            {
                                _playerStatus= singlePair[1];                                
                                break;
                            }
                            case "Title":
                            {
                                _title= singlePair[1];                                
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }

        private string GetProfile()
        {
            string profile = string.Empty;            
            profile = InfinityStreamsManager.ReadFromFile(Ap.FileUserProfile);
            return profile;
        }

        public void SaveProfile()
        {
            string profile = string.Empty;            
            string profileTemplate = @"
SkipOnProgramStart:{0},
LastName:{1},
FirstName:{2},
Town:{3},
Computer:{4},
PlayerStatus:{5},
Title:{6}";
            profile = string.Format(profileTemplate, SkipOnProgramStart, LastName, FirstName, Town, Computer, PlayerStatus, Title);
            InfinityStreamsManager.WriteFile(Ap.FileUserProfile, profile);            
        }

        #endregion        

        #region Child Classes 

        public struct PlayerStatusValues
        {
            public const string Beginner = "Beginner";
            public const string HobbyPlayer = "Hobby Player";
            public const string ClubPlayer = "Club Player";
        }

        public struct PlayerTitle
        {
            public const string Mr = "Mr";
            public const string Ms = "Ms";
        }

        #endregion

    }
}
