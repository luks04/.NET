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
    class Circulo : Figura
    {
        private double radio;
        private double diametro;

        public double Radio { get => radio; set => radio = value; }
        public double Diametro { get => diametro; set => diametro = value; }

        //Constructor vacío o por defecto
        public Circulo()
        {
        }

        public Circulo(string nombre, string color, double radio, double diametro)
        {
            //Herencia de los atributos de la superclase
            Nombre = nombre;
            Color = color;
            //Nuevo atributo para el objeto
            Radio = radio;
            Diametro = diametro;
        }

        public double calcularArcoCirculo(double angulo)
        {
            double longitudArco = Radio * angulo;
            return longitudArco;
        }

        public double calcularPerimetro()
        {
            double perimetroCirculo = 2 * Math.PI * Radio;
            return perimetroCirculo;
        }

        public double calcularArea()
        {
            double areaCirculo = Math.PI * Math.Pow(Radio, 2.0);
            return areaCirculo;
        }

        public void imprimirCirculo()
        {
            Console.WriteLine("\t");
            Console.WriteLine("              Radio = {0} cm", Radio);
            Console.WriteLine("\t               *****");
            Console.WriteLine("\t           *************");
            Console.WriteLine("\t         *****************");
            Console.WriteLine("\t        *******************");
            Console.WriteLine("\t       *********************   Diametro = {0} cm", Diametro);
            Console.WriteLine("\t        *******************");
            Console.WriteLine("\t         *****************");
            Console.WriteLine("\t           *************");
            Console.WriteLine("\t               *****");
            Console.WriteLine("\t");
        }
    }
}
