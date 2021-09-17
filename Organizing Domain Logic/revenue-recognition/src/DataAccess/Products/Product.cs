using System;

namespace DataAccess.Products {
    public abstract class Product {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public double Total { get; protected set; }
        public Product(string name, double total) {
            Id = Guid.NewGuid();
            Name = name;
            Total = total;
        }

        public abstract double GetCurrentPrice(double paidAmmount, double total);
    }
}
