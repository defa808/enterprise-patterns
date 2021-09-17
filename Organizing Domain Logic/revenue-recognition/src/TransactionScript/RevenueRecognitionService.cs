using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore.TransactionScript {
    public class RevenueRecognitionService {
        ContractGateway gateway;

        public RevenueRecognitionService(ContractGateway gateway) {
            this.gateway = gateway;
        }

        //Transaction Script in Command
        public void CalculateRevenueRecognition(DateTime date) {
            using var transaction = gateway.BeginTransaction();
            try {
                int status = 0;
                foreach (Contract contract in gateway.GetContractsFor(date)) {
                    IPaymentContractCommand command = PaymentCommandFactory.GetCommand(contract);
                    status += command.Execute(contract, gateway);
                }
                if (status == 0)
                    transaction.Complete();
            } catch (Exception e) {
                transaction.Dispose();
                throw e;
            }
        }

    }
}
