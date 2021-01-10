using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureApp
{
    public partial class PictureApp : Form
    {
        Image file;
        public PictureApp()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG (*.JPG)|*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog.FileName);
                pbxImage.Image = file;
                pbxImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
