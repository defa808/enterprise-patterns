using ChinhDo.Transactions;
using DataAccess.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace DataAccess {
    public class Context {
        IFileManager fm = new TxFileManager();
        TransactionScope scope;
        private string contractPath = "contracts";
        public Context() {
            //if (Directory.Exists(contractPath))
            //    InitializeFromFiles();

            Client c1 = new Client() {
                FirstName = "Alex",
                SecondName = "Havryliak"
            };
            Client c2 = new Client() {
                FirstName = "Tom",
                SecondName = "Hidden"
            };
            Client c3 = new Client() {
                FirstName = "Jon",
                SecondName = "Baekken"
            };

            Clients = new List<Client>() { c1, c2, c3 };
            Contracts = new List<Contract> { new Contract(c1, new Spreadsheet()), new Contract(c2, new WordProcessors()), new Contract(c3, new Database()) };

            Directory.CreateDirectory(contractPath);
            foreach (var item in Contracts) {
                SaveContract(item);
            }


        }

        //TODO: intit other entities
        //private void InitializeFromFiles() {
        //    string[] files = Directory.GetFiles(contractPath);
        //    foreach (var item in files) {
        //        Contract c = JsonSerializer.Deserialize<Contract>(File.ReadAllText(item));
        //        Contracts.Add(c);
        //    }

        //}

        internal TransactionScope GetTransaction() {
            scope = new TransactionScope();
            return scope;
        }

        public IEnumerable<Client> Clients { get; protected set; }

        public void SaveContract(Contract contract) {
            fm.WriteAllText($"{contractPath}/contract_{contract.Id}.txt", JsonSerializer.Serialize(contract));
        }

        public List<Product> Products { get; protected set; }
        public List<Contract> Contracts { get; protected set; }
    }
}
