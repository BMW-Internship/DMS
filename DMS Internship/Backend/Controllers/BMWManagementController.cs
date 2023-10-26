using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Linq.Expressions;

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
   
        private readonly ILogger<BMWManagementController> _logger;

        private readonly string connectionString;

       

        public BMWManagementController(ILogger<BMWManagementController> logger, IConfiguration configuration)
        {
            _logger = logger;
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
            

        }


        [HttpGet]
        public IActionResult GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Vehicle";
                    var data = connection.Query<Vehicle>(sql);
                    vehicles = data.ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("We have an exception: \n" + ex.Message);
                return BadRequest();
            }

            return Ok(vehicles);
        }

        [HttpGet("{vehicleID}")]
        public IActionResult GetVehicles(int vehicleID)
        {
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Vehicle WHERE vehicleid=@vehicleid";
                    var vehicle = connection.QuerySingle<Vehicle>(sql, new { vehicleid = vehicleID });
                    if(vehicle != null)
                    {
                        return Ok(vehicle);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("We have an exception: \n" + ex.Message);
                return BadRequest();
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult Create(vehicleDbContext VehicleDBContext)
        {
            try

            {
                using(var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Vehicle " +
                        "(make, Model, price) " +
                        "VALUES (@make, @Model, @price);" +
                        "select last_insert_rowid();";

                    var vehicle = new Vehicle()
                    {
                        make = VehicleDBContext.make,
                        Model = VehicleDBContext.Model,
                        price = VehicleDBContext.price,
                    };

                var newVehicleID = connection.ExecuteScalar<int>(sql, vehicle);
                if (newVehicleID > 0)
                {
                    return GetVehicles(newVehicleID);
                }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("We have an exception: \n" + ex.Message);
            }

            return BadRequest();
        }

        

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id, vehicleDbContext VehicleDBContext)
        {
            try
            {
                using(var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Vehicle SET make=@make, Model=@Model, price=@price WHERE vehicleID=@vehicleID";

                    var vehicle = new Vehicle()
                    {
                        vehicleID = id,
                        make = VehicleDBContext.make,
                        Model = VehicleDBContext.Model,
                        price = VehicleDBContext.price,
                    };

                   int count= connection.Execute(sql, vehicle);
                    if(count < 1)
                    {
                        return NotFound();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("We have an exception: \n" + ex.Message);
                return BadRequest();
            }
            return GetVehicles(id);
        }
        

        [HttpDelete("{vehicleID}")]
        public IActionResult DeleteVehicle(int vehicleID)
        {
            try
            {
                using(var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM Vehicle WHERE vehicleID=@vehicleID";
                    int count = connection.Execute(sql, new { vehicleID = vehicleID });
                    if(count < 1)
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("We have an exception: \n" + ex.Message);
                return BadRequest();
            }
            return Ok();
        }
        
        
     }

    }
