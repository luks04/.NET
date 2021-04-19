using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TallerConversionTiposCsharp
{
    class TypeConvert
    {
        /*
         * CONVERSIONES IMPLICITAS FROM ENTERO TO ...
         */
        public decimal convertFromEnteroToDecimal(int inputNum)
        {
            decimal outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }

        public double convertFromEnteroToDouble(int inputNum)
        {
            double outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }

        public float convertFromEnteroToFloat(int inputNum)
        {
            float outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }

        public long convertFromEnteroToLong(int inputNum)
        {
            long outputNum = 0L;
            outputNum = inputNum;
            return outputNum;
        }

        //*****************************************************
        // *********** ERRORES DE COMPILACION *****************
        //*****************************************************

        /*
        public byte convertFromEnteroToByte(int inputNum)
        {
            byte outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }

        public sbyte convertFromEnteroToSByte(int inputNum)
        {
            sbyte outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }

        public short convertFromEnteroToShort(int inputNum)
        {
            short outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }

        public ushort convertFromEnteroToUShort(int inputNum)
        {
            ushort outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }
        */
        //********************************************************************************************************************************
        /*
         * CONVERSIONES IMPLICITAS FROM DOUBLE TO ...
         */

        //*****************************************************
        // *********** ERRORES DE COMPILACION *****************
        //*****************************************************

        /*
        public byte convertFromDoubleToByte(double inputNum)
        {
            byte outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }
        public int convertFromDoubleToEntero(double inputNum)
        {
            int outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }

        public float convertFromDoubleToFloat(double inputNum)
        {
            float outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }

        public long convertFromDoubleToLong(double inputNum)
        {
            long outputNum = 0L;
            outputNum = inputNum;
            return outputNum;
        }
        */
        //********************************************************************************************************************************
        /*
         * CONVERSIONES IMPLICITAS FROM FLOAT TO ...
         */

        public double convertFromFloatToDouble(float inputNum)
        {
            double outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }

        //*****************************************************
        // *********** ERRORES DE COMPILACION *****************
        //*****************************************************
        
        /*
        public byte convertFromFloatToByte(float inputNum)
        {
            byte outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }
        
        public int convertFromFloatToEntero(float inputNum)
        {
            int outputNum = 0;
            outputNum = inputNum;
            return outputNum;
        }

        public long convertFromFloatToLong(float inputNum)
        {
            long outputNum = 0L;
            outputNum = inputNum;
            return outputNum;
        }
        */
        //********************************************************************************************************************************
        /*
         * CONVERSION FORMATO MONEDA
         */
        public string ConvertirFormatoMoneda(string valorMoneda, NumberStyles style, IFormatProvider culureInfoFormat, string culureInfoFormatString)
        {
            string answer = "";
            try
            {
                switch (culureInfoFormatString){
                    case "es-CO":
                        answer = "\tEn Colombia: ";
                        break;
                    case "en-US":
                         answer = "\tEn Estados Unidos: ";
                        break;
                    case "fr-FR":
                         answer = "\tEn Francia: ";
                        break;
                    case "en-GB":
                         answer = "\tEn Reino Unido: ";
                        break;
                    default:
                        answer = "";
                        break;
                }

                int number = Int32.Parse(valorMoneda, style, culureInfoFormat);
                answer = answer + "El valor de " + valorMoneda + " es " + number;
                return answer;
            }

            catch (FormatException)
            {
                answer = " Imposible convertir " + valorMoneda;
                return answer;
            }

            catch (OverflowException)
            {
                answer = valorMoneda + " esta fuera del rango del tipo Int 32";
                return answer;
            }

        }
    }
}
