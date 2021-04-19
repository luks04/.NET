using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TallerConversionTiposCsharp
{
    class Program
    {
        private static TypeConvert convertidorTipos;

        static void Main(string[] args)
        {
            Program miAplicacion = new Program();
            miAplicacion.leerEntradas();
        }

        public int leerDatoEntero()
        {
            int valor = 0;
            valor = Convert.ToInt32(System.Console.ReadLine());
            return (valor);
        }

        public double leerDatoDouble()
        {
            Console.WriteLine("\nRecuerde separar el decimal con punto");
            double valor = 0.0;
            valor = Convert.ToDouble(System.Console.ReadLine(), new CultureInfo("en-US"));
            return (valor);
        }

        public float leerDatoFloat()
        {
            Console.WriteLine("\nRecuerde separar el decimal con punto");
            float valor = 0;
            valor = float.Parse(System.Console.ReadLine(), new CultureInfo("en-US"));
            return (valor);
        }

        public void prepararPantalla()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
        }

        public void imprimirMarco(int a, int b)
        {
            int i = 0;
            for (i = 1; i < a; i++)
            {
                Console.SetCursorPosition(i,1);
                System.Console.Write("▓▓");
                Console.SetCursorPosition(i,b);
                System.Console.Write("▓▓");
            }
            
            for (i = 2; i < b; i++)
            {
                Console.SetCursorPosition(1,i);
                System.Console.Write("▓▓");
                Console.SetCursorPosition(a-1, i);
                System.Console.Write("▓▓");
            }
        }

        public void leerEntradas()
        {
            bool endApp = false;

            while (!endApp)
            {
                convertidorTipos = new TypeConvert();
                string op;
                do
                {
                    prepararPantalla();
                    imprimirMarco(100,25);

                    Console.SetCursorPosition(15,5);
                    Console.WriteLine("********************************************************************");
                    Console.SetCursorPosition(15,6);
                    Console.WriteLine("**************************** BIENVENIDO ****************************");
                    Console.SetCursorPosition(15,7);
                    Console.WriteLine("********************************************************************");
                    Console.SetCursorPosition(15,8);
                    Console.WriteLine("Digite el número correspondiente al punto que desea probar: ");
                    Console.SetCursorPosition(15,9);
                    Console.WriteLine("\t1. Punto 1 - Conversiones implicitas");
                    Console.SetCursorPosition(15,10);
                    Console.WriteLine("\t2. Punto 2 - Implementacion del CultureInfo");
                    Console.SetCursorPosition(15,11);
                    op = Console.ReadLine();
                } while (!op.Equals("1") && !op.Equals("2"));

                if (op == "1")
                {
                    // Punto 1 - Conversiones implicitas
                    prepararPantalla();
                    
                    // Conversiones número entero
                    Console.Write("Digite un número entero: ");
                    int inputEntero = leerDatoEntero();

                    Console.WriteLine("\t" + inputEntero + " es en decimal {0}", convertidorTipos.convertFromEnteroToDecimal(inputEntero));
                    Console.WriteLine("\t" + inputEntero + " es en double {0}", convertidorTipos.convertFromEnteroToDouble(inputEntero));
                    Console.WriteLine("\t" + inputEntero + " es en float {0}", convertidorTipos.convertFromEnteroToFloat(inputEntero));
                    Console.WriteLine("\t" + inputEntero + " es en long {0}", convertidorTipos.convertFromEnteroToLong(inputEntero));

                    /*
                     * ERRORES DE COMPILACIÓN
                     */
                    //Console.WriteLine(inputEntero + " es en byte {0}", convertidorTipos.convertFromEnteroToByte(inputEntero));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'int' en 'byte'.");
                    //Console.WriteLine(inputEntero + " es en sbyte {0}", convertidorTipos.convertFromEnteroToSByte(inputEntero));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'int' en 'sbyte'.");
                    //Console.WriteLine(inputEntero + " es en short {0}", convertidorTipos.convertFromEnteroToShort(inputEntero));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'int' en 'short'.");
                    //Console.WriteLine(inputEntero + " es en ushort {0}", convertidorTipos.convertFromEnteroToUShort(inputEntero));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'int' en 'ushort'.\n");

                    /*************************************************************************************************************/
                    /*************************************************************************************************************/
                    /*************************************************************************************************************/

                    // Conversiones número double
                    Console.Write("Digite un número double: ");
                    double inputDouble = leerDatoDouble();

                    /*
                     * ERRORES DE COMPILACIÓN
                     */
                    //Console.WriteLine(inputDouble + " es en byte {0}", convertidorTipos.convertFromDoubleToByte(inputDouble));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'double' en 'byte'.");
                    //Console.WriteLine(inputDouble + " es en int {0}", convertidorTipos.convertFromDoubleToEntero(inputDouble));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'double' en 'int'.");
                    //Console.WriteLine(inputDouble + " es en float {0}", convertidorTipos.convertFromDoubleToFloat(inputDouble));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'double' en 'float'.");
                    //Console.WriteLine(inputDouble + " es en long {0}", convertidorTipos.convertFromDoubleToLong(inputDouble));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'double' en 'long'.\n");

                    /*************************************************************************************************************/
                    /*************************************************************************************************************/
                    /*************************************************************************************************************/

                    // Conversiones número float
                    Console.Write("Digite un número float: ");
                    float inputFloat = leerDatoFloat();

                    Console.WriteLine("\t" + inputFloat + " es en double {0}", convertidorTipos.convertFromFloatToDouble(inputFloat));

                    /*
                     * ERRORES DE COMPILACIÓN
                     */
                    //Console.WriteLine(inputFloat + " es en byte {0}", convertidorTipos.convertFromFloatToDouble(inputFloat));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'float' en 'byte'.");
                    //Console.WriteLine(inputFloat + " es en sbyte {0}", convertidorTipos.convertFromFloatToDouble(inputFloat));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'float' en 'int'.");
                    //Console.WriteLine(inputFloat + " es en short {0}", convertidorTipos.convertFromFloatToDouble(inputFloat));
                    Console.WriteLine("\tError	CS0266	No se puede convertir implícitamente el tipo 'float' en 'long'.\n");
                                   }
                else // op == 2
                {
                    // Punto 2 - Implementacion del CultureInfo
                    prepararPantalla();

                    bool isValid = false;
                    string valorMoneda = "";
                    do{
                        Console.WriteLine("Ingrese un valor de moneda: ");
                        valorMoneda = Console.ReadLine();
                        if (valorMoneda.Length != 0 && !isValid){
                            isValid = true;
                        }
                    }while(!isValid);
                    string cultureFormat = "";
                    string menuOp;
                    do
                    {
                        Console.WriteLine("Escoja un país: ");
                        Console.WriteLine("\t1. Colombia");
                        Console.WriteLine("\t2. Estados Unidos");
                        Console.WriteLine("\t3. Francia");
                        Console.WriteLine("\t4. Reino Unido");
                        menuOp = Console.ReadLine();
                    } while (!menuOp.Equals("1") && !menuOp.Equals("2") && !menuOp.Equals("3") && !menuOp.Equals("4"));

                    int menuOpIntValue = Convert.ToInt32(menuOp);
                    string[] cultureFormatArray = new string[4] {"es-CO", "en-US","fr-FR","en-GB"};

                    cultureFormat = cultureFormatArray[menuOpIntValue-1];
                    
                    Console.WriteLine("{0}", convertidorTipos.ConvertirFormatoMoneda(valorMoneda, NumberStyles.Float | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, new CultureInfo(cultureFormat), cultureFormat));

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
