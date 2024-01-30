using Castle.Components.DictionaryAdapter.Xml;
using DMS_Internship.Backend.Controllers;
using DMS_Internship.Backend.Models;
using DMS_Internship.Backend.Setup;
using DMS_Internship.Backend.VehicleServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using SQLitePCL;
using System.Diagnostics;

namespace DMSUnitTests
{
    public class VehicleServiceTests
    {
        private IConfiguration _configuration;
        private VehicleService _sut;
        int Id;

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
            Assert.AreEqual(2558750, vehicles.First().PriceInclusive);
        }

        [Test]
        [Order(1)]
        public void VehicleService_GetById_ShouldDisplaySeededRecord()
        {
            //Act
            Id = 4;
            var vehicle = _sut.GetById(Id);
            //Assert
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(1943500, vehicle.PriceInclusive);
        }

        [Test]
        [Order(2)]
        public void VehicleService_GetById_WithNonexistentId_ShouldReturnNull()
        {
            //Act
            Id = 5;
            var vehicle = _sut.GetById(Id);
            //Assert
            Assert.IsNull(vehicle);
        }

        [Test]
        [Order(3)]
        public void VehicleService_WhenUpdate_ShouldUpdateSeededRecord()
        {
            //Act
            Id = 5;
            //var entity = new VehicleEntity();

            var entity = new VehicleEntity
            {
                // Set the properties of the entity to be updated
                // based on the requirements
                // Example:

                VehicleId = Id,
                Make = "Toyota",
                Price = 10,
                Model = "X5"

            };

            var update = _sut.Update(Id, entity);
            var vehicle = _sut.GetById(Id);

            var priceVatInclusive = entity.Price * 1.15;
            var vehicleSeries = entity.Make + entity.Model;
            //Assert.IsTrue(update); // Check if the update operation was successful

            // Verify that the seeded record has been updated with the new values
            Assert.AreEqual(entity.VehicleId, vehicle.Id);
            Assert.AreEqual(vehicleSeries, vehicle.Series);
            Assert.AreEqual(entity.Price, vehicle.Price);
            Assert.AreEqual(priceVatInclusive, vehicle.PriceInclusive);
            // Add additional assertions for other properties as required

            Assert.AreEqual(vehicle.Id, update.Id);
            Assert.AreEqual(vehicle.Series, update.Series);
            Assert.AreEqual(vehicle.Price, update.Price);
            Assert.AreEqual(vehicle.PriceInclusive, update.PriceInclusive);

        }

        [Test]
        [Order(4)]
        public void VehicleService_WhenDelete_ShouldRemoveSeededRecord()
        {
            //Act
            Id = 6;
            var delete = _sut.Delete(Id);
            var vehicles = _sut.GetAll();

            //Assert
            Assert.AreEqual(11, vehicles.Count());
            //
        }

        [Test]
        [Order(5)]
        public void VehicleService_WhenCreate_ShouldCreateSeededRecord()
        {
            //Arrange
            VehicleEntity model = new VehicleEntity();

            var entity = new VehicleEntity
            {
                VehicleId = 13,
                Make = "BMW",
                Model = "X5",
                Price = 15000000
            };

            var priceVatInclusive = entity.Price * 1.15;
            var vehicleSeries = entity.Make + entity.Model;

            //Act
            var vehicle = _sut.Create(entity);

            // Assert
            // Verify that the seeded record has been updated with the new values
            Assert.AreEqual(entity.VehicleId, vehicle.Id);
            Assert.AreEqual(vehicleSeries, vehicle.Series);
            Assert.AreEqual(entity.Price, vehicle.Price);
            Assert.AreEqual(priceVatInclusive, vehicle.PriceInclusive);
        }
    }
}