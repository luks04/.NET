using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ParcialJuego.dao
{
    class DAOJuegoParcial
    {
        private string querySQL;
        private static SqlConnection connection;
        private static SqlCommand cmd;
        public DAOJuegoParcial()
        {
        }

        //Constructor sobrecargado del DAO
        public DAOJuegoParcial(string cadenaConexion)
        {
            connection = new SqlConnection(cadenaConexion);
            Console.WriteLine("»»» Conexión establecida: " + connection + " «««\n");
        }

        //************************************************************************************************************************************************
        // Consultas SQL
        //************************************************************************************************************************************************

        public string generarConsultaSelect_PalabraCifrar()
        {
            this.querySQL =
            "SELECT [palabra] " +
            "       , [categoria] " +
            "     FROM[dbo].[PalabraCifrar] " +
            "WHERE [ronda] = @rondaP";

            return (this.querySQL);
        }

        public string generarConsultaSelect_LetraPista()
        {
            this.querySQL =
            "SELECT [letra] " +
            "     FROM[dbo].[LetraPista] ";

            return (this.querySQL);
        }

        //************************************************************************************************************************************************
        // Método para consultar palabra para cifrar
        //************************************************************************************************************************************************
        public (string, string) consultarPalabrasParaCifrar(int ronda)
        {
            List<PalabraCifrar> ListaPalabrasConsulta = new List<PalabraCifrar>();
            string consulta = "";
            SqlCommand command = null;
            SqlDataReader cursor = null;
            string resultadoPalabra = "";
            string categoriaPalabra = "";

            try
            {
                consulta = generarConsultaSelect_PalabraCifrar();

                connection.Open();
                command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@rondaP", ronda);

                //Recorremos el cursor de la consulta para obtener los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        PalabraCifrar registroConsultado = new PalabraCifrar();
                        registroConsultado.Palabra = cursor.GetString(0).Trim();
                        registroConsultado.Categoria = cursor.GetString(1).Trim();
                        ListaPalabrasConsulta.Add(registroConsultado);
                    }
                }
                var rand = new Random();
                int tamLista = ListaPalabrasConsulta.Count();
                int randomPosition = rand.Next(0, tamLista);
                resultadoPalabra = ListaPalabrasConsulta[randomPosition].Palabra;
                categoriaPalabra = ListaPalabrasConsulta[randomPosition].Categoria;
            }

            catch (Exception errorLectura)
            {
                Console.WriteLine("Error de consulta: " + errorLectura.Message);
            }

            finally
            {
                //Libera los recursos de la transacción DML de consulta
                if (command != null)
                {
                    command.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return (resultadoPalabra, categoriaPalabra);
        }
        //************************************************************************************************************************************************
        // Método para generar un listado de todos los registros
        //************************************************************************************************************************************************
        public List<LetraPista> generarListadoLetrasPistas()
        {
            List<LetraPista> registros = new List<LetraPista>();
            LetraPista registroConsultado = null;
            string consulta = "";
            SqlCommand command = null;
            SqlDataReader cursor = null;
            try
            {
                consulta = generarConsultaSelect_LetraPista();

                connection.Open();
                command = new SqlCommand(consulta, connection);

                //Recorremos el cursor de la consulta para obtener
                //los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        registroConsultado = new LetraPista();
                        registroConsultado.Letra = cursor.GetString(0);
                        registros.Add(registroConsultado);
                    }

                }
            }

            catch (Exception errorLectura)
            {
                Console.WriteLine("Error de consulta: " + errorLectura.Message);
                List<LetraPista> vacios = new List<LetraPista>();
                return (vacios);
            }

            finally
            {
                //Libera los recursos de la transacción DML de consulta
                if (command != null)
                {
                    command.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return (registros);
        }
        //************************************************************************************************************************************************
        // Método para consultar palabras para coincidencia
        //************************************************************************************************************************************************
        public List<PalabraCifrar> consultarListaPalabras(int ronda)
        {
            List<PalabraCifrar> ListaPalabrasConsulta = new List<PalabraCifrar>();
            string consulta = "";
            SqlCommand command = null;
            SqlDataReader cursor = null;

            try
            {
                consulta = generarConsultaSelect_PalabraCifrar();

                connection.Open();
                command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@rondaP", ronda);

                //Recorremos el cursor de la consulta para obtener los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        PalabraCifrar registroConsultado = new PalabraCifrar();
                        registroConsultado.Palabra = cursor.GetString(0).Trim();
                        registroConsultado.Categoria = cursor.GetString(1).Trim();
                        ListaPalabrasConsulta.Add(registroConsultado);
                    }
                }
            }

            catch (Exception errorLectura)
            {
                Console.WriteLine("Error de consulta: " + errorLectura.Message);
            }

            finally
            {
                //Libera los recursos de la transacción DML de consulta
                if (command != null)
                {
                    command.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return ListaPalabrasConsulta;
        }
    }
}
