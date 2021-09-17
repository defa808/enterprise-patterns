using Moq;
using System;
using System.Data;
using Xunit;
using DataAccess.Gateway;
using DataAccess.Interfaces;
using DataAccess;
using System.Collections.Generic;

namespace XUnitTestProject {
    public class ClientDataGatewayTest{
        [Fact]
        public void SelectAll_TwoClients() {
            var readerMock = new Mock<IDataReader>();
            readerMock.SetupSequence(_ => _.Read())
              .Returns(true) //first entity
              .Returns(true) //second entity
              .Returns(false); //end

            readerMock.Setup(x => x["id"])
                        .Returns(Guid.NewGuid());
            readerMock.Setup(x => x["firstName"])
                       .Returns("test");
            readerMock.Setup(x => x["secondName"])
                       .Returns("test");

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            connectionMock.Setup(m => m.CreateCommand()).Returns(commandMock.Object);

            IClientTableDataGateway clientDataGateway = new ClientDBDataGateway(connectionMock.Object);

            var result = clientDataGateway.SelectAll();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void FindById_OneClient() {
            Guid clientId = Guid.NewGuid();
            List<Client> ojectsToEmulate = new List<Client>() {
                new Client(clientId){FirstName = "test1", SecondName = "test1"},
                new Client(Guid.NewGuid()){FirstName = "test2", SecondName = "test2"}
            };

            //var moq = new Mock<IDataReader>();

            //// This var stores current position in 'ojectsToEmulate' list
            //int count = -1;

            //moq.Setup(x => x.Read())
            //    // Return 'True' while list still has an item
            //    .Returns(() => count < ojectsToEmulate.Count - 1)
            //    // Go to next position
            //    .Callback(() => count++);

            //moq.Setup(x => x["id"])
            //    // Again, use lazy initialization via lambda expression
            //    .Returns(() => ojectsToEmulate[count].Id);

            //moq.Setup(x => x["firstName"])
            //    // Again, use lazy initialization via lambda expression
            //    .Returns(() => ojectsToEmulate[count].FirstName);

            //moq.Setup(x => x["secondName"])
            //    // Again, use lazy initialization via lambda expression
            //    .Returns(() => ojectsToEmulate[count].SecondName);

            var commandMock = new Mock<IDbCommand>();
            var dataParameterCollection = new Mock<IDataParameterCollection>();
            commandMock.Setup(x => x.Parameters).Returns(dataParameterCollection.Object);
            //commandMock.Setup(m => m.ExecuteReader()).Returns(moq.Object).Verifiable();

            //commandMock.Setup(m => m.ExecuteReader()).Returns(new DataTableReader()).Verifiable();


            var connectionMock = new Mock<IDbConnection>();
            connectionMock.Setup(m => m.CreateCommand()).Returns(commandMock.Object);

            IClientTableDataGateway clientDataGateway = new ClientDBDataGateway(connectionMock.Object);

            var result = clientDataGateway.FindById(clientId);

            Assert.Equal(clientId, result.Id);
        }
    }
}
