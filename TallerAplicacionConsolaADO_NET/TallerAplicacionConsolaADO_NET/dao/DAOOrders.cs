using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data;

/*
 Maycol Andres Canastero Soler
 Lucas Alejandro Patiño Dorado
 */

namespace TallerAplicacionConsolaADO_NET.dao
{
    class DAOOrders
    {

        private static QueriesCRUD generadorQueriesSQL;
        private static SqlConnection connection;
        private static SqlCommand cmd;
        public DAOOrders()
        {
        }

        //Constructor sobrecargado del DAO
        public DAOOrders(string cadenaConexion)
        {
            connection = new SqlConnection(cadenaConexion);
            Console.WriteLine("»»» Conexión establecida: " + connection + " «««\n");
            generadorQueriesSQL = new QueriesCRUD();
        }

        //************************************************************************************************************************************************
        //Método para realizar la inserción del registro
        //************************************************************************************************************************************************
        public bool insertarRegistroOrder(Order registroEntidad)
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
                //(@CustomerIDP, @EmployeeIDP, @OrderDateP, @RequiredDateP, @ShippedDateP, @ShipViaP, @FreightP, @ShipNameP, @ShipAddressP, @ShipCityP, @ShipRegionP, @ShipPostalCodeP, @ShipCountryP)
                cmd.Parameters.AddWithValue("@CustomerIDP", registroEntidad.CustomerID);
                cmd.Parameters.AddWithValue("@EmployeeIDP", registroEntidad.EmployeeID);
                cmd.Parameters.AddWithValue("@OrderDateP", registroEntidad.OrderDate);
                cmd.Parameters.AddWithValue("@RequiredDateP", registroEntidad.RequiredDate);
                cmd.Parameters.AddWithValue("@ShippedDateP", registroEntidad.ShippedDate);
                cmd.Parameters.AddWithValue("@ShipViaP", registroEntidad.ShipVia);
                cmd.Parameters.AddWithValue("@FreightP", registroEntidad.Freight);
                cmd.Parameters.AddWithValue("@ShipNameP", registroEntidad.ShipName);
                cmd.Parameters.AddWithValue("@ShipAddressP", registroEntidad.ShipAddress);
                cmd.Parameters.AddWithValue("@ShipCityP", registroEntidad.ShipCity);
                cmd.Parameters.AddWithValue("@ShipRegionP", registroEntidad.ShipRegion);
                cmd.Parameters.AddWithValue("@ShipPostalCodeP", registroEntidad.ShipPostalCode);
                cmd.Parameters.AddWithValue("@ShipCountryP", registroEntidad.ShipCountry);

                //Ejecutamos la query de actualización
                totalFilas = cmd.ExecuteNonQuery();
                seInserto = true;
                
                Console.WriteLine("Resultado de la inserción: " + seInserto + " - Se insertaron " + totalFilas + " filas en la tabla");
                Console.WriteLine("*********************************************");
                Console.WriteLine("*********************************************");
            }

