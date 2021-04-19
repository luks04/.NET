using Parcial2_NET.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NET.dao
{
    class Conversion : IConversionMonedas
    {
        private string monedaOrigen;
        private string monedaDestino;
        private decimal valorOrigen;
        private decimal valorDestino;
        private decimal tasaCambio;
        private DateTime fechaHora;
        private string direccionConversion;

        public Conversion(string monedaOrigen, string monedaDestino)
        {
            MonedaOrigen = monedaOrigen;
            MonedaDestino = monedaDestino;
            ValorOrigen = 0;
            ValorDestino = 0;
            TasaCambio = 0;
            FechaHora = DateTime.Now;
            DireccionConversion = "1"; // "1" o "2"
        }
        public string MonedaOrigen { get => monedaOrigen; set => monedaOrigen = value; }
        public string MonedaDestino { get => monedaDestino; set => monedaDestino = value; }
        public decimal ValorOrigen { get => valorOrigen; set => valorOrigen = value; }
        public decimal ValorDestino { get => valorDestino; set => valorDestino = value; }
        public decimal TasaCambio { get => tasaCambio; set => tasaCambio = value; }
        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public string DireccionConversion { get => direccionConversion; set => direccionConversion = value; }

        
        double IConversionMonedas.convertirEntreMonedas(decimal valorOrigen, string direccionConversion, decimal tasaCambio)
        {
            double valorDestino = 0.0;

            if (direccionConversion == "1") //Origen a Destino, opción 1
            {
                valorDestino = (double)valorOrigen * (double)tasaCambio;
            }
            else if (direccionConversion == "2") //Destino a Origen, opción 2
            {
                valorDestino = (double)valorOrigen / (double)tasaCambio;
            }
            ValorDestino = (decimal)valorDestino;
            ValorOrigen = valorOrigen;
            TasaCambio = tasaCambio;

            return valorDestino;
        }

        string IConversionMonedas.obtenerResultadoConversion(string tipoOrigen, string tipoDestino, decimal tasaCambio, string direccion)
        {

            double valorDestino = (double)ValorDestino;
            double valorBitcoin;
            double valorTasaBitcoin = 0.0;
            if (tipoDestino == "Dólares americanos")
            {
                valorTasaBitcoin = 0.00025;
            }
            else if (tipoDestino == "Euros")
            {
                valorTasaBitcoin = 1.12 * 0.00025;
            }
            else if (tipoDestino == "Yenes(Renminbi)")
            {
                valorTasaBitcoin = 0.15 * 0.00025;
            }
            else if (tipoDestino == "Yenes japoneses")
            {
                valorTasaBitcoin = 0.009 * 0.00025;
            }
            else if (tipoDestino == "Pesos colombianos")
            {
                valorTasaBitcoin = 0.00031 * 0.00025;
            }
            valorBitcoin = valorDestino * valorTasaBitcoin;

            string nombreDireccion = "origen a destino.";
            if (direccion.Equals("2"))
            {
                nombreDireccion = "destino a origen.";
            }

            string mensaje = "\t "+ ValorOrigen + " " + tipoOrigen + " son " + valorDestino + " " + tipoDestino + ".\n\t Usando una tasa de cambio de " + (tasaCambio*100)
                + "%, con dirección de " + nombreDireccion + "\n\t El valor en bitcoin es de " + valorBitcoin + ".";

            return mensaje;
        }
        
    }
}
