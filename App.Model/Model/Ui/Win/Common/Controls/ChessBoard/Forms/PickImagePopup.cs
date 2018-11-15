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
    public partial class PickImagePopup : Form
    {
        #region DataMembers 

        public ImageTarget ImageTarget = ImageTarget.Background;
        public FillType FillType = FillType.Image;
        public string SelectedColor = null;
        public string SelectedImage = null;

        #endregion

        #region Ctor
        public PickImagePopup(ImageTarget imageTarget,FillType fillType,string selectedItem)
        {
            InitializeComponent();
            this.ImageTarget = imageTarget;
            this.FillType = fillType;
            switch (this.FillType)
            {
                case FillType.Color:
                    this.SelectedColor = selectedItem;
                    break;
                case FillType.Image:
                    this.SelectedImage = selectedItem;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Form Load

        private void PickImagePopup_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        #endregion

        #region Helper Methods 

        private void LoadItems()
        {
            LoadComboBoxes();
            switch (this.FillType)
            {
                case FillType.Color:
                    colorDialog1.Color = ColorTranslator.FromHtml(this.SelectedColor);
                    rdbPickColor.Checked = true;
                    break;
                case FillType.Image:
                    cmbBackground.SelectedValue = this.SelectedImage;
                    rdbChooseImage.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void LoadComboBoxes()
        {
            cmbBackground.DataSource = GetFiles(); // Ap.BoardTheme.KvBackground.DataTable;
            cmbBackground.DisplayMember = "k";
            cmbBackground.ValueMember = "v";            
        }

        private DataTable GetFiles()
        {
            string folderPath = "";
            folderPath = GetFolderPath();

            string[] files = Directory.GetFiles(folderPath, "*.jpg");
            string k = "";
            string v = "";
            Kv kv = new Kv();
            kv.DataTable.Clear();

            foreach (string file in files)
            {
                k = Path.GetFileNameWithoutExtension(file);
                v = Path.GetFileName(file);
                kv.Set(k, v);

            }
            return kv.DataTable;
        }

        private string GetFolderPath()
        {
            string folderPath = "";
            switch (this.ImageTarget)
            {
                case ImageTarget.LightSquare:
                    folderPath = Ap.FolderLightSquares;
                    break;
                case ImageTarget.DarkSquare:
                    folderPath = Ap.FolderDarkSquares;
                    break;
                case ImageTarget.Background:
                    folderPath = Ap.FolderImagesBackground;
                    break;
                default:
                    break;
            }
            return folderPath;
        }

        private bool ValidateSelection()
        {
            switch (this.FillType)
            {
                case FillType.Color:
                    if (string.IsNullOrEmpty(this.SelectedColor))
                    {
                        MessageForm.Show("Please select color.");
                        return false;
                    }
                    break;
                case FillType.Image:
                    if (string.IsNullOrEmpty(this.SelectedImage))
                    {
                        MessageForm.Show("Please select image.");
                        return false;
                    }
                    else if (!this.SelectedImage.EndsWith(".jpg"))
                    {
                        MessageForm.Show("Please select only 'jpg' image.");
                        return false;
                    }
                    
                    break;
                default:
                    break;
            }

            return true;
        }

        #endregion

        #region Events 
        
        private void rdbChooseImage_Click(object sender, EventArgs e)
        {
            if (rdbChooseImage.Checked)
            {
                this.FillType = FillType.Image;
                if (cmbBackground.SelectedValue != null)
                {
                    this.SelectedImage = cmbBackground.SelectedValue.ToString();
                }
            }
        }

        private void rdbPickColor_Click(object sender, EventArgs e)
        {
            if (rdbPickColor.Checked)
            {
                this.FillType = FillType.Color;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {   
                    this.SelectedColor = ColorTranslator.ToHtml(colorDialog1.Color);
                }
            }
        }

        private void rdbPickImage_Click(object sender, EventArgs e)
        {
            if (rdbPickImage.Checked)
            {
                this.FillType = FillType.Image;

                openFileDialog1.Filter = "Pictures(*jpg)|*.jpg";
                openFileDialog1.FileName = "*.jpg";
                openFileDialog1.InitialDirectory = "C:\\";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(openFileDialog1.FileName);
                    if (!fileName.EndsWith(".jpg"))
                    {
                        MessageForm.Show("Please select only 'jpg' image.");
                        return;
                    }
                    string destinationFilePath = GetFolderPath() + fileName;

                    if (!File.Exists(destinationFilePath))
                    {
                        File.Copy(openFileDialog1.FileName, destinationFilePath);
                    }
                    this.SelectedImage = fileName;
                }
            }
        }

        private void cmbBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBackground.SelectedValue != null)
            {
                this.SelectedImage = cmbBackground.SelectedValue.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateSelection())
            {
                return;
            }           

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

    }
}