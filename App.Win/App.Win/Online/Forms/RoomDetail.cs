using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;
namespace App.Win
{
    public partial class RoomDetail : Form
    {

        public RoomDetail()
        {
            InitializeComponent();
        }
       
        private void RoomDetail_Load(object sender, EventArgs e)
        {
            
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (roomDetailUc1.RoomName == string.Empty)
            {
                MessageForm.Show(this, MsgE.ErrorEmptyRoomTitle);
            }
            else
            {
                if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "save", "room") == DialogResult.Yes)
                {
                    roomDetailUc1.SaveRoom();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.RoomDetail);
        }
        public static DialogResult Show(Form owner, int NewsID)
        {
            return Show(owner, NewsID, null);
        }

        public static DialogResult Show(Form owner, int roomID, Room room)
        {
            RoomDetail frm = new RoomDetail();
            frm.roomDetailUc1.RoomID = roomID;
            frm.roomDetailUc1.Room = room;
            DialogResult result = frm.ShowDialog(owner);

            return result;
        }

       
       
       
    }
}
