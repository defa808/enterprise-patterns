using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore.TableModel {
    public class RevenueRecognition {
        protected DataTable Table;
        public RevenueRecognition(DataSet ds) {
            Table = ds.Tables["RevenueRecognition"];
        }

        public Guid Insert(Guid contractId, double sum, DateTime date) {
            DataRow newRow = Table.NewRow();
            Guid id = Guid.NewGuid();
            newRow["Id"] = id;
            newRow["ContractId"] = contractId;
            newRow["Amount"] = sum;
            newRow["Date"] = string.Format("{0:s}", date);
            Table.Rows.Add(newRow);
            return id;
        }

        public double GetTotalPaidAmount(Guid contractId, DateTime date) {
            string filter = string.Format("contractId = '{0}' AND date <= #{1:d}#", contractId, date);
            var rows = Table.Select(filter);
            return rows.Sum(row => double.Parse(row["Amount"].ToString()));
        }
    }
}
