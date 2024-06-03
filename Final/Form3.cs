using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Final
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            SoundPlayer sonido = new SoundPlayer();
            sonido.SoundLocation = "C:/Users/HP/OneDrive/Escritorio/Final/fin.wav";
            sonido.Play();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:/Users/HP/OneDrive/Escritorio/Final/final.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            timer1.Interval = 3500;
            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Application.Exit();
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
