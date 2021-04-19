using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

/*
    INTREGRANTES
    Lucas Alejandro Patiño Dorado
    Maycol Andres Canastero Soler
*/

namespace TallerHerenciaInterfaces_Punto1
{
    class Program
    {

        private static Circulo figuraCirculo;
        private static Paralelogramo figuraParalelogramo;

        static void Main(string[] args)
        {
            Program miAplicacion = new Program();
            miAplicacion.ejecutarOperacion();
        }

        public void prepararPantalla()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
        }

        public bool validarNumerosDoubles(string valor)
        {
            string[] array = valor.Split(',');
            if (array.Length >= 2)
            {
                Console.WriteLine("Recuerde separar el valor decimal con punto '.' y las unidades de miles con coma ','");
                return false;
            }
            try
            {
                double.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public double convertirToDoubles(string valor)
        {
            double resultado = Double.Parse(valor, new CultureInfo("en-CO"));
            return resultado;
        }

        public void ejecutarOperacion()
        {
            bool endApp = false;

            while (!endApp)
            {
                prepararPantalla();
                Console.WriteLine("********************************************************************");
                Console.WriteLine("**************************** BIENVENIDO ****************************");
                Console.WriteLine("********************************************************************");

                figuraCirculo = new Circulo();
                figuraParalelogramo = new Paralelogramo();

                /********************************************************************************/

                string op;
                do
                {
                    Console.WriteLine("Digite el número correspondiente a la figura que desea crear: ");
                    Console.WriteLine("\t1. Circulo");
                    Console.WriteLine("\t2. Paralelogramo");
                    op = Console.ReadLine();
                } while (!op.Equals("1") && !op.Equals("2"));

                if (op == "1")
                {
                    //Circulo
                    prepararPantalla();
                    string inputRadio;
                    string inputNombreCirculo;
                    string inputColorCirculo;
                    string inputAnguloCirculo;
                    double anguloCirculo = 0.0;
                    bool isValidCirculo = false;
                    do
                    {
                        Console.WriteLine("Digite el nombre del circulo: ");
                        inputNombreCirculo = Console.ReadLine();
                        while (inputNombreCirculo.Length != 0 && !isValidCirculo)
                        {
                            figuraCirculo.Nombre = inputNombreCirculo;
                            Console.WriteLine("Digite el color del circulo: ");
                            inputColorCirculo = Console.ReadLine();
                            while (inputColorCirculo.Length != 0 && !isValidCirculo)
                            {
                                figuraCirculo.Color = inputColorCirculo;
                                Console.WriteLine("Digite el radio del circulo: ");
                                inputRadio = Console.ReadLine();
                                if (validarNumerosDoubles(inputRadio) && !isValidCirculo)
                                {
                                    figuraCirculo.Radio = convertirToDoubles(inputRadio);
                                    while (figuraCirculo.Radio != 0.0 && !isValidCirculo)
                                    {
                                        figuraCirculo.Diametro = figuraCirculo.Radio * 2;
                                        Console.WriteLine("Digite el angulo para calcular el arco del circulo: ");
                                        inputAnguloCirculo = Console.ReadLine();
                                        if (validarNumerosDoubles(inputAnguloCirculo) && !isValidCirculo)
                                        {
                                            anguloCirculo = convertirToDoubles(inputAnguloCirculo);
                                            if (anguloCirculo != 0.0)
                                            {
                                                isValidCirculo = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }



                    } while (!isValidCirculo);


                    figuraCirculo.imprimirInfoFigura();
                    figuraCirculo.imprimirCirculo();
                    Console.WriteLine("\tde color {0}, con un radio de {1} y un angulo de {2}\n", figuraCirculo.Color, figuraCirculo.Radio, anguloCirculo);
                    Console.WriteLine("\ttiene un arco de circulo {0}, un perimetro de {1} y un área de {2}\n", figuraCirculo.calcularArcoCirculo(anguloCirculo), figuraCirculo.calcularPerimetro(), figuraCirculo.calcularArea());
                }
                else // op == 2
                {
                    //Paralelogramo
                    prepararPantalla();
                    string inputNombreParalelogramo;
                    string inputColorParalelogramo;
                    string inputLado1;
                    string inputLado2;
                    string inputAltura;
                    double alturaParalelogramo = 0.0;
                    bool isValidParalelogramo = false;

                    do
                    {
                        Console.WriteLine("Digite el nombre del Paralelogramo: ");
                        inputNombreParalelogramo = Console.ReadLine();
                        while (inputNombreParalelogramo.Length != 0 && !isValidParalelogramo)
                        {
                            figuraParalelogramo.Nombre = inputNombreParalelogramo;
                            Console.WriteLine("Digite el color del Paralelogramo: ");
                            inputColorParalelogramo = Console.ReadLine();
                            while (inputColorParalelogramo.Length != 0 && !isValidParalelogramo)
                            {
                                figuraParalelogramo.Color = inputColorParalelogramo;
                                Console.WriteLine("Digite el valor para uno de los lados del Paralelogramo en centimetros: ");
                                inputLado1 = Console.ReadLine();
                                while (validarNumerosDoubles(inputLado1) && !isValidParalelogramo)
                                {
                                    figuraParalelogramo.Lado1 = convertirToDoubles(inputLado1);
                                    Console.WriteLine("Digite el valor para el otro lado del Paralelogramo en centimetros: ");
                                    inputLado2 = Console.ReadLine();
                                    while (validarNumerosDoubles(inputLado2) && !isValidParalelogramo)
                                    {
                                        figuraParalelogramo.Lado2 = convertirToDoubles(inputLado2);
                                        Console.WriteLine("Digite la altura del Paralelogramo: ");
                                        inputAltura = Console.ReadLine();
                                        if (validarNumerosDoubles(inputAltura) && !isValidParalelogramo)
                                        {
                                            alturaParalelogramo = convertirToDoubles(inputAltura);
                                            if (alturaParalelogramo != 0.0)
                                            {
                                                figuraParalelogramo.Altura = alturaParalelogramo;
                                                isValidParalelogramo = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    } while (!isValidParalelogramo);

                    figuraParalelogramo.imprimirInfoFigura();
                    figuraParalelogramo.imprimirParalelogramo();

                    Console.WriteLine("\tde color {0}, con un lado de {1}, el segundo lado de {2} y una altura de {3}\n", figuraParalelogramo.Color, figuraParalelogramo.Lado1, figuraParalelogramo.Lado2, figuraParalelogramo.Altura);
                    Console.WriteLine("\ttiene un perimetro de {0} y un área de {1}\n", figuraParalelogramo.calcularPerimetro(), figuraParalelogramo.calcularArea());

                }

                // Esperar a que el usuario responda
                Console.Write("Presione la tecla 'n' para finalizar, sino presione otra otra tecla para continuar: ");
                if (Console.ReadLine() == "n")
                    endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }

    }
}
