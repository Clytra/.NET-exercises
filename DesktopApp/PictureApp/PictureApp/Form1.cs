using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PictureApp
{
    public partial class PictureApp : Form
    {
        Image file;
        string filePath;
        string programPath = Program.FilePath;

        public PictureApp()
        {
            InitializeComponent();
            GetPreviousImage();
        }

        private void GetPreviousImage()
        {
            if (File.Exists(programPath))
            {
                string readText = File.ReadAllText(programPath);
                file = Image.FromFile(readText);
                pbxImage.Image = file;
                pbxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG (*.JPG)|*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                btnDelete.Enabled = true;
                file = Image.FromFile(openFileDialog.FileName);
                pbxImage.Image = file;
                pbxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                filePath = openFileDialog.FileName;
            }
        }

        private void PictureApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (file != null && filePath != null)
            {
                using (StreamWriter writer = new StreamWriter(programPath))
                {
                    writer.WriteLine(filePath);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pbxImage.Image = null;
            btnDelete.Enabled = false;
        }
    }
}
