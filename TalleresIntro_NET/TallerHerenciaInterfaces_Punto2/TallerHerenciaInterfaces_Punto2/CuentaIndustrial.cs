using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    INTREGRANTES
    Lucas Alejandro Patiño Dorado
    Maycol Andres Canastero Soler
*/

namespace TallerHerenciaInterfaces_Punto2
{
    class CuentaIndustrial : InterfaceCuentas
    {
        private string nombrePropietario_CI;
        private string numeroCuenta;
        private long saldoCuenta;

        public long SaldoCuenta { get => saldoCuenta; set => saldoCuenta = value; }
        public string NumeroCuenta { get => numeroCuenta; set => numeroCuenta = value; }
        public string NombrePropietario_CI { get => nombrePropietario_CI; set => nombrePropietario_CI = value; }

        public CuentaIndustrial(string numeroCuenta, long saldoCuenta, string nombrePropietario_CI)
        {
            NumeroCuenta = numeroCuenta;
            SaldoCuenta = saldoCuenta;
            NombrePropietario_CI = nombrePropietario_CI;
        }

        string InterfaceCuentas.Retirar(long valor)
        {
            SaldoCuenta -= valor;
            string mensaje = "Retiro exitoso, el valor retirado fue de $" + valor + " y queda un saldo de $" + SaldoCuenta;
            return mensaje;
        }

        string InterfaceCuentas.SolicitarPrestamo(long cantidad)
        {
            double retencion = 0.0;
            if (cantidad > 2000000)
            {
                retencion = cantidad * 0.25; //Retención del 25%
            }
            double valorPrestamo = cantidad - retencion;
            string respuesta = "Prestamo exitoso por un valor de $" + valorPrestamo;
            return respuesta;
        }
    }
}
