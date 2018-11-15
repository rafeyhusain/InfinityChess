using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InfinitySettings;
using System.IO;

namespace App.Win
{
    public partial class BoardDesignPopup : Form
    {
        #region Delegates/Events
        public event EventHandler ApplyDesign;
        #endregion

        #region DataMembers 

        const string UserBmp = "User BMP...";
        string userImageFile;

        #endregion

        #region Ctor
        public BoardDesignPopup()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties 

        private bool IsUserBmp
        {
            get { return cmbBackground.Text == UserBmp; }
        }

        #endregion

        #region Form Load

        private void BoardDesign_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadControls();
        }

        #endregion

        #region Helper Methods 

        private void LoadComboBoxes()
        {
            cmbColorSchemes.DataSource = Ap.BoardTheme.KvColors.DataTable;
            cmbColorSchemes.DisplayMember = "k";
            cmbColorSchemes.ValueMember = "k";

            cmbPieces.DataSource = Ap.BoardTheme.KvPieces.DataTable;
            cmbPieces.DisplayMember = "k";
            cmbPieces.ValueMember = "k";

            cmbBackground.DataSource = Ap.BoardTheme.KvBackground.DataTable;
            cmbBackground.DisplayMember = "k";
            cmbBackground.ValueMember = "v";            
        }

        private void LoadControls()
        {
            LoadColors();

            cmbColorSchemes.SelectedValue = Ap.BoardTheme.BoardColorScheme;
            cmbPieces.SelectedValue = Ap.BoardTheme.BoardPieces;

            cmbBackground.SelectedValue = Ap.BoardTheme.BoardBackgroundImage;
            chkCoordinates.Checked = Ap.BoardTheme.BoardCoordinatesVisible;
        }

        private void LoadColors()
        {
            string spaces = "     ";

            lblWhiteColor.Text = spaces;
            lblBlackColor.Text = spaces;
            lblLightSquaresColor.Text = spaces;
            lblDarkSquaresColor.Text = spaces;
            lblBackgroundColor.Text = spaces;

            lblWhiteColor.BackColor = ColorTranslator.FromHtml(Ap.BoardTheme.WhitePiecesColor);
            lblBlackColor.BackColor = ColorTranslator.FromHtml(Ap.BoardTheme.BlackPiecesColor);

            if (Ap.BoardTheme.IsSquareImage)
            {
                lblLightSquaresColor.Visible = false;
                lblDarkSquaresColor.Visible = false;
                pbLightSquares.Visible = true;
                pbDarkSquares.Visible = true;

                if (File.Exists(Ap.BoardTheme.LightSquaresImagePath))
                {
                    pbLightSquares.Image = Image.FromFile(Ap.BoardTheme.LightSquaresImagePath);
                }
                if (File.Exists(Ap.BoardTheme.DarkSquaresImagePath))
                {
                    pbDarkSquares.Image = Image.FromFile(Ap.BoardTheme.DarkSquaresImagePath);
                }
                pbLightSquares.Location = lblLightSquaresColor.Location;
                pbDarkSquares.Location = lblDarkSquaresColor.Location;
            }
            else
            {
                lblLightSquaresColor.Visible = true;
                lblDarkSquaresColor.Visible = true;
                pbLightSquares.Visible = false;
                pbDarkSquares.Visible = false;

                lblLightSquaresColor.BackColor = ColorTranslator.FromHtml(Ap.BoardTheme.LightSquaresColor);
                lblDarkSquaresColor.BackColor = ColorTranslator.FromHtml(Ap.BoardTheme.DarkSquaresColor);
            }

            if (Ap.BoardTheme.IsBoardBackgroundImage)
            {
                pbBackground.Visible = true;
                lblBackgroundColor.Visible = false;
                if (File.Exists(Ap.BoardTheme.BoardBackgroundImagePath))
                {
                    cmbBackground.SelectedValue = Ap.BoardTheme.BoardBackgroundImage;
                    pbBackground.Image = Image.FromFile(Ap.BoardTheme.BoardBackgroundImagePath);
                }
                pbBackground.Location = lblBackgroundColor.Location;
            }
            else
            {
                pbBackground.Visible = false;
                lblBackgroundColor.Visible = true;
                lblBackgroundColor.BackColor = ColorTranslator.FromHtml(Ap.BoardTheme.BoardBackgroundColor);
            }
        }

