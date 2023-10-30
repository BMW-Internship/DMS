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
            var entity = new VehicleEntity();
            var update = _sut.Update(Id, entity);
            var vehicles = _sut.GetAll();

            //Assert

            //    var entity = new VehicleEntity[]
            //    {
            //        new VehicleEntity()
            //        {
            //            VehicleId = 1,
            //            Model = "GT3",
            //            Make = "Toyota",
            //            Price = 10
            //        }
            //    };

            //    var mockContext = new Mock<sqlite3_context>();
            //    //mockContext.Setup(e => e.Id).ReturnsDbSet(entity);
            //    //mockContext.Setup(m => m.Employees.Find(It.IsAny<object[]>()))
            //            //.Returns<object[]>(
            //                    ids => employees.FirstOrDefault(d => d.EmployeeId == (int)ids[0]));

            //    var sut = new EmployeeRepository(mockContext.Object);

            //    var employeeToUpdate = new 
            //    {
            //        EmployeeId = 1,
            //        FirstName = "John",
            //        LastName = "Smith",
            //        Email = "John.Smith@Illinois.gov",
            //        IsActive = true
            //    };

            //    sut.Save(employeeToUpdate);

            //    Assert.That(employees.First().FirstName, Is.EqualTo(employeeToUpdate.FirstName));
            //    Assert.That(employees.First().LastName, Is.EqualTo(employeeToUpdate.LastName));
            //    Assert.That(employees.First().Email, Is.EqualTo(employeeToUpdate.Email));
            //}
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