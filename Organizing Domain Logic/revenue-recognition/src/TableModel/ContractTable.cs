using DataAccess.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace dotnetcore.TableModel {
    public class ContractTable {
        //simulation of database or other storage
        protected DataTable Table;
        public ContractTable(DataSet ds) {
            Table = ds.Tables["Contracts"];
        }
        public IEnumerable<DataRow> GetContractsFor(DateTime date) {
            string filter = $"NextPayment >= #{date.Date.ToString("yyyy/MM/dd")}# AND NextPayment < #{date.Date.AddDays(1).ToString("yyyy/MM/dd")}#";
            return Table.Select(filter).ToList();
        }

        public IEnumerable<DataRow> GetAllContracts() {
            return Table.Select().ToList();
        }

        public void CalculateRevenueRecognition(DateTime date) {
            IEnumerable<DataRow> contracts = GetContractsFor(date);
            ProductTable productTable = new ProductTable(Table.DataSet);
            RevenueRecognition revenueRecognition = new RevenueRecognition(Table.DataSet);
            foreach (var contract in contracts) {
                contract["NextPayment"] = date.AddDays(30);
                DataRow product = productTable.GetProduct((Guid)((Product)contract["Product"]).Id);
                double paidAmount = revenueRecognition.GetTotalPaidAmount((Guid)contract["Id"], date);
                //GetCurrentPrice just for simple example. The main logic can be stored in table store procedures or in flat models like here.
                double price = ((Product)contract["Product"]).GetCurrentPrice(paidAmount, (double)product["Total"]);
                revenueRecognition.Insert((Guid)contract["Id"], price, date);
            }
        }
    }
}
