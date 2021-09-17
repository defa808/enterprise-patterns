using DataAccess;
using System;

namespace dotnetcore.TransactionScript {
    public class DatabasePaymentCommand : IPaymentContractCommand {
        public int Execute(Contract contract, ContractGateway gateway) {
            DateTime startDate = contract.NextPayment ?? contract.CreatedDate;
            if (contract.PaidMoney == contract.Product.Total) {
                contract.NextPayment = null;
                gateway.SaveContract(contract);
                return 0;
            }
            if (contract.NextPayment != null && contract.NextPayment.Value.Date == contract.CreatedDate.Date) {
                contract.NextPayment = startDate.AddDays(30);
                contract.PaidMoney += contract.Product.Total / 3;
                gateway.SaveContract(contract);
                return 0;
            }

            if (contract.NextPayment != null && contract.NextPayment.Value.Date == contract.CreatedDate.AddDays(30).Date) {
                contract.NextPayment = startDate.AddDays(30);
                contract.PaidMoney += contract.Product.Total / 3;
                gateway.SaveContract(contract);
                return 0;
            }
            if (contract.NextPayment != null && contract.NextPayment.Value.Date == contract.CreatedDate.AddDays(60).Date) {
                contract.NextPayment = startDate.AddDays(30);
                contract.PaidMoney = contract.Product.Total;
                gateway.SaveContract(contract);
            }
            return 0;
        }
    }
}