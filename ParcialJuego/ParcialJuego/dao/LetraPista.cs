using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialJuego.dao
{
    class LetraPista
    {
        private Int32 letraPistaID;
        private string letra;
        private Int32 codigo;

        public int LetraPistaID { get => letraPistaID; set => letraPistaID = value; }
        public string Letra { get => letra; set => letra = value; }
        public int Codigo { get => codigo; set => codigo = value; }
    }
}
