using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
namespace DMS_Internship.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BMWManagementController : ControllerBase
    {
        private static readonly string[] models = new[]
        {
        "BMW 3 Series", "BMW X1", "BMW 7 Series", "BMW X5", "1 Series", "BMW X7", "BMW 2 Series Gran Coupe", "BMW X4", "2 Series", "BMW iX3","BMW M2 Coupe","BMW X6"
    };
        private static readonly string[] makeYear = new[]
        {

            "",""
        };

        private readonly ILogger<BMWManagementController> _logger;

        private string connection;
        public BMWManagementController(ILogger<BMWManagementController> logger)
        {
            _logger = logger;
            var connection = new SqliteConnection("Data Source=DMS.db");
            connection.Open();
            connection.Execute();

        }


        [HttpGet]
        public IEnumerable<Dealerships> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Dealerships
            {
                //Price = models[Random.Shared.Next(models.Length)],
                
                Models = models[Random.Shared.Next(models.Length)]
            })
            .ToArray();
        }


        [HttpPost]
        public void Post()
        {
            throw (new Exception());
        }

        

        [HttpPut]
        
        public void Put()
        {
        throw new Exception();
        }

        [HttpDelete]
        
        public void Delete(int id)
        {
        throw(new Exception());
        }
        }

    }
