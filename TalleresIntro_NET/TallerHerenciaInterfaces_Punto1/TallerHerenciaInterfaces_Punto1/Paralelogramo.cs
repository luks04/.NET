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
    class Paralelogramo : Figura
    {
        private double lado1;
        private double lado2;
        private double altura;

        public double Lado1 { get => lado1; set => lado1 = value; }
        public double Lado2 { get => lado2; set => lado2 = value; }
        public double Altura { get => altura; set => altura = value; }


        //Constructor vacío o por defecto
        public Paralelogramo()
        {
        }

        public Paralelogramo(string nombre, string color, double lado1, double lado2, double altura)
        {
            //Herencia de los atributos de la superclase
            Nombre = nombre;
            Color = color;
            //Nuevo atributo para el objeto
            Lado1 = lado1;
            Lado2 = lado2;
            Altura = altura;
        }

        public double calcularPerimetro()
        {
            double perimetroParalelogramo = 2 * Lado1 + 2 * Lado2;
            return perimetroParalelogramo;
        }

        public double calcularArea()
        {
            double areaParalelogramo = Lado1 * Altura;
            return areaParalelogramo;
        }

        public void imprimirParalelogramo()
        {
            Console.WriteLine("\t");
            Console.WriteLine("             lado 1 = {0} cm", Lado1);
            Console.WriteLine("\t    _____________________________");
            Console.WriteLine("\t   /                            /");
            Console.WriteLine("\t  /                            /  lado 2 = {0} cm", Lado2);
            Console.WriteLine("\t /                            /");
            Console.WriteLine("\t/____________________________/ \n");
            Console.WriteLine("\t     altura = {0} cm", altura);
            Console.WriteLine("\t");
        }
    }
}
