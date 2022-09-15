using System;
using System.Drawing;
using System.Windows.Forms;

namespace CircuitRecogniser
{
    public partial class Form1 : Form
    {
        ControllerCircuitRecogniser imageWarrior;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pictures Files |*.jpg;*.jpeg;*.png";
            
            dialog.InitialDirectory = @"E:\";
            dialog.Multiselect = false;
            dialog.Title = "Please select an image.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = dialog.FileName;
                pictureInput.Image = Image.FromFile(sFileName);
                imageWarrior.inputBitmap = new Bitmap(pictureInput.Image);
                buttonStart.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageWarrior = new ControllerCircuitRecogniser();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (radioButPrevit.Checked==true)
            {
                /**/
            }
            if (radioButRoberts.Checked == true)
            {
                /**/
            }
            if (radioButSapo.Checked == true)
            {
                /**/
            }
            if (radioButSobel.Checked == true)
            {
                /**/
            }
            buttonDownload.Enabled = true;
        }
    }
}
