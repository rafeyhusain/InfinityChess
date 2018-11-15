using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;

namespace App.Win
{
    public partial class RoomUc : UserControl
    {
        public delegate void PlayerDataGridHandler(DataTable table);
        public static event PlayerDataGridHandler LoadPlayerGrid;

        public static int selectedRoomId;
        public RoomUc()
        {
            InitializeComponent();
        }

        private void RoomUc_Load(object sender, EventArgs e)
        {
            DataTable dt = Srv.Instance.GetAllRooms();
            PopulateNodes(dt, treeView1.Nodes);
        }

        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (String.IsNullOrEmpty(Convert.ToString(dr["ParentId"])))
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = dr["Name"].ToString() + " (" + dr["UserCount"] + ")";
                    tn.Tag = dr["RoomId"].ToString();
                    nodes.Add(tn);
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
                    tn.Text = dr["Name"].ToString() + " (" + dr["UserCount"] + ")";
                    tn.Tag = dr["RoomId"].ToString();
                    nodes.Nodes.Add(tn);

                    PopulateChildNodes(dt, tn);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedRoomId = Convert.ToInt32(e.Node.Tag);
            DataTable dt = Srv.Instance.GetAllUsers(selectedRoomId);
            if (LoadPlayerGrid != null)
            {
                LoadPlayerGrid(dt);
            }
        }
    }
}
