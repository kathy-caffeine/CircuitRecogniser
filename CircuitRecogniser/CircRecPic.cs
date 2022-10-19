using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircuitRecogniser
{
    public partial class CircRecPic : Form
    {
        Bitmap pic;
        public CircRecPic(Bitmap _pic)
        {
            InitializeComponent();
            pic = _pic;
        }

        private void CircRecPic_Load(object sender, EventArgs e)
        {
            pictureOutput.Image = pic;
        }
    }
}
