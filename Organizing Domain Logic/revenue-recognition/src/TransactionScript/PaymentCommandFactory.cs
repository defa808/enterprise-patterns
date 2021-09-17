using DataAccess;
using DataAccess.Products;
using System;

namespace dotnetcore.TransactionScript {
    internal class PaymentCommandFactory {
        public static IPaymentContractCommand GetCommand(Contract contract) {
            switch (contract.Product) {
                case Spreadsheet s: return new SpreadSheetPaymentCommand();
                case Database d: return new DatabasePaymentCommand();
                case WordProcessors d: return new WordProcessorPaymentCommand();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}