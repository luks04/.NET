using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NET.modelo
{
    interface IConversionMonedas
    {
        double convertirEntreMonedas(decimal valorOriginal, string direccionConversion, decimal tasaCambio);
        string obtenerResultadoConversion(string nombreMonedaOrigen, string nombreMonedaDestino, decimal tasaCambio, string direccionConversion);
    }
}   
