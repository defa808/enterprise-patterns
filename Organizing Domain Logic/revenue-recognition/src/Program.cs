using DataAccess;
using dotnetcore.TableModel;
using dotnetcore.TransactionScript;
using System;
using System.Data;
using System.Linq;
using System.Text.Json;

namespace dotnetcore
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Start Program");
            ContractGateway gateway = new ContractGateway(new Context());
            RunTableModule(new Context());
            //RunTransactionScript(gateway);
        }

        private static void RunTableModule(Context context) {
            DataSet dataSet = new DataSet();
            DataTable cTable = context.Contracts.ToDataTable(); 
            cTable.TableName = "Contracts";
         
            dataSet.Tables.Add(cTable);

            DataTable pTable = context.Contracts.Select(x=> x.Product).ToList().ToDataTable(); 
            pTable.TableName = "Products";

            dataSet.Tables.Add(pTable);

            DataTable revenueRecognition = new DataTable("RevenueRecognition");
            revenueRecognition.Columns.Add("Id");
            revenueRecognition.Columns.Add("ContractId");
            revenueRecognition.Columns.Add("Amount");
            revenueRecognition.Columns.Add("Date");
            dataSet.Tables.Add(revenueRecognition);

            ContractTable c = new ContractTable(dataSet);
            c.CalculateRevenueRecognition(DateTime.Now);

            Console.WriteLine("All Revenues for now:");
            foreach (DataRow item in revenueRecognition.Rows) {
                Console.WriteLine($"Id: {item["Id"]}");
                Console.WriteLine($"ContractId: {item["ContractId"]}");
                Console.WriteLine($"Amount: {item["Amount"]}");
                Console.WriteLine($"Date: {item["Date"]}");
            }
            
            Console.WriteLine("\nAll Revenues in 30 days later:");
            c.CalculateRevenueRecognition(DateTime.Now.AddDays(30));
            foreach (DataRow item in revenueRecognition.Rows) {
                Console.WriteLine($"Id: {item["Id"]}");
                Console.WriteLine($"ContractId: {item["ContractId"]}");
                Console.WriteLine($"Amount: {item["Amount"]}");
                Console.WriteLine($"Date: {item["Date"]}"); 
            }
            Console.WriteLine("\nAll Revenues in 30 days later more:");
            c.CalculateRevenueRecognition(DateTime.Now.AddDays(60));
            foreach (DataRow item in revenueRecognition.Rows) {
                Console.WriteLine($"Id: {item["Id"]}");
                Console.WriteLine($"ContractId: {item["ContractId"]}");
                Console.WriteLine($"Amount: {item["Amount"]}");
                Console.WriteLine($"Date: {item["Date"]}"); 
            }
        }

        private static void RunTransactionScript(ContractGateway gateway) {
            RevenueRecognitionService revenueRecognitionService = new RevenueRecognitionService(gateway);
            Console.WriteLine("Contracts for now:");
            ShowContracts(gateway);
            Console.WriteLine("\nPay today");
            revenueRecognitionService.CalculateRevenueRecognition(DateTime.Now);
            ShowContracts(gateway);
            Console.WriteLine("\nOn the next 30 days started");
            revenueRecognitionService.CalculateRevenueRecognition(DateTime.Now.AddDays(30));
            ShowContracts(gateway);
            Console.WriteLine("\nOn the next 60 days started");
            revenueRecognitionService.CalculateRevenueRecognition(DateTime.Now.AddDays(60));
            ShowContracts(gateway);
            Console.WriteLine("\nOn the next 90 days started");
            revenueRecognitionService.CalculateRevenueRecognition(DateTime.Now.AddDays(90));
            ShowContracts(gateway);
            Console.WriteLine("\nOn the next 120 days started");
            revenueRecognitionService.CalculateRevenueRecognition(DateTime.Now.AddDays(120));
            ShowContracts(gateway);
        }

        private static void ShowContracts(ContractGateway gateway) {
            foreach (Contract item in gateway.GetAllContracts()) {
                Console.WriteLine($"Product: {item.Product.Name}, Next Payment: {item.NextPayment}, Paid Money: {item.PaidMoney}, Total: {item.Product.Total}");
            }
        }
    }
}
