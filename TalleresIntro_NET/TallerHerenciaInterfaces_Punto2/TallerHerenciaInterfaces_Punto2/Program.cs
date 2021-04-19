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

namespace TallerHerenciaInterfaces_Punto2
{
    class Program
    {
        private static InterfaceCuentas cuentaBancaria;

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

        public bool validarNumerosLong(string valor)
        {
            try
            {
                long.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public long convertirToLong(string valor)
        {
            long resultado = long.Parse(valor);
            return resultado;
        }

        public string menuRetiroPrestamo()
        {
            string op;
            do
            {
                Console.WriteLine("Digite el número correspondiente al menú que desea ingresar: ");
                Console.WriteLine("\t1. Retiro");
                Console.WriteLine("\t2. Prestamo");
                op = Console.ReadLine();
            } while (!op.Equals("1") && !op.Equals("2"));
            prepararPantalla();
            return op;
        }

        public long menuRetiro()
        {
            string op;
            bool isValidRetiro = false;
            do
            {
                Console.WriteLine("Digite el valor que desea retirar: ");
                op = Console.ReadLine();
                if (validarNumerosLong(op))
                {
                    isValidRetiro = true;
                }
            } while (!isValidRetiro);
            prepararPantalla();
            return convertirToLong(op);
        }

        public long menuPrestamo()
        {
            string op;
            bool isValidPrestamo = false;
            do
            {
                Console.WriteLine("Digite el valor que desea solicitar: ");
                op = Console.ReadLine();
                if (validarNumerosLong(op))
                {
                    isValidPrestamo = true;
                }
            } while (!isValidPrestamo);
            prepararPantalla();
            return convertirToLong(op);
        }

        public void ejecutarOperacion()
        {
            bool endApp = false;
            CuentaIndustrial cuentaIndsutrial_1 = new CuentaIndustrial("1074189401", 1000000, "Maycol Canastero");
            CuentaComercial cuentaComercial_1 = new CuentaComercial("1230099861", 600000, "Lucas Patiño");
            while (!endApp)
            {
                prepararPantalla();
                Console.WriteLine("********************************************************************");
                Console.WriteLine("**************************** BIENVENIDO ****************************");
                Console.WriteLine("********************************************************************");

                /********************************************************************************/

                string op;
                do
                {
                    Console.WriteLine("Digite el número correspondiente al menú que desea ingresar: ");
                    Console.WriteLine("\t1. Cuenta comercial");
                    Console.WriteLine("\t2. Cuenta industrial");
                    op = Console.ReadLine();
                } while (!op.Equals("1") && !op.Equals("2"));

                if (op == "1")
                {
                    //Cuenta comercial
                    prepararPantalla();
                    string menuComercial = menuRetiroPrestamo();
                    cuentaBancaria = (InterfaceCuentas)cuentaComercial_1;
                    if (menuComercial == "1")
                    {
                        long valorRetiro = menuRetiro();
                        Console.WriteLine("\t{0}", cuentaBancaria.Retirar(valorRetiro));
                    }
                    else if (menuComercial == "2")
                    {
                        long valorPrestamo = menuPrestamo();
                        Console.WriteLine("\t{0}", cuentaBancaria.SolicitarPrestamo(valorPrestamo));
                    }
                }
                else if (op == "2")
                {
                    //Cuenta industrial
                    prepararPantalla();
                    string menuComercial = menuRetiroPrestamo();
                    cuentaBancaria = (InterfaceCuentas)cuentaIndsutrial_1;
                    if (menuComercial == "1")
                    {
                        long valorRetiro = menuRetiro();
                        Console.WriteLine("\t{0}", cuentaBancaria.Retirar(valorRetiro));
                    }
                    else if (menuComercial == "2")
                    {
                        long valorPrestamo = menuPrestamo();
                        cuentaBancaria.SolicitarPrestamo(valorPrestamo);
                        Console.WriteLine("\t{0}", cuentaBancaria.SolicitarPrestamo(valorPrestamo));
                    }
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