            catch (Exception errorInsertar)
            {
                Console.WriteLine("Error de inserción: " + errorInsertar.Message);
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
        //************************************************************************************************************************************************
        //Método para realizar la modificación del registro
        //************************************************************************************************************************************************
        public bool actualizarRegistroOrder(Order registroEntidad)
        {
            bool seModifico = false;
            string consulta = "";
            int totalFilas = 0;

            try
            {
                consulta = generadorQueriesSQL.generarConsultaUpdate();
                //Generamos el comando
                cmd = new SqlCommand(consulta, connection);
                //Abrimos la conexión
                connection.Open();
                //********************************************************************
                //********************************************************************
                //Seteamos los parámetros
                cmd.Parameters.AddWithValue("@CustomerIDP", registroEntidad.CustomerID);
                cmd.Parameters.AddWithValue("@EmployeeIDP", registroEntidad.EmployeeID);
                cmd.Parameters.AddWithValue("@OrderDateP", registroEntidad.OrderDate);
                cmd.Parameters.AddWithValue("@RequiredDateP", registroEntidad.RequiredDate);
                cmd.Parameters.AddWithValue("@ShippedDateP", registroEntidad.ShippedDate);
                cmd.Parameters.AddWithValue("@ShipViaP", registroEntidad.ShipVia);
                cmd.Parameters.AddWithValue("@FreightP", registroEntidad.Freight);
                cmd.Parameters.AddWithValue("@ShipNameP", registroEntidad.ShipName);
                cmd.Parameters.AddWithValue("@ShipAddressP", registroEntidad.ShipAddress);
                cmd.Parameters.AddWithValue("@ShipCityP", registroEntidad.ShipCity);
                cmd.Parameters.AddWithValue("@ShipRegionP", registroEntidad.ShipRegion);
                cmd.Parameters.AddWithValue("@ShipPostalCodeP", registroEntidad.ShipPostalCode);
                cmd.Parameters.AddWithValue("@ShipCountryP", registroEntidad.ShipCountry);

                //Llave para el update
                cmd.Parameters.AddWithValue("@OrderIDP", registroEntidad.OrderID);

                //Ejecutamos la query de actualización
                totalFilas = cmd.ExecuteNonQuery();
                seModifico = true;

                Console.WriteLine("Resultado de la modificación: " + seModifico + " - Se modificaron " + totalFilas + " filas en la tabla");
                Console.WriteLine("*********************************************");
                Console.WriteLine("*********************************************");
            }

            catch (Exception errorInsertar)
            {
                Console.WriteLine("Error de modificación: " + errorInsertar.Message);
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

            return (seModifico);
        }
        //************************************************************************************************************************************************
        // Método para eliminar registro
        //************************************************************************************************************************************************
        public bool eliminarRegistroOrder(int idOrder)
        {
            bool seElimino = false;
            string consulta = "";

            try
            {
                consulta = generadorQueriesSQL.generarConsultaDelete();
                cmd = new SqlCommand(consulta, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@OrderIDP", idOrder);
                cmd.ExecuteNonQuery();
                seElimino = true;
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("El registro con ID " + idOrder + " se borró: " + seElimino);
                Console.WriteLine("-------------------------------------------------------------------");
            }

            catch (Exception errorInsertar)
            {
                Console.WriteLine("Error de eliminación: " + errorInsertar.Message);
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

            return (seElimino);
        }
        //************************************************************************************************************************************************
        // Método para consultar registro por ID (OrderID)
        //************************************************************************************************************************************************
        public Order consultarRegistroOrder(int idOrder)
        {
            Order registroConsultado = new Order();
            string consulta = "";
            SqlCommand command = null;
            SqlDataReader cursor = null;

            try
            {
                consulta = generadorQueriesSQL.generarConsultaSelect();

                connection.Open();
                command = new SqlCommand(consulta, connection);
                Console.WriteLine("\nID DE ORDEN A CONSULTAR: " + idOrder);
                command.Parameters.AddWithValue("@OrderIDP", idOrder);

                //Recorremos el cursor de la consulta para obtener los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        registroConsultado.OrderID = cursor.GetInt32(0);
                        registroConsultado.CustomerID = cursor.IsDBNull(1) ? null : cursor.GetString(1);
                        registroConsultado.EmployeeID = cursor.IsDBNull(2) ? -1 : cursor.GetInt32(2);
                        registroConsultado.OrderDate = cursor.IsDBNull(3) ? new DateTime() : cursor.GetDateTime(3);
                        registroConsultado.RequiredDate = cursor.IsDBNull(4) ? new DateTime() : cursor.GetDateTime(4);
                        registroConsultado.ShippedDate = cursor.IsDBNull(5) ? new DateTime() : cursor.GetDateTime(5);
                        registroConsultado.ShipVia = cursor.IsDBNull(6) ? -1 : cursor.GetInt32(6);
                        registroConsultado.Freight = cursor.IsDBNull(7) ? -1 : cursor.GetDecimal(7);
                        registroConsultado.ShipName = cursor.IsDBNull(8) ? null : cursor.GetString(8);
                        registroConsultado.ShipAddress = cursor.IsDBNull(9) ? null : cursor.GetString(9);
                        registroConsultado.ShipCity = cursor.IsDBNull(10) ? null : cursor.GetString(10);
                        registroConsultado.ShipRegion = cursor.IsDBNull(11) ? null : cursor.GetString(11);
                        registroConsultado.ShipPostalCode = cursor.IsDBNull(12) ? null : cursor.GetString(12);
                        registroConsultado.ShipCountry = cursor.IsDBNull(13) ? null : cursor.GetString(13);
                    }
                }
            }

            catch (Exception errorLectura)
            {
                Console.WriteLine("Error de consulta: " + errorLectura.Message);
                Order registroVacio = new Order();
                registroVacio.OrderID = 0;
                return (registroVacio);
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
            
            return (registroConsultado);
        }
        //************************************************************************************************************************************************
        // Método para generar un listado de todos los registros
        //************************************************************************************************************************************************
        public List<Order> generarListadoOrders(string modo)
        {
            List<Order> registros = new List<Order>();
            Order registroConsultado = null;
            string consulta = "";
            SqlCommand command = null;
            SqlDataReader cursor = null;
            try
            {
                consulta = generadorQueriesSQL.generarConsultaTodosRegistros(modo);

                connection.Open();
                command = new SqlCommand(consulta, connection);

                //Recorremos el cursor de la consulta para obtener
                //los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        registroConsultado = new Order();
                        registroConsultado.OrderID = cursor.GetInt32(0);
                        registroConsultado.CustomerID = cursor.IsDBNull(1) ? null : cursor.GetString(1);
                        registroConsultado.EmployeeID = cursor.IsDBNull(2) ? -1 : cursor.GetInt32(2);
                        registroConsultado.OrderDate = cursor.IsDBNull(3) ? new DateTime() : cursor.GetDateTime(3);
                        registroConsultado.RequiredDate = cursor.IsDBNull(4) ? new DateTime() : cursor.GetDateTime(4);
                        registroConsultado.ShippedDate = cursor.IsDBNull(5) ? new DateTime() : cursor.GetDateTime(5);
                        registroConsultado.ShipVia = cursor.IsDBNull(6) ? -1 : cursor.GetInt32(6);
                        registroConsultado.Freight = cursor.IsDBNull(7) ? -1 : cursor.GetDecimal(7);
                        registroConsultado.ShipName = cursor.IsDBNull(8) ? null : cursor.GetString(8);
                        registroConsultado.ShipAddress = cursor.IsDBNull(9) ? null : cursor.GetString(9);
                        registroConsultado.ShipCity = cursor.IsDBNull(10) ? null : cursor.GetString(10);
                        registroConsultado.ShipRegion = cursor.IsDBNull(11) ? null : cursor.GetString(11);
                        registroConsultado.ShipPostalCode = cursor.IsDBNull(12) ? null : cursor.GetString(12);
                        registroConsultado.ShipCountry = cursor.IsDBNull(13) ? null : cursor.GetString(13);

                        registros.Add(registroConsultado);
                    }

                    //Verificamos los datos
                    Console.WriteLine("****************************************************************");
                    Console.WriteLine("****************************************************************");
                    Console.WriteLine("ID ORDEN = " + registroConsultado.OrderID);
                    Console.WriteLine("****************************************************************");
                    Console.WriteLine("****************************************************************");

                }
            }

            catch (Exception errorLectura)
            {
                Console.WriteLine("Error de consulta: " + errorLectura.Message);
                List<Order> vacios = new List<Order>();
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
        // Método para generar un listado de los productos asociados a un cliente
        //************************************************************************************************************************************************
        public List<Product> generarListadoProductosByCliente(string cliente)
        {
            List<Product> registros = new List<Product>();
            Product registroConsultado = null;
            string consulta = "";
            SqlCommand command = null;
            SqlDataReader cursor = null;

            try
            {
                consulta = generadorQueriesSQL.generarConsultaProductosByCliente(cliente);

                connection.Open();
                command = new SqlCommand(consulta, connection);

                //Recorremos el cursor de la consulta para obtener
                //los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        registroConsultado = new Product();
                        registroConsultado.OrderID = cursor.IsDBNull(0) ? -1 : cursor.GetInt32(0);
                        registroConsultado.ProductID = cursor.GetInt32(1);
                        registroConsultado.ProductName = cursor.IsDBNull(2) ? null : cursor.GetString(2);
                        registroConsultado.SupplierID = cursor.IsDBNull(3) ? -1 : cursor.GetInt32(3);
                        registroConsultado.CategoryID = cursor.IsDBNull(4) ? -1 : cursor.GetInt32(4);

                        registros.Add(registroConsultado);
                    }
                }
            }

            catch (Exception errorLectura)
            {
                Console.WriteLine("Error de consulta: " + errorLectura.Message);
                List<Product> vacios = new List<Product>();
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
    }
}
