using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace App.Model
{
    public class GameUcList : Dictionary<string, IGameUc>
    {
        #region Methods
        public void Init()
        {
            foreach (IGameUc c in this.Values)
            {
                if (c != null)
                {
                    c.Init();
                }
            }
        }

        public void UnInit()
        {
            foreach (IGameUc c in this.Values)
            {
                if (c != null)
                {
                    c.UnInit();
                }
            }
        }

        public void NewGame()
        {
            foreach (IGameUc c in this.Values)
            {
                if (c != null)
                {
                    c.NewGame();
                }
            }
        }

        public void SetNull()
        {
            foreach (string key in this.Keys)
            {
                base[key] = null;
            }
        }

        public new void Add(string key, IGameUc c)
        {
            if (base.ContainsKey(key))
            {
                base[key] = c;
            }
            else
            {
                base.Add(key, c);
            }
        }
        #endregion        

    }
}
