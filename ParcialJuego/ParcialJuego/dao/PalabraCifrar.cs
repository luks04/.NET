using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ParcialJuego.dao
{
    class PalabraCifrar
    {
        private Int32 palabraID;
        private Int32 ronda;
        private string palabra;
        private string categoria;

        public int PalabraID { get => palabraID; set => palabraID = value; }
        public int Ronda { get => ronda; set => ronda = value; }
        public string Palabra { get => palabra; set => palabra = value; }
        public string Categoria { get => categoria; set => categoria = value; }
    }
}
