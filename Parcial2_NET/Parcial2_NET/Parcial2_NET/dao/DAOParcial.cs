using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Parcial2_NET.dao
{
    class DAOParcial
    {

        private static QueriesParcial generadorQueriesSQL;
        private static SqlConnection connection;
        private static SqlCommand cmd;
        public DAOParcial()
        {
        }

        //Constructor sobrecargado del DAO
        public DAOParcial(string cadenaConexion)
        {
            connection = new SqlConnection(cadenaConexion);
            generadorQueriesSQL = new QueriesParcial();
        }

        //************************************************************************************************************************************************
        //Método para realizar la inserción del registro
        //************************************************************************************************************************************************
        public bool insertarConversion(Conversion registroEntidad)
        {
            bool seInserto = false;
            string consulta = "";
            int totalFilas = 0;

            try
            {
                // Generar Query para realizar el Insert
                consulta = generadorQueriesSQL.generarConsultaInsert();
                //Generamos el comando
                cmd = new SqlCommand(consulta, connection);
                //Abrimos la conexión
                connection.Open();

                //Seteamos los parámetros
                //(@ConversionIDP, @MonedaOrigenP, @MonedaDestinoP, @ValorOrigenP, @ValorDestinoP, @TasaConversionP, @FechaHoraP)
                cmd.Parameters.AddWithValue("@MonedaOrigenP", registroEntidad.MonedaOrigen);
                cmd.Parameters.AddWithValue("@MonedaDestinoP", registroEntidad.MonedaDestino);
                cmd.Parameters.AddWithValue("@ValorOrigenP", registroEntidad.ValorOrigen);
                cmd.Parameters.AddWithValue("@ValorDestinoP", registroEntidad.ValorDestino);
                cmd.Parameters.AddWithValue("@TasaConversionP", registroEntidad.TasaCambio);
                cmd.Parameters.AddWithValue("@FechaHoraP", registroEntidad.FechaHora);

                //Ejecutamos la query de actualización
                totalFilas = cmd.ExecuteNonQuery();
                seInserto = true;

                Console.SetCursorPosition(15, 21);
                Console.WriteLine("*********************************************");
                Console.SetCursorPosition(15, 22);
                Console.WriteLine("Resultado de la inserción: " + seInserto + " - Se insertaron " + totalFilas + " filas en la tabla");
                Console.SetCursorPosition(15, 23);
                Console.WriteLine("*********************************************");
            }

            catch (Exception errorInsertar)
            {
                Console.SetCursorPosition(15, 21);
                Console.WriteLine("Error de inserción: " + errorInsertar.Message);
                Console.SetCursorPosition(15, 22);
                Console.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return (seInserto);
        }
    }
 }
