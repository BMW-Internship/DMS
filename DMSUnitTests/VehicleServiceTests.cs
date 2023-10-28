using DMS_Internship.Backend.Setup;
using DMS_Internship.Backend.VehicleServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using System.Diagnostics;

namespace DMSUnitTests
{
    public class VehicleServiceTests
    {
        private IConfiguration _configuration;
        private VehicleService _sut;
        int id;

        [SetUp]
        public void Setup()
        {
            var configValues = new Dictionary<string, string?>()
            {
                { "ConnectionStrings:DefaultConnection", "Data Source=DMS_Test.db" }
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            _sut = new VehicleService(NullLogger<VehicleService>.Instance, _configuration);

            var databaseInit = new DatabaseInit(_configuration);
            databaseInit.DropDatabaseTables();
            databaseInit.IntDatabase();
        }

        [Test]
        [Order(0)]
        public void VehicleService_WhenGetAll_ShouldReturnSeededRecords()
        {
            // act
            var vehicles = _sut.GetAll();

            // assert
            Assert.AreEqual(12, vehicles.Count());
        }

        [Test]
        [Order(1)]
        public void VehicleService_WhenDelete_ShouldRemoveSeededRecord()
        {
            //Act
            id = 5;
            var delete = _sut.Delete(id);
            var vehicles = _sut.GetAll();

            //Assert
            Assert.AreEqual(11, vehicles.Count());
            //
        }
    }
}