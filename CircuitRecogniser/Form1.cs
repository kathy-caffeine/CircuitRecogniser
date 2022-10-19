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
                //pictureInput.Image = Image.FromFile(sFileName);
                imageWarrior.inputBitmap = MakeGrayscale(new Bitmap(sFileName));
                buttonStart.Enabled = true;
                pictureInput.Image = imageWarrior.inputBitmap;
                //pictureInput.Image = imageWarrior.inputBitmap;


                //temp
                imageWarrior.outputBitmap = imageWarrior.inputBitmap;
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
            CircRecPic form = new CircRecPic(imageWarrior.outputBitmap);
            form.Show(this);
            //form.Dispose();
        }



        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

                //create the grayscale ColorMatrix
                System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(
                   new float[][]
                   {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (System.Drawing.Imaging.ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes())
                {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }
    }
}
