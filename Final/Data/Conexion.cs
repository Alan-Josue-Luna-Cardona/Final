using Final.Data.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Final.Data
{
    internal class Conexion
    {
        string connectionString = "server=localhost;database=labfinal;user=root;password=si12345";
        MySqlConnection connection;

        public Conexion()
        {
            connection = new MySqlConnection(connectionString);
        }

        public void Insert(Personaje usr)
        {
            try
            {
                string query = "INSERT INTO mk (Nombre, Reino, TipoPersonaje, Victorias, Derrotas, Fatalitys, Creacion) VALUES (@Nombre, @Reino, @TipoPersonaje, @Victorias, @Derrotas, @Fatalitys, @Creacion)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", usr.Nombre);
                cmd.Parameters.AddWithValue("@Reino", usr.Reino);
                cmd.Parameters.AddWithValue("@TipoPersonaje", usr.TipoPersonaje);
                cmd.Parameters.AddWithValue("@Victorias", usr.Victorias);
                cmd.Parameters.AddWithValue("@Derrotas", usr.Derrotas);
                cmd.Parameters.AddWithValue("@Fatalitys", usr.Fatalitys);
                cmd.Parameters.AddWithValue("@Creacion", usr.Creacion);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Kombatiente no pudo ser agregado: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
            public List<Personaje> ObtenerTodosPersonaje()
            {
                List<Personaje> listpersonajes = new List<Personaje>();
            
                using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM labfinal.mk";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Personaje personaje = new Personaje
                        (
                            id: reader.GetInt32(0),
                            nombre: reader.GetString(1),
                            reino: reader.GetString(2),
                            tipoPersonaje: reader.GetString(3),
                            victorias: reader.GetInt32(4),
                            derrotas: reader.GetInt32(5),
                            fatalitys: reader.GetInt32(6),
                            creacion: reader.GetDateTime(7)
                        ); 

                        listpersonajes.Add(personaje);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Detectado: " + ex.Message);
                }
            }

            return listpersonajes;
        }
        public void Actualizar(Personaje usr)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
                try
            {
                string query = "UPDATE labfinal.mk SET Nombre = @Nombre, Reino = @Reino, TipoPersonaje = @TipoPersonaje, Victorias = @Victorias, Derrotas = @Derrotas, Fatalitys = @Fatalitys, Creacion = @Creacion WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", usr.ID);
                cmd.Parameters.AddWithValue("@Nombre", usr.Nombre);
                cmd.Parameters.AddWithValue("@Reino", usr.Reino);
                cmd.Parameters.AddWithValue("@TipoPersonaje", usr.TipoPersonaje);
                cmd.Parameters.AddWithValue("@Victorias", usr.Victorias);
                cmd.Parameters.AddWithValue("@Derrotas", usr.Derrotas);
                cmd.Parameters.AddWithValue("@Fatalitys", usr.Fatalitys);
                cmd.Parameters.AddWithValue("@Creacion", usr.Creacion);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detectado. No se pudo actualizar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public DataRow LeerPorId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM mk WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Detectado. No se puede leer el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt.Rows[0];
        }
        public void Eliminar(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))

                try
                {
                    string query = "DELETE FROM mk WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Detectado. No se pudo eliminar al Kombatiente: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
        }

    }

}


