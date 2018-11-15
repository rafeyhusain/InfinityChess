using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;
namespace App.Win
{
    public partial class RoomDetailUc : UserControl
    {
        public int RoomID = 0;
        private Room room = null;
        public RoomDetailUc()
        {
            InitializeComponent();
        }
        public string RoomName
        {
            set { txtName.Text = value; }
            get { return txtName.Text; }
        }
        public Room Room
        {
            //[System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (room == null)
                {
                    ProgressForm frm = ProgressForm.Show(this, "Loading Room...");

                    room = SocketClient.GetRoomByID(RoomID);

                    frm.Close();

                    //if (table.Rows.Count > 0)
                    //{
                    //    Room = new Room(Ap.Cxt, table.Rows[0]);
                    //}
                }

                return room;
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                room = value;
            }
        }
        private void RoomDetailUc_Load(object sender, EventArgs e)
        {
            FillParentRoomCombo();

            LoadRoom();
        }

        private void LoadRoom()
        {
            if (Room == null)
            {
                return;
            }

            txtName.Text = this.Room.Name;
            editor1.HtmlText = this.Room.Html;
            chkCanMoveBack.Checked = this.Room.CanTakeBackMove;
            chkIsUrlBit.Checked = this.Room.IsUrlBit;
            chkIsGuestAllow.Checked = this.Room.IsGuestAllow;

            if (this.Room.RoomID == 0)
            {
                this.ParentForm.Text = "New Room";
            }

            if (this.Room.ParentID > 0)
            {
                cmbParentRoom.SelectedValue = this.Room.ParentID;
            }
            else
            {
                cmbParentRoom.SelectedIndex = 0;
            }
        }

        public void FillParentRoomCombo()
        {
            try
            {
                DataSet ds = SocketClient.GetAllRoomsWithNullTournament();

                if (ds != null)
                {
                    cmbParentRoom.DataSource = ds.Tables[0];
                    cmbParentRoom.DisplayMember = "ParentAndChild";
                    cmbParentRoom.ValueMember = "RoomID";
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }
        public void SaveRoom()
        {
            try
            {
                int parentID = 0;

                parentID = Convert.ToInt32(cmbParentRoom.SelectedValue);

                SocketClient.SaveRoom(RoomID, parentID,
                    txtName.Text,
                    editor1.HtmlText,
                    chkCanMoveBack.Checked,
                    chkIsUrlBit.Checked,
                    chkIsGuestAllow.Checked);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
