using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Parcial2_NET.controller;
using Parcial2_NET.dao;

/*
    Integrantes
Maycol Andres Canastero Soler
Lucas Alejandro Patiño Dorado
 */

namespace Parcial2_NET
{
    class Program
    {
        //Marco de pantalla
        public void imprimirMarco(byte x, byte y)
        {
            int i = 0;
            int a = x; // Conversion implícita
            int b = y; // Conversion implícita
            for (i = 1; i < a; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("▓▓");
                Console.SetCursorPosition(i, b);
                Console.Write("▓▓");
            }

            for (i = 2; i < b; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("▓▓");
                Console.SetCursorPosition(a - 1, i);
                Console.Write("▓▓");
            }
        }

        //Manejo de la pantalla
        public void prepararPantalla()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
        }

        public static void clearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(15, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(1, Console.CursorTop);
            Console.Write("▓▓");
            Console.SetCursorPosition(109, currentLineCursor);
            Console.Write("▓▓");
            Console.SetCursorPosition(15, currentLineCursor);
        }

        // Metodos validacion datos
        public bool validarNumerosDecimales(string valor)
        {
            string[] array = valor.Split(',');
            if (array.Length >= 2)
            {
                Console.SetCursorPosition(15, 10);
                Console.WriteLine("Recuerde separar el valor decimal con punto '.' y las unidades de miles con coma ','");
                return false;
            }
            try
            {
                decimal.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public decimal convertirToDecimal(string valor)
        {
            decimal resultado = decimal.Parse(valor, new CultureInfo("en-CO"));
            return resultado;
        }

        public bool validarRangoTasaCambio(decimal inputTasaCambio)
        {
            bool isValid = false;
            if(inputTasaCambio <=1 && inputTasaCambio > 0)
            {
                isValid = true;
            }
            else
            {
                Console.SetCursorPosition(15, 11);
                Console.WriteLine("Recuerde que la tasa de cambio debe ser mayor a 0 y menor o igual a 1");
            }
            return isValid;
        }

        public decimal ingresoConsolaDecimal(string mensaje)
        {
            bool valid_1 = false;
            decimal valorDecimal = 0;
            while (!valid_1)
            {
                Console.SetCursorPosition(15, 9);
                clearCurrentConsoleLine();
                Console.Write(mensaje);
                string inputDecimal = System.Console.ReadLine();
                bool valid_2 = validarNumerosDecimales(inputDecimal);
                if (valid_2)
                {
                    valorDecimal = convertirToDecimal(inputDecimal);
                    valid_1 = true;
                }
            }
            return valorDecimal;
        }

        public bool validarSimilitudOrigenDestino(string origen, string destino)
        {
            if (origen == destino)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(15, 14);
                Console.WriteLine("No se puede seleccionar la misma opción de origen y destino,");
                Console.SetCursorPosition(15, 15);
                Console.WriteLine("debe seleccionar un destino diferente.");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Program miAplicacion = new Program();
            miAplicacion.ejecutarOperacionesParcial2();
        }

        public void ejecutarOperacionesParcial2()
        {
            ControladorParcial conversionController = new ControladorParcial();

            bool endApp = false;

            while (!endApp)
            {
                prepararPantalla();
                imprimirMarco(110, 30);
                Console.SetCursorPosition(15, 5);
                Console.WriteLine("********************************************\n");
                Console.SetCursorPosition(15, 6);
                Console.WriteLine("Parte practica parcial segundo corte\r");
                Console.SetCursorPosition(15, 7);
                Console.WriteLine("********************************************\n");
                Console.SetCursorPosition(15, 8);
                decimal valorMonedaOrigen = ingresoConsolaDecimal("Ingrese el valor de la moneda de origen: ");
                prepararPantalla();
                imprimirMarco(110, 30);
                string op_MonedaOrigen;
                do
                {
                    Console.SetCursorPosition(15, 5);
                    Console.WriteLine("Lista de opciones de moneda de origen");
                    Console.SetCursorPosition(15, 6);
                    Console.WriteLine("\t1 - Dólares americanos");
                    Console.SetCursorPosition(15, 7);
                    Console.WriteLine("\t2 - Euros");
                    Console.SetCursorPosition(15, 8);
                    Console.WriteLine("\t3 - Yuanes(Renminbi)");
                    Console.SetCursorPosition(15, 9);
                    Console.WriteLine("\t4 - Yenes japoneses");
                    Console.SetCursorPosition(15, 10);
                    Console.WriteLine("\t5 - Pesos colombianos");
                    Console.SetCursorPosition(15, 11);
                    Console.WriteLine("Seleccione la opción de la moneda de origen: ");
                    Console.SetCursorPosition(15, 12);
                    clearCurrentConsoleLine();
                    op_MonedaOrigen = Console.ReadLine();
                } while (!op_MonedaOrigen.Equals("1") && !op_MonedaOrigen.Equals("2") && !op_MonedaOrigen.Equals("3") && !op_MonedaOrigen.Equals("4") && !op_MonedaOrigen.Equals("5"));
                
                prepararPantalla();
                imprimirMarco(110, 30);
                string op_MonedaDestino = "";
                bool valid_SimilitudOrigenDestino = false;
                do
                {
                    while (!valid_SimilitudOrigenDestino)
                    {
                        Console.SetCursorPosition(15, 5);
                        Console.WriteLine("Lista de opciones de moneda de destino");
                        Console.SetCursorPosition(15, 6);
                        Console.WriteLine("\t1 - Dólares americanos");
                        Console.SetCursorPosition(15, 7);
                        Console.WriteLine("\t2 - Euros");
                        Console.SetCursorPosition(15, 8);
                        Console.WriteLine("\t3 - Yuanes(Renminbi)");
                        Console.SetCursorPosition(15, 9);
                        Console.WriteLine("\t4 - Yenes japoneses");
                        Console.SetCursorPosition(15, 10);
                        Console.WriteLine("\t5 - Pesos colombianos");
                        Console.SetCursorPosition(15, 11);
                        Console.WriteLine("Seleccione la opción de la moneda de destino: ");
                        Console.SetCursorPosition(15, 12);
                        clearCurrentConsoleLine();
                        op_MonedaDestino = Console.ReadLine();
                        if ((op_MonedaDestino.Equals("1") || op_MonedaDestino.Equals("2") || op_MonedaDestino.Equals("3") || op_MonedaDestino.Equals("4") || op_MonedaDestino.Equals("5")) && !validarSimilitudOrigenDestino(op_MonedaOrigen, op_MonedaDestino))
                        {
                            valid_SimilitudOrigenDestino = true;
                        }
                    }
                } while (!op_MonedaDestino.Equals("1") && !op_MonedaDestino.Equals("2") && !op_MonedaDestino.Equals("3") && !op_MonedaDestino.Equals("4") && !op_MonedaDestino.Equals("5"));
                
                prepararPantalla();
                imprimirMarco(110, 30);
                bool isValidTasaCambio = false;
                decimal valorTasaCambio = 0;
                while (!isValidTasaCambio)
                {
                    Console.SetCursorPosition(15, 5);
                    valorTasaCambio = ingresoConsolaDecimal("Ingrese el valor de la tasa de cambio: ");
                    isValidTasaCambio = validarRangoTasaCambio(valorTasaCambio);
                }

                prepararPantalla();
                string op_DireccionConversion;
                do
                {
                    imprimirMarco(110, 30);
                    Console.SetCursorPosition(15, 5);
                    Console.WriteLine("Lista de opciones de dirección de conversión");
                    Console.SetCursorPosition(15, 6);
                    Console.WriteLine("\t1 - De moneda 1 a moneda 2");
                    Console.SetCursorPosition(15, 7);
                    Console.WriteLine("\t2 - De moneda 2 a moneda 1");
                    Console.SetCursorPosition(15, 8);
                    Console.WriteLine("Seleccione la dirección para la conversión de la moneda: ");
                    Console.SetCursorPosition(15, 9);
                    clearCurrentConsoleLine();
                    op_DireccionConversion = Console.ReadLine();
                } while (!op_DireccionConversion.Equals("1") && !op_DireccionConversion.Equals("2"));
                
                Console.SetCursorPosition(15, 10);
                Conversion objetoConvertior = conversionController.realizarConversion(op_MonedaOrigen, op_MonedaDestino, valorMonedaOrigen, valorTasaCambio, op_DireccionConversion);
                imprimirMarco(110, 30);

                string op_GuardadoInformacion;
                do
                {
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("¿Desea guardar la información de la conversión?");
                    Console.SetCursorPosition(15, 16);
                    Console.WriteLine("\t1 - Si");
                    Console.SetCursorPosition(15, 17);
                    Console.WriteLine("\t2 - No");
                    Console.SetCursorPosition(15, 18);
                    Console.WriteLine("Ingrese la opción: ");
                    Console.SetCursorPosition(15, 19);
                    clearCurrentConsoleLine();
                    op_GuardadoInformacion = Console.ReadLine();
                } while (!op_GuardadoInformacion.Equals("1") && !op_GuardadoInformacion.Equals("2"));

                if (op_GuardadoInformacion == "1")
                {
                    conversionController.registroConversion(objetoConvertior);
                }
                

                Console.SetCursorPosition(15, 25);
                Console.WriteLine("********************************************\n");

                // Esperar a que el usuario responda
                Console.SetCursorPosition(15, 26);
                Console.Write("Presione la tecla 'n' y luego 'Enter' para finalizar,");
                Console.SetCursorPosition(15, 27);
                Console.Write("sino presione 'Enter' para continuar: ");
                if (Console.ReadLine() == "n")
                    endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }

}
