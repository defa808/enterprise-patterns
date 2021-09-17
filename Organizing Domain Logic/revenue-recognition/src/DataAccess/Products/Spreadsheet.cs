using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Products {
    public class Spreadsheet : Product {
        public Spreadsheet() : base("Spreadsheet AXCEL", 100) {
        }

        public override double GetCurrentPrice(double paidAmmount, double total) {
            if(paidAmmount < total)
                return total / 4;
            return 0;
        }
    }
}
