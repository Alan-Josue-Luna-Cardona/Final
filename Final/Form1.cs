using Final.Data;
using Final.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Final
{
    public partial class Form1 : Form
    {
        Conexion Clscone = new Conexion();
        Personaje usr = new Personaje();
        List<Personaje> todos;
        Data.Model.Cursor cursor1 = new Data.Model.Cursor();

        private string[] Reinos = {
            "Tierra",
            "Mundo Exterior",
            "Edenia" };
        private string[] TipoPersonajes = {
            "Jugable",
            "Jefe",
            "Ambos",
            "Invitado"};

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxReino.Items.AddRange(Reinos);
            comboBoxPersonaje.Items.AddRange(TipoPersonajes);
        }

        private void buttoncrear_Click(object sender, EventArgs e)
        {
            try
            {
                usr.Nombre = textBoxNombre.Text;
                usr.Reino = comboBoxReino.Text;
                usr.TipoPersonaje = comboBoxPersonaje.Text;
                usr.Victorias = Int32.Parse(numericVict.Text);
                usr.Derrotas = Int32.Parse(numericDerr.Text);
                usr.Fatalitys = Int32.Parse(numericFatal.Text);
                usr.Creacion = dateTimePicker1.Value;
                Clscone.Insert(usr);
                MessageBox.Show("Nuevo Kombatiente Ingresado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detectado. No se pudo agregar al Kombatiente: " + ex.Message);
            }
        }

        private void buttontodos_Click(object sender, EventArgs e)
        {
            try {
                todos = Clscone.ObtenerTodosPersonaje();
                dataGridView1.DataSource = todos;
                if (todos.Count > 0)
                {
                    cursor1.totalRegistros = todos.Count;
                    cursor1.current = 0;
                    Next();
                    cursor1.current--;
                    Personaje u = todos[0];
                    textBoxID.Text = u.ID.ToString();
                    textBoxNombre.Text = u.Nombre;
                    comboBoxReino.Text = u.Reino;
                    comboBoxPersonaje.Text = u.TipoPersonaje;
                    numericVict.Value = u.Victorias;
                    numericDerr.Value = u.Derrotas;
                    numericFatal.Value = u.Victorias;
                    dateTimePicker1.Value = u.Creacion;

                }
                else
                {
                    MessageBox.Show("No hay registros");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detectado. " + ex.Message);
            }
        }


        private void Next()
        {
            try {
                if (cursor1.current >= 0 && cursor1.current < cursor1.totalRegistros)
                {
                    cursor1.current++;
                    Personaje u = todos[cursor1.current];
                    textBoxID.Text = u.ID.ToString();
                    textBoxNombre.Text = u.Nombre;
                    comboBoxReino.Text = u.Reino;
                    comboBoxPersonaje.Text = u.TipoPersonaje;
                    numericVict.Value = u.Victorias;
                    numericDerr.Value = u.Derrotas;
                    numericFatal.Value = u.Victorias;
                    dateTimePicker1.Value = u.Creacion;

                    if (cursor1.current >= cursor1.totalRegistros)
                    {
                        cursor1.current = 0;
                        MessageBox.Show("Fin de los registros");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detectado. No es posible avanzar: " + ex.Message);
            }
        }
        private void Back()
        {
            try {
                if (cursor1.current >= 0 && cursor1.current < cursor1.totalRegistros)
                {
                    cursor1.current--;
                    Personaje u = todos[cursor1.current];
                    textBoxID.Text = u.ID.ToString();
                    textBoxNombre.Text = u.Nombre;
                    comboBoxReino.Text = u.Reino;
                    comboBoxPersonaje.Text = u.TipoPersonaje;
                    numericVict.Value = u.Victorias;
                    numericDerr.Value = u.Derrotas;
                    numericFatal.Value = u.Victorias;
                    dateTimePicker1.Value = u.Creacion;

                    if (cursor1.current >= cursor1.totalRegistros)
                    {
                        cursor1.current = 0;
                        MessageBox.Show("Fin de los registros");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detectado. No es posible regresar: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Next();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void buttonactu_Click(object sender, EventArgs e)
        {
            try {
                usr.ID = Int32.Parse(textBoxID.Text);
                usr.Nombre = textBoxNombre.Text;
                usr.Reino = comboBoxReino.Text;
                usr.TipoPersonaje = comboBoxPersonaje.Text;
                usr.Victorias = Int32.Parse(numericVict.Text);
                usr.Derrotas = Int32.Parse(numericDerr.Text);
                usr.Fatalitys = Int32.Parse(numericFatal.Text);
                usr.Creacion = dateTimePicker1.Value;
                Clscone.Actualizar(usr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detectado. No fue posible actualizar el registro" + ex.Message);
            }
        }

        private void buttonelim_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxID.Text);
            try
            {
                Clscone.Eliminar(id);
                MessageBox.Show("Kombatiente eliminado con extio.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detectado. No fue posible eliminar al Kombatiente: " + ex.Message);
            }

        }

        private void buttonbuscar_Click(object sender, EventArgs e)
        {
            try {
                DataRow resp = Clscone.LeerPorId(int.Parse(textBoxID.Text));
                if (resp != null)
                {
                    textBoxNombre.Text = resp["Nombre"].ToString();
                    comboBoxReino.SelectedItem = resp["Reino"].ToString();
                    comboBoxPersonaje.SelectedItem = resp["TipoPersonaje"].ToString();
                    numericVict.Value = (Int32)resp["Victorias"];
                    numericDerr.Value = (Int32)resp["Derrotas"];
                    numericFatal.Value = (Int32)resp["Fatalitys"];
                    dateTimePicker1.Value = (DateTime)resp["Creacion"];
                    MessageBox.Show("Kombatiente encontrado");

                }
                else
                {
                    MessageBox.Show("No se encontro el registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detectado. No fue posible realizar la busqueda: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                textBoxID.Clear();
                textBoxNombre.Clear();
                comboBoxReino.SelectedIndex = -1;
                comboBoxPersonaje.SelectedIndex = -1;
                numericVict.Value = numericVict.Minimum;
                numericDerr.Value = numericDerr.Minimum;
                numericFatal.Value = numericFatal.Minimum;
                dateTimePicker1.Value = DateTime.Now;
                dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detectado: " + ex.Message);
            }

        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericDerr_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
    }

