using DataAccess.Products;
using System;
using System.Data;

namespace dotnetcore.TableModel {
    public class ProductTable {
        protected DataTable Table;
        public ProductTable(DataSet ds) {
            Table = ds.Tables["Products"];
        }

        public DataRow GetProduct(Guid productId) {
            string filter = string.Format("Id = '{0}'", productId);
            return Table.Select(filter)[0];
        }
    }
}