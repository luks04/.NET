using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Maycol Andres Canastero Soler
 Lucas Alejandro Patiño Dorado
 */

namespace TallerAplicacionConsolaADO_NET.dao
{
    class QueriesCRUD
    {
        private string querySQL;
        public string generarConsultaInsert()
        {
            this.querySQL =
            "INSERT INTO [dbo].[Orders] " +
            " ([CustomerID],[EmployeeID],[OrderDate],[RequiredDate],[ShippedDate],[ShipVia],[Freight],[ShipName],[ShipAddress],[ShipCity],[ShipRegion],[ShipPostalCode],[ShipCountry]) " +
            " VALUES (@CustomerIDP, @EmployeeIDP, @OrderDateP, @RequiredDateP, @ShippedDateP, @ShipViaP, @FreightP, @ShipNameP, @ShipAddressP, @ShipCityP, @ShipRegionP, @ShipPostalCodeP, @ShipCountryP) ";
            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaUpdate()
        {
            this.querySQL =
            "UPDATE [dbo].[Orders] " +
            "   SET [CustomerID] = @CustomerIDP " +
            "      ,[EmployeeID] = @EmployeeIDP " +
            "      ,[OrderDate] = @OrderDateP " +
            "      ,[RequiredDate] = @RequiredDateP " +
            "      ,[ShippedDate] = @ShippedDateP " +
            "      ,[ShipVia] = @ShipViaP " +
            "      ,[Freight] = @FreightP " +
            "      ,[ShipName] = @ShipNameP " +
            "      ,[ShipAddress] = @ShipAddressP " +
            "      ,[ShipCity] = @ShipCityP " +
            "      ,[ShipRegion] = @ShipRegionP " +
            "      ,[ShipPostalCode] = @ShipPostalCodeP " +
            "      ,[ShipCountry] = @ShipCountryP " +
            "   WHERE [OrderID] = @OrderIDP ";
            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaSelect()
        {
            this.querySQL =
            "SELECT [OrderID] " +
            "   ,[CustomerID] " +
            "   ,[EmployeeID] " +
            "   ,[OrderDate] " +
            "   ,[RequiredDate] " +
            "   ,[ShippedDate] " +
            "   ,[ShipVia] " +
            "   ,[Freight] " +
            "   ,[ShipName] " +
            "   ,[ShipAddress] " +
            "   ,[ShipCity] " +
            "   ,[ShipRegion] " +
            "   ,[ShipPostalCode] " +
            "   ,[ShipCountry] " +
            "     FROM[dbo].[Orders] " +
            "WHERE [OrderID] = @OrderIDP ";

            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaDelete()
        {
            this.querySQL =
            "DELETE FROM[dbo].[Orders] " +
            "  WHERE [OrderId] = @OrderIdP ";
            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaTodosRegistros(string modo)
        {
            this.querySQL =
            "SELECT[OrderID] " +
            "   ,[CustomerID] " +
            "   ,[EmployeeID] " +
            "   ,[OrderDate] " +
            "   ,[RequiredDate] " +
            "   ,[ShippedDate] " +
            "   ,[ShipVia] " +
            "   ,[Freight] " +
            "   ,[ShipName] " +
            "   ,[ShipAddress] " +
            "   ,[ShipCity] " +
            "   ,[ShipRegion] " +
            "   ,[ShipPostalCode] " +
            "   ,[ShipCountry] " +
            "     FROM[dbo].[Orders] " +
            " ORDER BY [OrderID] " + modo;

            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaProductosByCliente(string clienteID)
        {
            this.querySQL =
            "SELECT O.OrderID, P.ProductID, P.ProductName, P.SupplierID, P.CategoryID " +
            "FROM Products P, Customers C, Orders O, [Order Details] OD " +
            "WHERE(C.CustomerID = O.CustomerID AND O.OrderID = OD.OrderID AND OD.ProductID = P.ProductID) " +
            "AND(O.CustomerID = '" + clienteID + "')";

            return (this.querySQL);
        }
    }
}
