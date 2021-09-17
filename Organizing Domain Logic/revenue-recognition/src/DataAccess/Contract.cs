using DataAccess.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess {
    public class Contract {
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime? NextPayment { get; set; }
        public Client Client { get; protected set; }
        public Guid ProductId { get; protected set; }
        public Product Product { get; protected set; }
        public Contract(Client client, Product product) {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            NextPayment = DateTime.Now;
            Client = client;
            Product = product;
        }
        public double PaidMoney { get; set; }
    }
}
