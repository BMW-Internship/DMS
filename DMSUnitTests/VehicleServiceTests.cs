using DMS_Internship.Backend.VehicleServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace DMSUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //arrange
            var configMock = new Mock<IConfiguration>();

            var mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "DefaultConnection")]).Returns("mock value");
            configMock.Setup(a => a.GetSection(It.Is<string>(s => s == "ConnectionStrings"))).Returns(mockConfSection.Object);

            var sut = new VehicleService(NullLogger<VehicleService>.Instance, configMock.Object);

            //act
            var vehicles = sut.GetAll();

            //assert
            Assert.True(vehicles.Count() > 0);
        }
    }
}