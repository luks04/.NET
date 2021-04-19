using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAplicacionConsolaADO_NET.controlador;
using TallerAplicacionConsolaADO_NET.dao;

/*
 Maycol Andres Canastero Soler
 Lucas Alejandro Patiño Dorado
 */

namespace TallerAplicacionConsolaADO_NET
{
    class Program
    {

        //Manejo de la pantalla
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
                Console.SetCursorPosition(i, 1);
                System.Console.Write("▓▓");
                Console.SetCursorPosition(i, b);
                System.Console.Write("▓▓");
            }

            for (i = 2; i < b; i++)
            {
                Console.SetCursorPosition(1, i);
                System.Console.Write("▓▓");
                Console.SetCursorPosition(a - 1, i);
                System.Console.Write("▓▓");
            }
        }

        public void mostrarMenuCRUD()
        {
            bool endApp = false;

            while (!endApp)
            {
                string op;
                do
                {
                    prepararPantalla();
                    imprimirMarco(100, 25);
                    Console.SetCursorPosition(15, 5);
                    Console.WriteLine("MENÚ DE OPCIONES DEL GESTOR CRUD DE LA TABLA ORDERS");
                    Console.SetCursorPosition(15, 6);
                    Console.WriteLine("1.  Insertar Registro");
                    Console.SetCursorPosition(15, 7);
                    Console.WriteLine("2.  Modificar Registro");
                    Console.SetCursorPosition(15, 8);
                    Console.WriteLine("3.  Consultar Registro");
                    Console.SetCursorPosition(15, 9);
                    Console.WriteLine("4.  Eliminar Registro");
                    Console.SetCursorPosition(15, 10);
                    Console.WriteLine("5.  Consultar todos los registros");
                    Console.SetCursorPosition(15, 11);
                    Console.WriteLine("6.  Obtener el listado de productos comprados por un cliente");
                    Console.SetCursorPosition(15, 12);
                    Console.Write("Ingrese una opción: ");
                    op = Console.ReadLine();
                } while (!op.Equals("1") && !op.Equals("2") && !op.Equals("3") && !op.Equals("4") && !op.Equals("5") && !op.Equals("6"));

                prepararPantalla();
                ejecutarOpcionCrud(op);

                Console.WriteLine("\nEl programa ha terminado");
                // Esperar a que el usuario responda
                Console.Write("Presione la tecla 'n' y luego 'Enter' para finalizar, sino presione 'Enter' para continuar: ");
                if (Console.ReadLine() == "n")
                    endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
        //**************************************************
        //**************************************************
        //**************************************************
        public void ejecutarOpcionCrud(string opcion)
        {

            Order registro = null;
            bool resultado = false;
            Int32 idOrder = 0;
            string modo = "";
            string idCliente = "";
            ControladorOrders ordersController = new ControladorOrders();

            switch (opcion)
            {
                case "1":
                    registro = ordersController.armarRegistroOrder("crear");
                    resultado = ordersController.registroOrder(registro);
                    break;
                case "2":
                    registro = ordersController.armarRegistroOrder("modificar");
                    resultado = ordersController.modificarOrder(registro);
                    break;
                case "3":
                    idOrder = ordersController.ingresoConsolaEntero("Digite el ID de la orden: ");
                    registro = ordersController.consultarRegistroOrder(idOrder);
                    ordersController.imprimirDatosEntidad(registro);
                    break;
                case "4":
                    idOrder = ordersController.ingresoConsolaEntero("Digite el ID de la orden: ");
                    resultado = ordersController.eliminarOrder(idOrder);
                    break;
                case "5":
                    modo = ordersController.ingresoConsolaString("Ingrese el modo de consulta (asc o desc): ");
                    ordersController.generarListadoOrders(modo);
                    break;
                case "6":
                    idCliente = ordersController.ingresoConsolaString("Ingrese el ID de un cliente: ");
                    ordersController.generarListadoProductosByCliente(idCliente);
                    break;
            }//Fin del switch
        }
        static void Main(string[] args)
        {
            Program nuevoGestorCRUD = new Program();
            nuevoGestorCRUD.mostrarMenuCRUD();
        }
    }
}
