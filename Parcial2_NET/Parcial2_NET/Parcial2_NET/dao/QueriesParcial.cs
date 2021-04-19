using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_NET.dao
{
    class QueriesParcial {
        private string querySQL;
        public string generarConsultaInsert()
        {
            this.querySQL =
            "INSERT INTO [dbo].[Conversion] " +
            " ([MonedaOrigen],[MonedaDestino],[ValorOrigen],[ValorDestino],[TasaConversion],[FechaHora]) " +
            " VALUES (@MonedaOrigenP, @MonedaDestinoP, @ValorOrigenP, @ValorDestinoP, @TasaConversionP, @FechaHoraP) ";
            return (this.querySQL);
        }
    }
}
