using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using App.Model.Db;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using InfinityChess.InfinityChesshelp;

namespace App.Win
{
    public partial class UserData : BaseWinForm
    {
        #region Data Members
        private byte[] UserImage = null;
        private string ImageType = string.Empty;
        private UserDataKv kv = null;
        public int UserID = 0;
        private User user = null;
        public bool ShowConfirmDialog = true;
        #endregion

        #region Properties
        public bool IsNew
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return UserID == 0; }
        }

        public User User
        {
            //[System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (user == null)
                {
                    ProgressForm frm = ProgressForm.Show(this, "Loading User...");

                    DataTable table = SocketClient.GetUserById(UserID).Tables[0];

                    frm.Close();

                    if (table.Rows.Count > 0)
                    {
                        user = new User(Ap.Cxt, table.Rows[0]);
                    }
                }

                return user;
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                user = value;
            }
        }

        public UserDataKv Kv
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (kv == null)
                {
                    kv = UserDataKv.Instance;
                }

                return kv;
            }
        }
        #endregion

        #region Constructor
        public UserData()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            LoadUi();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                Regex reg = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                Match mt = reg.Match(txtEmail.Text);
                if (!mt.Success)
                {
                    MessageForm.Error(this, MsgE.ErrorInvalidEmail);
                    return;
                }
            }
            if (!String.IsNullOrEmpty(txtURL.Text))
            {
                Regex reg = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
                Match mt = reg.Match(txtURL.Text);
                if (!mt.Success)
                {
                    MessageForm.Error(this, MsgE.ErrorInvalidURL);
                    return;
                }
            }

            if (IsNew)
            {
                if (ShowConfirmDialog)
                {
                    if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "save", "user") == DialogResult.Yes)
                    {
                        Save();
                    }
                }
                else
                {
                    Save();
                }
            }
            else
            {
                if (ShowConfirmDialog)
                {
                    if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "update", "user") == DialogResult.Yes)
                    {
                        Update();
                    }
                }
                else
                {
                    Update();
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "BMP Images (*.bmp)|*.bmp";
            dlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            dlg.InitialDirectory = Ap.FolderImages;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(dlg.FileName);
                long s1 = f.Length;
                if (s1 <= 204800)
                //if (s1 <= 4194304)
                {
                    Image uImage = Image.FromFile(dlg.FileName);
                    ImageType = System.IO.Path.GetExtension(dlg.FileName);
                    UserImage = UImage.GetImageBytes(dlg.FileName);
                    MemoryStream memoryStream = new MemoryStream(ResizeImageFile(UserImage, pbUser.Height));
                    Bitmap img = new Bitmap(memoryStream);
                    pbUser.Image = img;
                    memoryStream.Close();
                }
                else
                {
                    //MessageForm.Error("Image size not more than 4Mb");
                    MessageForm.Error(this, MsgE.ErrorImageRange);
                }
            }
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCountry.SelectedIndex != 0)
            {
                try
                {
                    pbFlag.Image = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + cbCountry.SelectedValue + ".PNG");
                }
                catch (Exception ex)
                {
                    TestDebugger.Instance.WriteError(ex);
                    pbFlag.Image = null;
                }
            }
            else
            {
                pbFlag.Image = null;
            }
        }

        private void chkFIDE_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFIDE.Checked)
            {
                rbFM.Enabled = true;
                rbIM.Enabled = true;
                rbGM.Enabled = true;
                rbFM.Checked = true;
            }
            else
            {
                rbFM.Enabled = false;
                rbIM.Enabled = false;
                rbGM.Enabled = false;
            }
        }

        private void chkICCF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkICCF.Checked)
            {
                rbIccfIM.Enabled = true;
                rbIccfSIM.Enabled = true;
                rbIccfGM.Enabled = true;
                rbIccfIM.Checked = true;
            }
            else
            {
                rbIccfIM.Enabled = false;
                rbIccfSIM.Enabled = false;
                rbIccfGM.Enabled = false;
            }
        }
        #endregion

        #region Helper

        private void LoadUi()
        {
            Kv kv = new Kv(KvType.NearestCity);
            cbNearestCity.DataSource = kv.DataTable;
            cbNearestCity.DisplayMember = "v";
            cbNearestCity.ValueMember = "k";

            kv = new Kv(KvType.CountryLong);
            cbCountry.DataSource = kv.DataTable;
            cbCountry.DisplayMember = "v";
            cbCountry.ValueMember = "k";

            if (IsNew)
            {
                this.Text = "New User";
                txtLoginId.Focus();
                dtpDateOfBirth.MaxDate = DateTime.Now;
                dtpDateOfBirth.Value = DateTime.Now.AddMinutes(-1);
                cbNearestCity.SelectedIndex = 0;
                cbCountry.SelectedIndex = 0;
                chkFIDE.Checked = false;
                rbFM.Enabled = false;
                rbIM.Enabled = false;
                rbGM.Enabled = false;
                chkICCF.Checked = false;
                rbIccfIM.Enabled = false;
                rbIccfSIM.Enabled = false;
                rbIccfGM.Enabled = false;
            }
            else
            {
                LoadUserData();
                this.Text = txtLoginId.Text;
                txtLoginId.Enabled = false;
                txtFirstName.Focus();
            }
        }

        private void LoadUserData()
        {
            if (this.User == null)
            {
                return;
            }

            txtLoginId.Text = this.User.UserName;
            txtEmail.Text = this.User.Email;
            txtFirstName.Text = this.User.FirstName;
            txtLastName.Text = this.User.LastName;
            cbNearestCity.SelectedValue = this.User.NearestCityID;
            cbCountry.SelectedValue = this.User.CountryID;

            if (this.User.GenderID == (int)GenderE.Mr)
            {
                rbMr.Checked = true;
            }
            else if (this.User.GenderID == (int)GenderE.Mrs)
            {
                rbMrs.Checked = true;
            }
            else
            {
                rbComp.Checked = true;
            }

            if (this.User.FideTitleID == (int)FideTitleE.FM)
            {
                chkFIDE.Checked = true;
                rbFM.Checked = true;
            }
            else if (this.User.FideTitleID == (int)FideTitleE.IM)
            {
                chkFIDE.Checked = true;
                rbIM.Checked = true;
            }
            else if (this.User.FideTitleID == (int)FideTitleE.GM)
            {
                chkFIDE.Checked = true;
                rbGM.Checked = true;
            }
            else
            {
                chkFIDE.Checked = false;
                rbFM.Enabled = false;
                rbIM.Enabled = false;
                rbGM.Enabled = false;
            }

            if (this.User.IccfTitleID == (int)IccfTitleE.SIM)
            {
                chkICCF.Checked = true;
                rbIccfSIM.Checked = true;
            }
            else if (this.User.IccfTitleID == (int)IccfTitleE.IM)
            {
                chkICCF.Checked = true;
                rbIccfIM.Checked = true;
            }
            else if (this.User.IccfTitleID == (int)IccfTitleE.GM)
            {
                chkICCF.Checked = true;
                rbIccfGM.Checked = true;
            }
            else
            {
                chkICCF.Checked = false;
                rbIccfIM.Enabled = false;
                rbIccfSIM.Enabled = false;
                rbIccfGM.Enabled = false;
            }

            txtNotes.Text = this.User.PersonalNotes;
            txtURL.Text = this.User.Url;
            dtpDateOfBirth.MaxDate = DateTime.Now;
            if (this.User.DateOfBirth.Date != new DateTime())
                dtpDateOfBirth.Value = this.User.DateOfBirth.Date;


            DataSet ds = SocketClient.GetUserPicture();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["UserImage"].ToString()))
                    {
                        ShowUserImage(dt.Rows[0]["UserImage"].ToString());
                    }
                }
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
            DataColumn typeColumn;
            typeColumn = new DataColumn();
            typeColumn.DataType = System.Type.GetType("System.String");
            typeColumn.ColumnName = "ImageType";
            userImageTable.Columns.Add(typeColumn);

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            MemoryStream ms = new MemoryStream(encoding.GetBytes(UserImageString));
            userImageTable.ReadXml(ms);
            ms.Close();

            //Image img = Image.FromStream(ms);
            if (userImageTable != null && userImageTable.Rows.Count > 0)
            {
                UserImage = (byte[])userImageTable.Rows[0]["ImageBytes"];
                ImageType = userImageTable.Rows[0]["ImageType"].ToString();
                MemoryStream memoryStream = new MemoryStream(ResizeImageFile(UserImage, pbUser.Height));
                Bitmap img = new Bitmap(memoryStream);
                pbUser.Image = img;
                memoryStream.Close();
            }
        }

        private void Save()
        {
            if (!String.IsNullOrEmpty(txtLoginId.Text))
            {
                if (txtLoginId.Text.Length < 3)
                {
                    MessageForm.Error(this, MsgE.ErrorLoginIdRange);
                    return;
                }
                else if (txtLoginId.Text.Contains(" "))
                {
                    MessageForm.Error(this, MsgE.ErrorSpacing);
                    return;
                }
                else
                {
                    //Regex reg = new Regex(@"^(([a-zA-Z])(\.)?([a-zA-Z0-9_]?)(\.)?)+$");
                    Regex reg = new Regex(@"^[a-zA-Z]+[a-zA-Z0-9_\.]+$");
                    Match mt = reg.Match(txtLoginId.Text);
                    if (!mt.Success)
                    {
                        MessageForm.Show(this, MsgE.InfoLoginRule);
                        return;
                    }

                    DataSet ds = SocketClient.CheckUserId(txtLoginId.Text);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        Kv kv1 = new Kv();
                        kv1 = new Kv(ds.Tables[0]);
                        bool isExist = kv1.GetBool("IsExist");
                        if (isExist)
                        {
                            MessageForm.Error(this, MsgE.ErrorUserExsist);
                            return;
                        }
                    }
                    else
                    {
                        MessageForm.Error(this, MsgE.ErrorServerConnection);
                        return;
                    }
                }
            }
            else
            {
                MessageForm.Error(this, MsgE.ErrorEnterUser);
                return;
            }

            Kv.UserName = txtLoginId.Text;
            Kv.Email = txtEmail.Text;
            Kv.FirstName = txtFirstName.Text;
            Kv.LastName = txtLastName.Text;
            Kv.NearestCityID = Convert.ToInt32(cbNearestCity.SelectedValue);

            if (cbCountry.SelectedIndex != 0)
                Kv.CountryID = Convert.ToInt32(cbCountry.SelectedValue);

            if (rbMr.Checked)
                Kv.GenderIDE = GenderE.Mr;
            else if (rbMrs.Checked)
                Kv.GenderIDE = GenderE.Mrs;
            else
                Kv.GenderIDE = GenderE.Comp;

            if (chkFIDE.Checked)
            {
                if (rbFM.Checked)
                    Kv.FideTitleIDE = FideTitleE.FM;
                else if (rbIM.Checked)
                    Kv.FideTitleIDE = FideTitleE.IM;
                else
                    Kv.FideTitleIDE = FideTitleE.GM;
            }
            else
            {
                Kv.FideTitleIDE = FideTitleE.None;
            }

            if (chkICCF.Checked)
            {
                if (rbIccfIM.Checked)
                    Kv.IccfTitleIDE = IccfTitleE.IM;
                else if (rbIccfSIM.Checked)
                    Kv.IccfTitleIDE = IccfTitleE.SIM;
                else
                    Kv.IccfTitleIDE = IccfTitleE.GM;
            }
            else
                Kv.IccfTitleIDE = IccfTitleE.None;

            Kv.PersonalNotes = txtNotes.Text;
            Kv.DateOfBirth = dtpDateOfBirth.Value.ToString("MM/dd/yyyy");
            //Kv.DateOfBirth = UData.GetChessDate(dtpDateOfBirth.Value.ToString("", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));
            Kv.DateLastLogin = DateTime.Now.ToString("MM/dd/yyyy");
            Kv.Url = txtURL.Text;

            if (UserImage != null)
            {
                GeUserImageBytes();
            }
            if (IsNew)
            {
                this.Visible = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
                ChangePassword frm = new ChangePassword();
                frm.ShowDialog();
            }
            else
            {
                //Call Update User Method
            }
        }

        private new void Update()
        {
            Kv.Email = txtEmail.Text;
            Kv.FirstName = txtFirstName.Text;
            Kv.LastName = txtLastName.Text;
            Kv.NearestCityID = Convert.ToInt32(cbNearestCity.SelectedValue);

            if (cbCountry.SelectedIndex != 0)
                Kv.CountryID = Convert.ToInt32(cbCountry.SelectedValue);

            if (rbMr.Checked)
                Kv.GenderIDE = GenderE.Mr;
            else if (rbMrs.Checked)
                Kv.GenderIDE = GenderE.Mrs;
            else
                Kv.GenderIDE = GenderE.Comp;

            if (chkFIDE.Checked)
            {
                if (rbFM.Checked)
                    Kv.FideTitleIDE = FideTitleE.FM;
                else if (rbIM.Checked)
                    Kv.FideTitleIDE = FideTitleE.IM;
                else
                    Kv.FideTitleIDE = FideTitleE.GM;
            }
            else
                Kv.FideTitleIDE = FideTitleE.None;

            if (chkICCF.Checked)
            {
                if (rbIccfIM.Checked)
                    Kv.IccfTitleIDE = IccfTitleE.IM;
                else if (rbIccfSIM.Checked)
                    Kv.IccfTitleIDE = IccfTitleE.SIM;
                else if (rbIccfGM.Checked)
                    Kv.IccfTitleIDE = IccfTitleE.GM;
            }
            else
                Kv.IccfTitleIDE = IccfTitleE.None;

            Kv.PersonalNotes = txtNotes.Text;
            Kv.DateOfBirth = dtpDateOfBirth.Value.ToString("MM/dd/yyyy");

            //Kv.DateLastLogin = DateTime.Now;
            Kv.Url = txtURL.Text;
            if (UserImage != null)
            {
                GeUserImageBytes();
            }

            DataSet ds = SocketClient.UpdateUser(Kv);
            if (ds != null && ds.Tables.Count > 0)
            {
                Kv kv1 = new Kv(ds.Tables[0]);
                Srv.SetCurrentUser(kv1);
                MessageForm.Show(this, MsgE.InfoUserUpdate);

            }

            string userTitle = " - InfinityChess Online";
            if (this.User.HumanRankIDE != RankE.Guest)
            {
                userTitle = "[" + this.User.UserName + "] - " + this.User.FirstName + "," + this.User.LastName + userTitle;
            }
            else
            {
                userTitle = "[" + this.User.UserName + "] - " + "Guest" + userTitle;
            }
            ApWin.OnlineClientForm.Text = userTitle;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void GeUserImageBytes()
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
            DataRow dr = userImageTable.NewRow();
            dr["ImageName"] = "UserImage";
            dr["ImageBytes"] = UserImage;
            userImageTable.Rows.Add(dr);

            Kv.UserImageType = ImageType;
            Kv.UserImage = UData.ToString(userImageTable);
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
        #endregion

        public override string HelpTopicId
        {
            get { return "220"; }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.UserData);
        }

        public static DialogResult Show(Form owner, int userID)
        {
            return Show(owner, userID, null);
        }

        public static DialogResult Show(Form owner, int userID, User user)
        {
            return Show(owner, userID, user, true);
        }

        public static DialogResult Show(Form owner, int userID, User user, bool showConfirm)
        {
            UserData frm = new UserData();
            frm.UserID = userID;
            frm.User = user;
            frm.ShowConfirmDialog = showConfirm;

            DialogResult result = frm.ShowDialog(owner);

            return result;
        }
    }
}