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
    class CuentaComercial : InterfaceCuentas
    {
        private string nombrePropietario_CC;
        private string numeroCuenta;
        private long saldoCuenta;

        public string NombrePropietario_CC { get => nombrePropietario_CC; set => nombrePropietario_CC = value; }
        public long SaldoCuenta { get => saldoCuenta; set => saldoCuenta = value; }
        public string NumeroCuenta { get => numeroCuenta; set => numeroCuenta = value; }

        public CuentaComercial(string numeroCuenta, long saldoCuenta, string nombrePropietario_CC)
        {
            NumeroCuenta = numeroCuenta;
            SaldoCuenta = saldoCuenta;
            NombrePropietario_CC = nombrePropietario_CC;
        }

        string InterfaceCuentas.Retirar(long cantidadRetiro)
        {
            string respuesta = "";
            if (SaldoCuenta < 500000)
            {
                respuesta = "No es posible realizar el retiro porque su saldo es inferior a $500.000";
            }
            else
            {
                SaldoCuenta -= cantidadRetiro;
                respuesta = "Retiro exitoso por un valor de $" + cantidadRetiro + " Saldo actual: $" + SaldoCuenta;
            }
            return respuesta;
        }

        string InterfaceCuentas.SolicitarPrestamo(long cantidadSolicitada)
        {
            string respuesta = "";
            double prestamo = Convert.ToDouble(cantidadSolicitada);
            double bono = cantidadSolicitada * 0.04;
            if (cantidadSolicitada > 1000000)
            {
                prestamo = (cantidadSolicitada * 0.85) + bono; // Retencion del 15% + bono del 4%
            }
            respuesta = "Prestamo exitoso por un valor de $" + prestamo;
            return respuesta;
        }
    }
}
