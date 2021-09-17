using DataAccess.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess {
    public class Client {
        public Guid Id { get; protected set; }
        public Client() {
            Id = Guid.NewGuid();
        }
        public Client(Guid id) {
            Id = id;
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
