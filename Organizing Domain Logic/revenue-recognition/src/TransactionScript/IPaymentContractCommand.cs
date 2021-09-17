using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore.TransactionScript {
    public interface IPaymentContractCommand {
        int Execute(Contract contract, ContractGateway gateway);
    }
}
