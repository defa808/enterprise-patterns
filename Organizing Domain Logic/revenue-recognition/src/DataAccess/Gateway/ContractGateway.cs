using ChinhDo.Transactions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace DataAccess {
    public class ContractGateway {
        private Context context;
        public ContractGateway(Context context) {
            this.context = context;
        }

        public TransactionScope BeginTransaction() {
            return context.GetTransaction();
        }

        public IEnumerable<Contract> GetContractsFor(DateTime date) {
            return context.Contracts.Where(x => x.NextPayment != null && x.NextPayment.Value.Date == date.Date).ToList();
        }

        public void SaveContract(Contract contract) {
            context.SaveContract(contract);
        }

        public IEnumerable<Contract> GetAllContracts() {
            return context.Contracts;
        }
    }
}