        private void SaveDesign()
        {
            SaveBackgroundFile();
            Ap.BoardTheme.BoardColorScheme = cmbColorSchemes.SelectedValue.ToString();
            Ap.BoardTheme.BoardPieces = (PieceThemeE)Enum.Parse(typeof(PieceThemeE), cmbPieces.SelectedValue.ToString());
            //Ap.BoardTheme.BoardBackgroundImage = cmbBackground.SelectedValue.ToString();
            Ap.BoardTheme.BoardCoordinatesVisible = chkCoordinates.Checked;
            Ap.Options.Save();
            Ap.BoardTheme.Save();

            Ap.BoardTheme.LightImageBrush = null;
            Ap.BoardTheme.DarkImageBrush = null;

            OnApplyDesign();
        }

        private void SaveBackgroundFile()
        {
            if (IsUserBmp && File.Exists(userImageFile))
            {
                string fileName = Path.GetFileName(userImageFile);

                string destinationFilePath = Ap.FolderImagesBackground + fileName;

                if (!File.Exists(destinationFilePath))
                {
                    File.Copy(userImageFile, destinationFilePath);
                }

                Ap.BoardTheme.KvBackground.Set(UserBmp, fileName);
                Ap.BoardTheme.KvBackground.WriteXml(Kv.GetFilePath(KvType.BackgroundThemes));
            }
        }

        private void OnApplyDesign()
        {
            if (ApplyDesign != null)
            {
                ApplyDesign(this, EventArgs.Empty);
            }
        }

        private void SetCustomTheme()
        {
            string lightSquaresColor = Ap.BoardTheme.LightSquaresColor;
            string darkSquaresColor = Ap.BoardTheme.DarkSquaresColor;

            Ap.BoardTheme.BoardColorScheme = "Custom";
            Ap.BoardTheme.LightSquaresColor = lightSquaresColor;
            Ap.BoardTheme.DarkSquaresColor = darkSquaresColor;

            cmbColorSchemes.SelectedValue = Ap.BoardTheme.BoardColorScheme;            
        }

        #endregion

