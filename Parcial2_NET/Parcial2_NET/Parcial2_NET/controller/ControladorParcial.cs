using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Parcial2_NET.dao;
using Parcial2_NET.modelo;

namespace Parcial2_NET.controller
{
    class ControladorParcial
    {

        private static DAOParcial fachadaServiciosDAO;
        private static IConversionMonedas convertidorMonedas;
        public ControladorParcial()
        {
            String cadenaConexion = "";
            cadenaConexion = ConfigurationManager.ConnectionStrings["OrigenDatosSQLServerDemo"].ConnectionString;
            fachadaServiciosDAO = new DAOParcial(cadenaConexion);
        }

        // Métodos de mapeo de opciones
        public string mapNombreMoneda(string op_Moneda)
        {
            string mappedValue = "";
            switch (op_Moneda)
            {
                case "1":
                    mappedValue = "Dólares americanos";
                    break;
                case "2":
                    mappedValue = "Euros";
                    break;
                case "3":
                    mappedValue = "Yuanes(Renminbi)";
                    break;
                case "4":
                    mappedValue = "Yenes japoneses";
                    break;
                case "5":
                    mappedValue = "Pesos colombianos";
                    break;

            }
            return mappedValue;
        }

        //***********************************************
        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool registroConversion(Conversion registro)
        {
            return (fachadaServiciosDAO.insertarConversion(registro));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para realizar la conversion
        public Conversion realizarConversion(string op_MonedaOrigen, string op_MonedaDestino, decimal valorMonedaOrigen, decimal valorTasaCambio, string op_DireccionConversion)
        {
            string nombreMonedaOrigen = mapNombreMoneda(op_MonedaOrigen);
            string nombreMonedaDestino = mapNombreMoneda(op_MonedaDestino);

            Conversion convertidor = new Conversion(nombreMonedaOrigen, nombreMonedaDestino);
            convertidorMonedas = (IConversionMonedas)convertidor;
            convertidorMonedas.convertirEntreMonedas(valorMonedaOrigen, op_DireccionConversion, valorTasaCambio);
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("\n" + convertidorMonedas.obtenerResultadoConversion(nombreMonedaOrigen, nombreMonedaDestino, valorTasaCambio, op_DireccionConversion) + "\n");
            return convertidor;
        }
    }
}
