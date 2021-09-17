using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Products {
    public class Database : Product {
        public Database() : base("Database OROKL", 900) {
        }

        public override double GetCurrentPrice(double paidAmmount, double total) {
            if (paidAmmount < total)
                return total / 5;
            return 0;
        }
    }
}
