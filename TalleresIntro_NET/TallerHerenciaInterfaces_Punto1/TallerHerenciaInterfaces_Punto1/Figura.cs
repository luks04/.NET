using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    INTREGRANTES
    Lucas Alejandro Patiño Dorado
    Maycol Andres Canastero Soler
*/

namespace TallerHerenciaInterfaces_Punto1
{
    class Figura
    {
        // Atributos
        private string nombre;
        private string color;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Color { get => color; set => color = value; }

        // Constructor Objeto Duplicado
        public Figura(Figura copiaFigura)
        {
            Nombre = copiaFigura.Nombre;
            Color = copiaFigura.Color;
        }

        public Figura(string nombre, string color)
        {
            Nombre = nombre;
            Color = color;
        }

        public Figura()
        {
            Nombre = "";
            Color = "";
        }

        public void imprimirInfoFigura()
        {
            System.Console.WriteLine("----------------------------------------------------------------------------------------------");
            System.Console.WriteLine("La figura " + this.nombre);
            System.Console.WriteLine("----------------------------------------------------------------------------------------------");
        }
    }
}
