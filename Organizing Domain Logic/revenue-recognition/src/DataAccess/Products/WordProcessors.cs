using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Products {
    public class WordProcessors : Product {
        public WordProcessors() : base("WordProcessor 3000",10) {
        }

        public override double GetCurrentPrice(double paidAmmount, double total) {
            if (paidAmmount < total)
                return total / 6;
            return 0;
        }
    }
}
