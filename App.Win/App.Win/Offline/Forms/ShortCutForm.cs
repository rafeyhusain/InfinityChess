using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InfinityChess
{
    public partial class ShortCutForm : Form
    {
        public ShortCutForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string copiedString = string.Empty;
            foreach (var item in listBox1.Items)
            {
                copiedString = copiedString + item.ToString() + Environment.NewLine;
            }
            
            System.Windows.Forms.Clipboard.SetText(copiedString);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