        #region Events 
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Pictures(*jpg)|*.jpg";
            openFileDialog1.FileName = "*.jpg";
            openFileDialog1.InitialDirectory = "C:\\";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                userImageFile = openFileDialog1.FileName;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveDesign();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveDesign();            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            InfinityChess.InfinityChesshelp.InfinityChessHelp.OpenHelpFile();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBrowse.Enabled = IsUserBmp;
        }

        #endregion     
     
        #region Pick Color/Image Events 

        private void lblWhiteColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                SetCustomTheme();
                Ap.BoardTheme.WhitePiecesColor = ColorTranslator.ToHtml(colorDialog1.Color);
                lblWhiteColor.BackColor = ColorTranslator.FromHtml(Ap.BoardTheme.WhitePiecesColor);
            }
        }

        private void lblBlackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                SetCustomTheme();
                Ap.BoardTheme.BlackPiecesColor = ColorTranslator.ToHtml(colorDialog1.Color);
                lblBlackColor.BackColor = ColorTranslator.FromHtml(Ap.BoardTheme.BlackPiecesColor);
            }
        }

        private void lblLightSquaresColor_Click(object sender, EventArgs e)
        {
            PickImagePopup frm = new PickImagePopup(ImageTarget.LightSquare, FillType.Color,  Ap.BoardTheme.LightSquaresColor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SetCustomTheme();
                switch (frm.FillType)
                {
                    case FillType.Color:
                        Ap.BoardTheme.LightSquaresColor = frm.SelectedColor;
                        Ap.BoardTheme.IsSquareImage = false;
                        LoadColors();
                        break;
                    case FillType.Image:
                        Ap.BoardTheme.LightSquaresImage = frm.SelectedImage;
                        Ap.BoardTheme.IsSquareImage = true;
                        LoadColors();
                        break;
                    default:
                        break;
                }                
            }
        }

        private void lblDarkSquaresColor_Click(object sender, EventArgs e)
        {
            PickImagePopup frm = new PickImagePopup(ImageTarget.DarkSquare, FillType.Color, Ap.BoardTheme.DarkSquaresColor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SetCustomTheme();
                switch (frm.FillType)
                {
                    case FillType.Color:
                        Ap.BoardTheme.DarkSquaresColor = frm.SelectedColor;
                        Ap.BoardTheme.IsSquareImage = false;
                        LoadColors();
                        break;
                    case FillType.Image:
                        Ap.BoardTheme.DarkSquaresImage = frm.SelectedImage;
                        Ap.BoardTheme.IsSquareImage = true;
                        LoadColors();
                        break;
                    default:
                        break;
                }
            }           
        }

        private void lblBackgroundColor_Click(object sender, EventArgs e)
        {
            PickImagePopup frm = new PickImagePopup(ImageTarget.Background, FillType.Color, Ap.BoardTheme.BoardBackgroundColor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (frm.FillType)
                {
                    case FillType.Color:
                        Ap.BoardTheme.BoardBackgroundColor = frm.SelectedColor;
                        Ap.BoardTheme.IsBoardBackgroundImage = false;
                        LoadColors();
                        break;
                    case FillType.Image:
                        Ap.BoardTheme.BoardBackgroundImage = frm.SelectedImage;
                        Ap.BoardTheme.IsBoardBackgroundImage = true;
                        LoadColors();
                        break;
                    default:
                        break;
                }
            }
        }

        private void pbLightSquares_Click(object sender, EventArgs e)
        {
            PickImagePopup frm = new PickImagePopup(ImageTarget.LightSquare, FillType.Image, Ap.BoardTheme.LightSquaresImage);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SetCustomTheme();
                switch (frm.FillType)
                {
                    case FillType.Color:
                        Ap.BoardTheme.LightSquaresColor = frm.SelectedColor;
                        Ap.BoardTheme.IsSquareImage = false;
                        LoadColors();
                        break;
                    case FillType.Image:
                        Ap.BoardTheme.LightSquaresImage = frm.SelectedImage;
                        Ap.BoardTheme.IsSquareImage = true;
                        LoadColors();
                        break;
                    default:
                        break;
                }
            }
        }

        private void pbDarkSquares_Click(object sender, EventArgs e)
        {
            PickImagePopup frm = new PickImagePopup(ImageTarget.DarkSquare, FillType.Image, Ap.BoardTheme.DarkSquaresImage);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SetCustomTheme();
                switch (frm.FillType)
                {
                    case FillType.Color:
                        Ap.BoardTheme.DarkSquaresColor = frm.SelectedColor;
                        Ap.BoardTheme.IsSquareImage = false;
                        LoadColors();
                        break;
                    case FillType.Image:
                        Ap.BoardTheme.DarkSquaresImage = frm.SelectedImage;
                        Ap.BoardTheme.IsSquareImage = true;
                        LoadColors();
                        break;
                    default:
                        break;
                }
            }   
        }

        private void pbBackground_Click(object sender, EventArgs e)
        {
            PickImagePopup frm = new PickImagePopup(ImageTarget.Background, FillType.Image, Ap.BoardTheme.BoardBackgroundImage);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (frm.FillType)
                {
                    case FillType.Color:
                        Ap.BoardTheme.BoardBackgroundColor = frm.SelectedColor;
                        Ap.BoardTheme.IsBoardBackgroundImage = false;
                        LoadColors();
                        break;
                    case FillType.Image:
                        Ap.BoardTheme.BoardBackgroundImage = frm.SelectedImage;
                        Ap.BoardTheme.IsBoardBackgroundImage = true;
                        LoadColors();
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

    }
}