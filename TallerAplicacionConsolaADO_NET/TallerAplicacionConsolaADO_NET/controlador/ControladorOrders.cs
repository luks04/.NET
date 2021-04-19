using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAplicacionConsolaADO_NET.dao;
using System.Configuration;
using System.Globalization;
using System.Data;

/*
 Maycol Andres Canastero Soler
 Lucas Alejandro Patiño Dorado
 */

namespace TallerAplicacionConsolaADO_NET.controlador
{
    class ControladorOrders
    {

        private static DAOOrders fachadaServiciosDAO;
        public ControladorOrders()
        {
            String cadenaConexion = "";
            cadenaConexion = ConfigurationManager.ConnectionStrings["OrigenDatosSQLServerDemo"].ConnectionString;
            //Console.WriteLine("Cadena conexion: " + cadenaConexion);
            fachadaServiciosDAO = new DAOOrders(cadenaConexion);
        }

        // Metodos validacion datos
        public bool validarNumerosDecimales(string valor)
        {
            string[] array = valor.Split(',');
            if (array.Length >= 2)
            {
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

        public decimal ingresoConsolaDecimal(string mensaje)
        {
            bool valid_1 = false;
            decimal valorDecimal = 0;
            while (!valid_1)
            {
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

        public bool validarNumerosInt(string valor)
        {
            try
            {
                int.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int convertirToInt(string valor)
        {
            int resultado = Int32.Parse(valor);
            return resultado;
        }

        public int ingresoConsolaEntero(string mensaje)
        {
            bool valid_1 = false;
            int valorEntero = 0;
            while (!valid_1)
            {
                Console.Write(mensaje);
                string inputInt = System.Console.ReadLine();
                bool valid_2 = validarNumerosInt(inputInt);
                if (valid_2)
                {
                    valorEntero = convertirToInt(inputInt);
                    valid_1 = true;
                }
            }
            return valorEntero;
        }

        public string ingresoConsolaString(string mensaje)
        {
            bool valid_1 = false;
            string valorString = "";
            while (!valid_1)
            {
                Console.Write(mensaje);
                string inputString = System.Console.ReadLine();
                if (inputString.Length != 0)
                {
                    valorString = inputString;
                    valid_1 = true;
                }
            }
            return valorString;
        }

        public DateTime ingresoConsolaDateTime(string mensaje)
        {
            bool valid_1 = false;
            DateTime valorFecha = DateTime.Now;
            while (!valid_1)
            {
                Console.WriteLine("Recuerde que el formato para ingreso de la fecha es dd/mm/yyyy");
                Console.Write(mensaje);
                string inputString = System.Console.ReadLine();
                string[] arrayInputString = inputString.Split('/');
                if (arrayInputString.Length == 3)
                {
                    if (convertirToInt(arrayInputString[0]) >= 1 && convertirToInt(arrayInputString[0]) <= 31)
                    {
                        if (convertirToInt(arrayInputString[1]) >= 1 && convertirToInt(arrayInputString[1]) <= 12)
                        {
                            if (convertirToInt(arrayInputString[2]) >= 1990)
                            {
                                valorFecha = DateTime.Parse(inputString, CultureInfo.InvariantCulture);
                                valid_1 = true;
                            }
                            else {
                                Console.WriteLine("Recuerde que debe ingresar el año, el valor admitido debe ser mayor a 1990");
                            }
                        }
                        else {
                            Console.WriteLine("Recuerde que debe ingresar el mes, el valor admitido esta entre 1 y 12");
                        }
                    } 
                    else {
                        Console.WriteLine("Recuerde que debe ingresar el día, el valor admitido esta entre 1 y 31");
                    }

                }
            }
            return valorFecha;
        }

        //***********************************************
        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool registroOrder(Order registro)
        {
            return (fachadaServiciosDAO.insertarRegistroOrder(registro));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool modificarOrder(Order registro)
        {
            return (fachadaServiciosDAO.actualizarRegistroOrder(registro));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool eliminarOrder(int idOrder)
        {
            return (fachadaServiciosDAO.eliminarRegistroOrder(idOrder));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para consultar el registro
        public Order consultarRegistroOrder(int idOrder)
        {
            return (fachadaServiciosDAO.consultarRegistroOrder(idOrder));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        public void generarListadoOrders(string modo)
        {
            List<Order> registrosOrders = null;
            registrosOrders = fachadaServiciosDAO.generarListadoOrders(modo);
            imprimirRegistros(registrosOrders);
        }
        //***********************************************
        //***********************************************
        //***********************************************
        public void generarListadoProductosByCliente(string cliente)
        {
            List<Product> registrosProductos = null;
            registrosProductos = fachadaServiciosDAO.generarListadoProductosByCliente(cliente);
            imprimirRegistrosProductosByCliente(registrosProductos);
        }
        //***********************************************
        //***********************************************
        //***********************************************
        public Order armarRegistroOrder(string tipo)
        {
            Order registroOrder = new Order();

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("INGRESO DE LOS DATOS DEL REGISTRO");

            if (tipo.Equals("modificar"))
            {
                registroOrder.OrderID = ingresoConsolaEntero("Ingrese el valor del campo OrderID: ");
            }

            registroOrder.CustomerID = ingresoConsolaString("Ingrese el valor del campo CustomerID: ");
            registroOrder.EmployeeID = ingresoConsolaEntero("Ingrese el valor del campo EmployeeID: ");
            registroOrder.OrderDate = ingresoConsolaDateTime("Ingrese el valor del campo OrderDate: ");
            registroOrder.RequiredDate = ingresoConsolaDateTime("Ingrese el valor del campo RequiredDate: ");
            registroOrder.ShippedDate = ingresoConsolaDateTime("Ingrese el valor del campo ShippedDate: ");
            registroOrder.ShipVia = ingresoConsolaEntero("Ingrese el valor del campo ShipVia: ");
            registroOrder.Freight = ingresoConsolaDecimal("Ingrese el valor del campo Freight: ");
            registroOrder.ShipName = ingresoConsolaString("Ingrese el valor del campo ShipName: ");
            registroOrder.ShipAddress = ingresoConsolaString("Ingrese el valor del campo ShipAddress: ");
            registroOrder.ShipCity = ingresoConsolaString("Ingrese el valor del campo ShipCity: ");
            registroOrder.ShipRegion = ingresoConsolaString("Ingrese el valor del campo ShipRegion: ");
            registroOrder.ShipPostalCode = ingresoConsolaString("Ingrese el valor del campo ShipPostalCode: ");
            registroOrder.ShipCountry = ingresoConsolaString("Ingrese el valor del campo ShipCountry: ");


            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("-----------------------------------------------");

            return (registroOrder);
        }
        //***********************************************
        //***********************************************
        //***********************************************
        public void imprimirDatosEntidad(Order registroOrder)
        {
            if(registroOrder.OrderID == 0)
            {
                Console.WriteLine("\n*******************************************************88******");
                Console.WriteLine("**** EL registro no existe actualmente en la base de datos ****");
                Console.WriteLine("***************************************************************\n");
            }
            else
            {
                Console.WriteLine("\n************************************************************");
                Console.WriteLine("************************************************************");
                Console.WriteLine("************************************************************");
                Console.WriteLine("*** OrderID: " + registroOrder.OrderID);
                Console.WriteLine("*** CustomerID: " + (registroOrder.CustomerID ?? "NULL"));
                Console.WriteLine("*** EmployeeID: " + (registroOrder.EmployeeID == -1 ? "NULL" : registroOrder.EmployeeID.ToString()));
                Console.WriteLine("*** OrderDate: " + (registroOrder.OrderDate == new DateTime() ? "NULL" : registroOrder.OrderDate.ToString()));
                Console.WriteLine("*** RequiredDate: " + (registroOrder.RequiredDate == new DateTime() ? "NULL" : registroOrder.RequiredDate.ToString()));
                Console.WriteLine("*** ShippedDate: " + (registroOrder.ShippedDate == new DateTime() ? "NULL" : registroOrder.ShippedDate.ToString()));
                Console.WriteLine("*** ShipVia: " + (registroOrder.ShipVia == -1 ? "NULL" : registroOrder.EmployeeID.ToString()));
                Console.WriteLine("*** Freight: " + (registroOrder.Freight == -1 ? "NULL" : registroOrder.EmployeeID.ToString()));
                Console.WriteLine("*** ShipName: " + (registroOrder.ShipName ?? "NULL"));
                Console.WriteLine("*** ShipAddress: " + (registroOrder.ShipAddress ?? "NULL"));
                Console.WriteLine("*** ShipCity: " + (registroOrder.ShipCity ?? "NULL"));
                Console.WriteLine("*** ShipRegion: " + (registroOrder.ShipRegion ?? "NULL"));
                Console.WriteLine("*** ShipPostalCode: " + (registroOrder.ShipPostalCode ?? "NULL"));
                Console.WriteLine("*** ShipCountry: " + (registroOrder.ShipCountry ?? "NULL"));
                Console.WriteLine("************************************************************");
                Console.WriteLine("************************************************************");
                Console.WriteLine("************************************************************\n");
            }
        }
        //***********************************************
        //***********************************************
        //***********************************************
        
        public void imprimirRegistros(List<Order> registros)
        {
            int i = 0;
            string salida = "";
            Order registro = null;

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");

            salida = "OrderID \t" +
                            "|" +
                            "CustomerID\t" +
                            "|" +
                            "EmployeeID\t" +
                            "|" +
                            "OrderDate\t" +
                            "|" +
                            "RequiredDate\t" +
                            "|" +
                            "ShippedDate\t" +
                            "|" +
                            "ShipVia\t" +
                            "|" +
                            "Freight\t" +
                            "|" +
                            "ShipName\t" +
                            "|" +
                            "ShipAddress\t" +
                            "|" +
                            "ShipCity\t" +
                            "|" +
                            "ShipRegion\t" +
                            "|" +
                            "ShipPostalCode\t" +
                            "|" +
                            "ShipCountry \n";

            for (i = 0; i < registros.Count; i++)
            {
                registro = (Order)registros.ElementAt(i);
                //*****************************************
                //*****************************************
                salida += registro.OrderID + "\t" +
                                (registro.CustomerID ?? "NULL") + "\t" +
                                "|" +
                                (registro.EmployeeID == -1 ? "NULL" : registro.EmployeeID.ToString()) + "\t" +
                                "|" +
                                (registro.OrderDate == new DateTime() ? "NULL" : registro.OrderDate.ToString()) + "\t" +
                                "|" +
                                (registro.RequiredDate == new DateTime() ? "NULL" : registro.RequiredDate.ToString()) + "\t" +
                                "|" +
                                (registro.ShippedDate == new DateTime() ? "NULL" : registro.ShippedDate.ToString()) + "\t" +
                                "|" +
                                (registro.ShipVia == -1 ? "NULL" : registro.ShipVia.ToString()) + "\t" +
                                "|" +
                                (registro.Freight == -1 ? "NULL" : registro.Freight.ToString()) + "\t" +
                                "|" +
                                (registro.ShipName ?? "NULL") + "\t" +
                                "|" +
                                (registro.ShipAddress ?? "NULL") + "\t" +
                                "|" +
                                (registro.ShipCity ?? "NULL") + "\t" +
                                "|" +
                                (registro.ShipPostalCode ?? "NULL") + "\t" +
                                "|" +
                                (registro.ShipCountry ?? "NULL") + "\n";
                //*****************************************
                //*****************************************
            }
            Console.Write(salida);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
        }

        public void imprimirRegistrosProductosByCliente(List<Product> registros)
        {
            int i = 0;
            string salida = "";
            Product registro = null;

            Console.WriteLine("\n TABLA DE PRODUCTOS COMPRADOS POR UN CLIENTE\n");

            Console.WriteLine(String.Format("|{0,-10}+{1,-10}+{2,-50}+{3,-14}+{4,-14}|", "----------", "----------", "--------------------------------------------------", "--------------", "--------------"));
            Console.WriteLine(String.Format("|{0,-10}|{1,-10}|{2,-50}|{3,-14}|{4,-14}|", "OrderID", "ProductID", "ProductName", "SupplierID", "CategoryID"));
            Console.WriteLine(String.Format("|{0,-10}+{1,-10}+{2,-50}+{3,-14}+{4,-14}|", "----------", "----------", "--------------------------------------------------", "--------------", "--------------"));

            for (i = 0; i < registros.Count; i++)
            {
                registro = (Product)registros.ElementAt(i);
                Console.WriteLine(String.Format("|{0,-10}|{1,-10}|{2,-50}|{3,-14}|{4,-14}|", registro.OrderID, registro.ProductID, registro.ProductName, registro.SupplierID, registro.CategoryID));
                Console.WriteLine(String.Format("|{0,-10}+{1,-10}+{2,-50}+{3,-14}+{4,-14}|", "----------", "----------", "--------------------------------------------------", "--------------", "--------------"));

            }
        }

    }
}
