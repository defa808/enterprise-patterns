using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Interfaces {
    public interface IClientTableDataGateway {
        List<Client> SelectAll();
        Client FindById(Guid id);
        Client FindWithLastName(string lastName);
        int Update(Guid id, string firstName, string lastName);
        int Insert(string firstName, string lastName);
        int Delete(Guid id);
    }
}
