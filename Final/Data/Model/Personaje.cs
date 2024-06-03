using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Model
{
    internal class Personaje
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Reino { get; set; }
        public string TipoPersonaje { get; set; }
        public int Victorias { get; set; }
        public int Derrotas { get; set; }
        public int Fatalitys { get; set; }
        public DateTime Creacion { get; set; }



        public Personaje() { }
        public Personaje(int id) {}
        public Personaje (int id, string nombre, string reino, string tipoPersonaje, int victorias, int derrotas, int fatalitys, DateTime creacion)
        {
            ID = id;
            Nombre = nombre;
            Reino = reino;
            TipoPersonaje = tipoPersonaje;
            Victorias = victorias;
            Derrotas = derrotas;
            Fatalitys = fatalitys;
            Creacion = creacion;
        }
    }
}
