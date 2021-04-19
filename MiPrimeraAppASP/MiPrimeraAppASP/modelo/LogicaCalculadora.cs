using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPrimeraAppASP.modelo
{
    //***********************************************************************
    //***********************************************************************
    //***********************************************************************
    public class LogicaCalculadora
    {
        //Encapsular los datos
        private double numero1;
        private double numero2;
        private double resultado;

        public double Numero1 { get => numero1; set => numero1 = value; }
        public double Numero2 { get => numero2; set => numero2 = value; }
        public double Resultado { get => resultado; set => resultado = value; }

        //*****************************************************************
        //*****************************************************************
        //*****************************************************************
        public double EjecutarOperacion(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

            System.Console.WriteLine("Primer valor de la operación: {0}", num1);
            System.Console.WriteLine("segundo valor de la operación: {0}", num2);
            System.Console.WriteLine("Operador " + op);

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        result = 0.0;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }

            return result;
        }
        //*****************************************************************
        //*****************************************************************
        //*****************************************************************
    }
    //***********************************************************************
    //***********************************************************************
    //***********************************************************************

}