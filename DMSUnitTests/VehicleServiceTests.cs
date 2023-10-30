using Castle.Components.DictionaryAdapter.Xml;
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
        }

        [Test]
        [Order(1)]
        public void VehicleService_WhenUpdate_ShouldUpdateSeededRecord()
        {
            //Act
            Id = 6;
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
            var vehicles = _sut.GetAll();

            string expected = "true";
            string actual = update.ToString();
            bool test;

            if (expected == actual)
                test = true;

            else
                test = false;
            Assert.IsTrue(test);

            //Assert.IsTrue(update); // Check if the update operation was successful

            // Verify that the seeded record has been updated with the new values
            Assert.AreEqual(entity.VehicleId, update.Id);
            Assert.AreEqual(entity.Model + entity.Make, update.Series);
            Assert.AreEqual(entity.Price, update.Price);
            Assert.AreEqual(entity.Price, update.PriceInclusive);
            // Add additional assertions for other properties as required
           
        }


        [Test]
        [Order(2)]
        public void VehicleService_WhenDelete_ShouldRemoveSeededRecord()
        {
            //Act
            Id = 5;
            var delete = _sut.Delete(Id);
            var vehicles = _sut.GetAll();

            //Assert
            Assert.AreEqual(11, vehicles.Count());
            //
        }
    }
}