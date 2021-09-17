using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Gateway {
    public class ClientDBDataGateway : IClientTableDataGateway {
        private readonly IDbConnection connection;

        public ClientDBDataGateway(IDbConnection connection) {
            this.connection = connection;
        }

        public List<Client> SelectAll() {
            string sql = "select * from Clients";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            IDataReader reader = command.ExecuteReader();
            List<Client> clients = new List<Client>();

            while(reader.Read()) {
                Guid clientId = Guid.Parse(reader["id"].ToString());
                string firstName = reader["firstName"].ToString();
                string secondName = reader["secondName"].ToString();
                clients.Add(new Client(clientId) { FirstName = firstName, SecondName = secondName });
            }
            reader.Close();
            return clients;
        }

        public Client FindById(Guid id) {
            string sql = "select * from Clients where id = @id"; 
            IDbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add(new SqlParameter("@id", id)); 
            IDataReader reader = command.ExecuteReader(); 
            Client client = null; 
            
            while (reader.Read()) {
                Guid clientId = Guid.Parse(reader["id"].ToString());
                string firstName = reader["firstName"].ToString();
                string secondName = reader["secondName"].ToString();
                client = new Client(clientId) { FirstName = firstName, SecondName = secondName }; 
            }
            reader.Close(); 
            return client;
        }

        public Client FindWithLastName(string lastName) {
            string sql = "select * from Clients where lastName = @lastName";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add(new SqlParameter("@lastName", lastName));
            IDataReader reader = command.ExecuteReader();
            Client client = null;

            while (reader.Read()) {
                Guid clientId = Guid.Parse(reader["id"].ToString());
                string firstName = reader["firstName"].ToString();
                string secondName = reader["secondName"].ToString();
                client = new Client(clientId) { FirstName = firstName, SecondName = secondName };
            }
            reader.Close();
            return client;
        }

        public int Update(Guid id, string firstName, string lastName) {
            string sql = "update Clients set firstName = @firstName, lastName = @lastName where id = @id";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add(new SqlParameter("@id", id.ToString()));
            command.Parameters.Add(new SqlParameter("@firstName", firstName));
            command.Parameters.Add(new SqlParameter("@lastName", lastName));
            return command.ExecuteNonQuery();
        }

        public int Insert(string firstName, string lastName) {
            string sql = "insert into Clients (firstName, lastName)" + " values (@firstName, @lastName)";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add(new SqlParameter("@firstName", firstName)); 
            command.Parameters.Add(new SqlParameter("@lastName", lastName));
           return command.ExecuteNonQuery();
        }

        public int Delete(Guid id) {
            string sql = "delete from Clients where id = @id";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add(new SqlParameter("@id", id.ToString()));
            return command.ExecuteNonQuery();
        }

       
    }
}
