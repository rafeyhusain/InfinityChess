using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Win;
using App.Model;
using App.Model.Db;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Win
{
    public partial class RoomUc : DockContent
    {
        #region Data Members
        public const string Guid = "da55ff31-3073-45cd-b795-f3e0468d2c7c";

        public delegate void PlayerDataGridHandler(DataTable table);
        public event PlayerDataGridHandler LoadPlayerGrid;

        public delegate void GameDataGridHandler(DataTable table);
        public event GameDataGridHandler LoadGameGrid;

        public delegate void ChallengeDataGridHandler(DataTable table);
        public event ChallengeDataGridHandler LoadChallengeGrid;

        public delegate void RommInfoPageHandler(int roomID, int tounamentID, string url);
        public event RommInfoPageHandler LoadRoomInfoPage;

        public delegate void UserMessagesHandler(DataTable table);
        public event UserMessagesHandler LoadUserMessages;

        private TreeNode SelectedNode;


        private int parentRoomUserCount = 0;
        private bool isUrlBit = true;
        private string url = string.Empty;
        string strVal = "";
        #endregion

        #region Ctor
        public RoomUc()
        {
            InitializeComponent();
        } 
        #endregion

        #region Events

        private void RoomUc_Load(object sender, EventArgs e)
        {
            GetAllRooms();
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (Ap.IsGameInProgress)
            {
                //MessageForm.Show(this.ParentForm, MsgE.ErrorRoomChange);
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Warning, ChatTypeE.OnlineClient, MsgE.ErrorRoomChange, 0);
                e.Cancel = true;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int len = 0;

            string PreviousRoomName = string.Empty;
            int PreviousRoomID = 0;
            if (SelectedNode != null)
            {
                PreviousRoomName = SelectedNode.Text;
                PreviousRoomID = Ap.SelectedRoomID;
            }

            Ap.CurrentUser.RoomID = Ap.SelectedRoomID = Convert.ToInt32(e.Node.Tag);
            SelectedNode = e.Node;

            SetEngine();

            GetDataByRoomId(false);

            if (PreviousRoomID > 0)
            {
                len = PreviousRoomName.IndexOf('(') < 0 ? PreviousRoomName.Length : PreviousRoomName.IndexOf('(');
                ChatClient.Send(ChatAudienceTypeE.Room, ChatMessageTypeE.LeftRoom, ChatTypeE.OnlineClient, PreviousRoomID, Msg.GetMsg(MsgE.InfoUserLeftRoom, Ap.CurrentUser.UserName, PreviousRoomName.Substring(0, len)), 0);
            }

            len = e.Node.Text.IndexOf('(') < 0 ? e.Node.Text.Length : e.Node.Text.IndexOf('(');
            ChatClient.Send(ChatAudienceTypeE.Room, ChatMessageTypeE.EnteredRoom, ChatTypeE.OnlineClient, Convert.ToInt32(e.Node.Tag), Msg.GetMsg(MsgE.InfoUserEnteredRoom, Ap.CurrentUser.UserName, e.Node.Text.Substring(0, len)), 0);
        }

        private static void SetEngine()
        {
            if ((Ap.SelectedRoomID != (int)RoomE.ComputerChess && Ap.SelectedRoomID != (int)RoomE.EngineHall && Ap.SelectedRoomID != (int)RoomE.FreestyleChess && Ap.SelectedRoomID != (int)RoomE.TestRoom && Ap.SelectedRoomID != (int)RoomE.EngineTournaments) || (Ap.SelectedRoomParentID != (int)RoomE.ComputerChess && Ap.SelectedRoomParentID != (int)RoomE.EngineTournaments))
            {
                if (Ap.SelectedRoomID <= (int)RoomE.EngineTournaments && Ap.SelectedRoomID != (int)RoomE.ComputerChess && Ap.SelectedRoomID != (int)RoomE.EngineHall && Ap.SelectedRoomID != (int)RoomE.FreestyleChess && Ap.SelectedRoomID != (int)RoomE.TestRoom)
                {
                    Ap.CurrentUser.UserStatusIDE = UserStatusE.Blank;
                    Ap.CurrentUser.EngineID = 1;

                    Ap.PlayingMode.ChessTypeID = 1;
                    PlayingModeData.Instance.ChessTypeID = 1;

                    if (Ap.PlayingMode.SelectedEngine != null)
                    {
                        Ap.PlayingMode.SelectedEngine.Close();
                        Ap.PlayingMode.SelectedEngine = null;
                    }
                }
                else
                {
                    Ap.CurrentUser.EngineID = -1;
                }
            }
            else
            {
                Ap.CurrentUser.EngineID = -1;
            }

            Ap.CanAutoChallenge = true;
            PlayingModeData.Instance.AutometicAccepts = false;
            PlayingModeData.Instance.AutometicChallenges = false;
            PlayingModeData.Instance.SendEvaluations = false;
            PlayingModeData.Instance.SendExpectedMoves = false;
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            if (Ap.IsGameInProgress)
            {
                MessageForm.Show(this.ParentForm, MsgE.ErrorRoomChange);
                return;
            }

            GetAllRooms();
        }

        #endregion

        #region Methods

        private void GetAllRooms()
        {
            treeView1.Nodes.Clear();

            DataSet ds = SocketClient.GetAllRooms();
            if (ds == null || ds.Tables.Count <= 0)
                return;
            DataTable dt = ds.Tables[0];
            ImageList item = new ImageList();
            item.ImageSize = new Size(16, 16);
            item.Images.Add("category1.png", Image.FromFile(App.Model.Ap.FolderRooms + "category1.png"));
            item.Images.Add("room.png", Image.FromFile(App.Model.Ap.FolderRooms + "room.png"));
            treeView1.ImageList = item;
            PopulateNodes(dt, treeView1.Nodes);
            treeView1.ExpandAll();
            treeView1.SelectedNode = SelectedNode;
            int count = 0;
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Tag.ToString() == Ap.CurrentUser.RoomID.ToString())
                {
                    treeView1.SelectedNode = node;
                    count++;
                    break;
                }
                count = SetSelectedNodes(node, count);
            }
            if (count == 0)
            {
                treeView1.SelectedNode = treeView1.Nodes[1];
            }
        }

        private int SetSelectedNodes(TreeNode ParentNode, int count)
        {
            foreach (TreeNode node in ParentNode.Nodes)
            {
                if (node.Tag.ToString() == Ap.CurrentUser.RoomID.ToString())
                {
                    treeView1.SelectedNode = node;
                    count++;
                    break;
                }
                count = SetSelectedNodes(node, count);
            }
            return count;
        }

        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (String.IsNullOrEmpty(Convert.ToString(dr["ParentId"])))
                {
                    TreeNode tn = new TreeNode();
                    tn.ImageIndex = 0;
                    tn.Text = dr["Name"].ToString();
                    tn.Tag = dr["RoomId"].ToString();
                    tn.SelectedImageIndex = 0;
                    nodes.Add(tn);
                    if (dr["RoomId"].ToString() == Ap.CurrentUser.RoomID.ToString())
                    {
                        SelectedNode = tn;
                    }

                    PopulateChildNodes(dt, tn);
                }
            }
        }

        private void PopulateChildNodes(DataTable dt, TreeNode nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ParentId"] != null && dr["ParentId"].ToString() == nodes.Tag.ToString())
                {
                    TreeNode tn = new TreeNode();
                    tn.ImageIndex = 1;
                    tn.Text = dr["Name"].ToString();
                    tn.Tag = dr["RoomId"].ToString();
                    tn.SelectedImageIndex = 1;
                    nodes.Nodes.Add(tn);

                    if (dr["RoomId"].ToString() == Ap.CurrentUser.RoomID.ToString())
                    {
                        SelectedNode = tn;
                    }

                    PopulateChildNodes(dt, tn);
                }
            }
        }

        public void SetDataByRoomId(DataSet ds, bool isFromTimer)
        {
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables["Room"] != null && ds.Tables["Room"].Rows.Count > 0)
                    {
                        Room room = new Room(Ap.Cxt, ds.Tables["Room"].Rows[0]);

                        if (!string.IsNullOrEmpty(room.TournamentID.ToString()))
                        {
                            Ap.SelectedRoomParentID = room.ParentID;
                            Ap.RoomTournamentID = room.TournamentID;

                            isUrlBit = room.IsUrlBit;
                            url = string.Empty;
                            if (isUrlBit)
                            {
                                if (DBNull.Value.ToString() != room.Html &&
                                    room.Html != string.Empty)
                                {
                                    url = room.Html;
                                }
                            }

                            if (LoadRoomInfoPage != null && !isFromTimer)
                            {
                                LoadRoomInfoPage(Ap.SelectedRoomID, Ap.RoomTournamentID, url);
                            }
                        }
                    }

                    if (ds.Tables["LoggedinUsers"].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(ds.Tables["LoggedinUsers"].Rows[0]["LoggedinUser"].ToString()))
                            tsUserCounter.Text = ds.Tables["LoggedinUsers"].Rows[0]["LoggedinUser"].ToString();
                    }

                    if (ds.Tables.Count == 0)
                    {
                        return;
                    }

                    if (LoadPlayerGrid != null)
                    {
                        LoadPlayerGrid(ds.Tables["Users"]);
                    }

                    if (LoadGameGrid != null)
                    {
                        LoadGameGrid(ds.Tables["Games"]);
                    }

                    if (LoadChallengeGrid != null)
                    {
                        LoadChallengeGrid(ds.Tables["Challenges"]);
                    }

                    if (LoadUserMessages != null)
                    {
                        if (ds.Tables["UserMessages"] != null)
                            LoadUserMessages(ds.Tables["UserMessages"]);
                    }

                    if (ds.Tables["RoomUsersCount"] != null)
                    {
                        if (ds.Tables["RoomUsersCount"].Rows.Count > 0)
                        {
                            if (treeView1.Nodes.Count > 0)
                                SetRoomUsersCount(ds);
                        }
                    }

                    if (ds.Tables["AcceptedChallenge"] != null)
                    {
                        if (ds.Tables["AcceptedChallenge"].Rows.Count > 0)
                        {

                            int challengeID = UData.ToInt32(ds.Tables["AcceptedChallenge"].Rows[0]["ChallengeID"]);
                            InfinityChess.WinForms.MainOnline.ShowMainOnline(challengeID, ChallengeStatusE.Accepted, 0);
                            Ap.CanAutoChallenge = true;
                            return;
                        }
                    }

                    //Only for human tounament rooms
                    if (Ap.SelectedRoomID > (int)RoomE.EngineTournaments && Ap.SelectedRoomParentID != (int)RoomE.ComputerChess && Ap.SelectedRoomParentID != (int)RoomE.EngineTournaments)
                    {
                        if (Ap.IsGameInProgress || Ap.KibitzersCount > 0)
                        {
                            return;
                        }

                        Ap.CurrentUser.UserStatusIDE = UserStatusE.Blank;
                        Ap.CurrentUser.EngineID = 1;

                        Ap.PlayingMode.ChessTypeID = 1;
                        PlayingModeData.Instance.ChessTypeID = 1;

                        if (Ap.PlayingMode.SelectedEngine != null)
                        {
                            Ap.PlayingMode.SelectedEngine.Close();
                            Ap.PlayingMode.SelectedEngine = null;
                        }

                        SocketClient.SetUserEngine(string.Empty, Ap.CurrentUser.UserStatusIDE);
                    }

                    return;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }

        public void GetDataByRoomId(bool isFromTimer)
        {
            if (Ap.CurrentUser.HumanRankIDE == RankE.Guest)
            {
                if (Ap.SelectedRoomID == (int)RoomE.Cafe || Ap.SelectedRoomID == (int)RoomE.Broadcasts || Ap.SelectedRoomID == (int)RoomE.EngineHall)
                {

                    SocketClient.GetDataByRoomID(isFromTimer, Ap.SelectedRoomID, Ap.CurrentUserID);
                    if (ApWin.OnlineClientForm != null && ApWin.OnlineClientForm.statusStrip1.Items.Count > 0)
                    {
                        ApWin.OnlineClientForm.statusStrip1.Items[0].Text = "Done";
                    }
                }
                else
                {
                    if (ApWin.OnlineClientForm != null)
                    {
                        ApWin.OnlineClientForm.statusStrip1.Items[0].Text = "You can not enter in this room";
                    }

                    SocketClient.GetDataByRoomID(isFromTimer, Ap.SelectedRoomID, 0);
                }
            }
            else
            {
                SocketClient.GetDataByRoomID(isFromTimer, Ap.SelectedRoomID, Ap.CurrentUserID);
            }
        }

        #region SetRoomUsersCount
        public void SetRoomUsersCount(DataSet ds)
        {
            treeView1.ExpandAll();

            if (ds.Tables["Table7"] != null)
            {
                DataTable dt = SearchTreeViewNode(ds.Tables["Table7"]);

                if (dt.Rows.Count > 0)
                {
                    AddTreeViewNode(dt);
                }
            }
            foreach (TreeNode node in treeView1.Nodes)
            {
                DataTable dtUserCount = ds.Tables["RoomUsersCount"];

                SetChildRoomUsersCount(node, ds);

                //AddTournamentNode();

                DataView dv = new DataView(dtUserCount);
                dv.RowFilter = "RoomID=" + node.Tag.ToString();
                if (dv.Count > 0)
                {
                    parentRoomUserCount = parentRoomUserCount + Convert.ToInt32(dv.ToTable().Rows[0]["UsersCount"]);
                }

                int index = node.Text.IndexOf('(');
                if (index > 0)
                {
                    node.Text = node.Text.Remove(index);
                }
                if (parentRoomUserCount > 0)
                    node.Text = node.Text + "(" + parentRoomUserCount + ")";

                parentRoomUserCount = 0;
            }
        }
        #endregion

        #region SetChildRoomUsersCount
        private void SetChildRoomUsersCount(TreeNode ParentNode, DataSet ds)
        {
            foreach (TreeNode node in ParentNode.Nodes)
            {
                RemoveTournamentNode(ds, node);

                DataTable dtUserCount = ds.Tables["RoomUsersCount"];

                DataView dv = new DataView(dtUserCount);
                dv.RowFilter = "RoomID=" + node.Tag.ToString();

                int index = node.Text.IndexOf('(');
                if (index > 0)
                {
                    node.Text = node.Text.Remove(index);
                }
                if (dv.Count > 0)
                {
                    node.Text = node.Text + "(" + dv.ToTable().Rows[0]["UsersCount"] + ")";
                    parentRoomUserCount = parentRoomUserCount + Convert.ToInt32(dv.ToTable().Rows[0]["UsersCount"]);
                }

                SetChildRoomUsersCount(node, ds);
            }

        }
        #endregion

        #region Add Remove Nodes

        #region AddTreeViewNode
        void AddTreeViewNode(DataTable dtRoom)
        {
            TreeNodeCollection node = treeView1.Nodes;

            for (int i = 0; i < dtRoom.Rows.Count; i++)
            {
                DataRow dr = dtRoom.Rows[i];
                foreach (TreeNode n in node)
                {
                    AddRecursive(n, ref dr);
                }
            }
        }

        void AddRecursive(TreeNode tn, ref DataRow dr)
        {

            foreach (TreeNode n in tn.Nodes)
            {
                if (n.Tag.ToString() == "7")
                {
                    if (dr["ParentID"].ToString() == "7")
                    {
                        if (dr != null)
                        {
                            AddRoom(dr, n);
                            dr = null;
                        }
                    }
                }
                else if (n.Tag.ToString() == "12")
                {
                    if (dr != null)
                    {
                        if (dr["ParentID"].ToString() == "12")
                        {
                            if (dr != null)
                            {
                                AddRoom(dr, n);
                                dr = null;
                            }
                        }
                    }
                }
                AddRecursive(n, ref dr);

            }
        }
        #endregion

        #region Add Node
        private static void AddRoom(DataRow dr, TreeNode n)
        {
            Room r = new Room(Ap.Cxt, dr);
            TreeNode tn1 = new TreeNode();
            tn1.ImageIndex = 1;
            tn1.Text = r.Name;
            tn1.Tag = r.RoomID.ToString();
            tn1.SelectedImageIndex = 1;
            n.Nodes.Add(tn1);
        }
        #endregion

        #region SearchTreeViewNode
        DataTable SearchTreeViewNode(DataTable dtRoom)
        {
            TreeNodeCollection node = treeView1.Nodes;
            strVal = "";
            foreach (DataRow row in dtRoom.Rows)
            {

                foreach (TreeNode n in node)
                {
                    FindRecursive(n, row);
                }
            }
            if (strVal.Length > 0)
            {
                strVal = strVal.Remove(0, 1);
                dtRoom.DefaultView.RowFilter = "RoomID NOT IN (" + strVal + ")";
            }

            return dtRoom.DefaultView.ToTable();
        }

        void FindRecursive(TreeNode tn, DataRow dr)
        {

            foreach (TreeNode n in tn.Nodes)
            {
                if (n.Parent.Tag.ToString() == "7" || n.Parent.Tag.ToString() == "12")
                {

                    if (dr["RoomID"].ToString() == n.Tag.ToString())
                    {
                        strVal += "," + n.Tag.ToString();
                    }
                }
                FindRecursive(n, dr);
            }
        }
        #endregion

        #region RemoveTournamentNode
        private void RemoveTournamentNode(DataSet ds, TreeNode node)
        {
            if (ds == null)
            {
                return;
            }

            if (ds.Tables["Table7"] == null)
            {
                RemoveLastNode(node);
                return;
            }

            if (ds.Tables["Table7"].Rows.Count == 0)
            {
                RemoveLastNode(node);
                return;
            }

            DataView dv = ds.Tables["Table7"].DefaultView;

            dv.RowFilter = "RoomID=" + node.Tag.ToString();

            RemoveCurrentNode(node, dv);
        }

        private static void RemoveLastNode(TreeNode node)
        {
            TreeNode tn = node.Parent;
            if (tn != null)
            {
                if (tn.Tag.ToString() == "7" || tn.Tag.ToString() == "12")
                {
                    node.Remove();
                }
            }
        }

        private static void RemoveCurrentNode(TreeNode node, DataView dv)
        {
            TreeNode tn = node.Parent;

            if (tn != null)
            {
                if (tn.Tag.ToString() == "7" || tn.Tag.ToString() == "12")
                {
                    if (dv.ToTable().Rows.Count == 0)
                    {
                        node.Remove();
                    }
                }
            }
        }
        #endregion

        #endregion

        #endregion

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #endregion
    }
}
