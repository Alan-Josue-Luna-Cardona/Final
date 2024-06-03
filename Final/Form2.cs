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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C:/Users/HP/OneDrive/Escritorio/Final/musica.wav";
            Sonido.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
