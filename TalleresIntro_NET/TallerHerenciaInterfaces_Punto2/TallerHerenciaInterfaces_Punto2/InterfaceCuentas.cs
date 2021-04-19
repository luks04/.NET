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
    public interface InterfaceCuentas
    {
        string Retirar(long cantidadRetiro);
        string SolicitarPrestamo(long cantidadSolicitada);
    }
}
