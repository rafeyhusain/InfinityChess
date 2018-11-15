using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Win;
using App.Model.Db;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using InfinityChess.WinForms;

namespace App.Win
{
    public partial class PersonalInformation : Form
    {
        private int userID;
        private string userName;
        private byte[] UserImage = null;

        public int UserID
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return userID; }
            [System.Diagnostics.DebuggerStepThrough]
            set { userID = value; }
        }
        bool isRated = false;        
        public string UserName
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return userName; }
            [System.Diagnostics.DebuggerStepThrough]
            set { userName = value; }
        }

        public PersonalInformation()
        {
            InitializeComponent();
        }

        public PersonalInformation(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void PersonalInformation_Load(object sender, EventArgs e)
        {
            txtUser.Text = userName;
            GetUser(txtUser.Text);
            this.Text = "'" + txtUser.Text + "'" + " - Personal Information";
        }

        void GetUser(string userName)
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading User Information...");

            DataSet ds = null;
            if (userName == "" && userID != 0)
            {
                ds = SocketClient.GetUserInfoByUserID(userID);
            }
            else if (userName != "")
            {
                ds = SocketClient.UserByName(userName);
            }
            Init(ds);

            frmProgress.Close();
        }

        private void Init(DataSet ds)
        {
            
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    isRated = true;
                    userID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    userName = dt.Rows[0]["UserName"].ToString();
                    lblFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                    lblLastName.Text = dt.Rows[0]["LastName"].ToString();
                    lblMemberSince.Text = Convert.ToDateTime(dt.Rows[0]["DateCreated"]).ToShortDateString();
                    pictureBoxRank.Image = Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\" + dt.Rows[0]["Rank"].ToString() + ".PNG");
                    txtPersonalNotes.Text = dt.Rows[0]["PersonalNotes"].ToString();
                    pictureBoxCountry.Image = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + dt.Rows[0]["CountryID"].ToString() + ".PNG");
                    lblCountry.Text = dt.Rows[0]["Country"].ToString();
                    lblNearestCity.Text = dt.Rows[0]["NearestCity"].ToString();
                    lblFideTitle.Text = dt.Rows[0]["FIDETitle"].ToString();
                    lblIccfTitle.Text = dt.Rows[0]["ICCFTitle"].ToString();

                    if (!string.IsNullOrEmpty(dt.Rows[0]["UserImage"].ToString()))
                    {
                        ShowUserImage(dt.Rows[0]["UserImage"].ToString());
                    }
                    else
                    {
                        pictureBoxUser.Image = null;
                    }
                    txtUser.Text = userName;
                }
                else
                { isRated = false; }
            }
            else
            { isRated = false; }
        }
        

        private void btnRating_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            //this.Close();
            if (!Ap.CurrentUser.IsGuest)
            {
                RatedGameResult frm2 = new RatedGameResult();
                frm2.UserID = Convert.ToInt32(this.userID);
                frm2.UserName = txtUser.Text;
                frm2.ShowDialog();
            }            
        }

        private void ShowUserImage(string UserImageString)
        {
            DataTable userImageTable = new DataTable("UserImageTable");
            DataColumn nameColumn;
            nameColumn = new DataColumn();
            nameColumn.DataType = System.Type.GetType("System.String");
            nameColumn.ColumnName = "ImageName";
            userImageTable.Columns.Add(nameColumn);
            DataColumn imageColumn;
            imageColumn = new DataColumn();
            imageColumn.DataType = System.Type.GetType("System.Byte[]");
            imageColumn.ColumnName = "ImageBytes";
            userImageTable.Columns.Add(imageColumn);

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            MemoryStream ms = new MemoryStream(encoding.GetBytes(UserImageString));
            userImageTable.ReadXml(ms);

            //Image img = Image.FromStream(ms);
            if (userImageTable != null && userImageTable.Rows.Count > 0)
            {
                UserImage = (byte[])userImageTable.Rows[0]["ImageBytes"];
                MemoryStream memoryStream = new MemoryStream(ResizeImageFile(UserImage, pictureBoxUser.Height));
                Bitmap img = new Bitmap(memoryStream);
                memoryStream.Close();
                pictureBoxUser.Image = img;
            }
            ms.Close();
        }

        private byte[] ResizeImageFile(byte[] imageFile, int targetSize)
        {
            Image original = Image.FromStream(new MemoryStream(imageFile));
            int targetH, targetW;
            if (original.Height > original.Width)
            {
                targetH = targetSize;
                targetW = (int)(original.Width * ((float)targetSize / (float)original.Height));
            }
            else
            {
                targetW = targetSize;
                targetH = (int)(original.Height * ((float)targetSize / (float)original.Width));
            }
            Image imgPhoto = Image.FromStream(new MemoryStream(imageFile));
            // Create a new blank canvas.  The resized image will be drawn on this canvas.
            Bitmap bmPhoto = new Bitmap(targetW, targetH, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(72, 72);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, targetW, targetH), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel);
            // Save out to memory and then to a file.  We dispose of all objects to make sure the files don't stay locked.
            MemoryStream ms = new MemoryStream();
            bmPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            original.Dispose();
            imgPhoto.Dispose();
            bmPhoto.Dispose();
            grPhoto.Dispose();

            byte[] buffer = ms.GetBuffer();
            ms.Close();

            return buffer;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pictureBoxCountry_Click(object sender, EventArgs e)
        {

        }
        ProgressForm frmProgress;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            frmProgress = ProgressForm.Show(this,"Searching...");
            GetUser(txtUser.Text);
            this.Text = "'" + txtUser.Text + "'" + " - Personal Information";
            if (!isRated)
            {
                MessageForm.Show(this,MsgE.InfoProfile, txtUser.Text);
            }
            
            frmProgress.Close();
        }

    }
}
