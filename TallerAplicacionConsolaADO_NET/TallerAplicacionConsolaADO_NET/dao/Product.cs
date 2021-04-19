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
    class Product
    {
        private Int32? orderID;
        private Int32 productID;
        private string productName;
        private Int32? supplierID;
        private Int32? categoryID;

        public int? OrderID { get => orderID; set => orderID = value; }
        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int? SupplierID { get => supplierID; set => supplierID = value; }
        public int? CategoryID { get => categoryID; set => categoryID = value; }
    }
}
