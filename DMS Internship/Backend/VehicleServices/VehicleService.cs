using Dapper;
using DMS_Internship.Backend.Controllers;
using DMS_Internship.Backend.Models;
using Microsoft.Data.Sqlite;
using static Dapper.SqlMapper;

namespace DMS_Internship.Backend.VehicleServices
{
    public class VehicleService
    {
        private ILogger<VehicleService> _logger;
        private readonly string? _connectionString;

        public VehicleService(ILogger<VehicleService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public VehicleModel? Create(VehicleEntity entity)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Vehicle " +
                        "(Make, Model, Price) " +
                        "VALUES (@Make, @Model, @Price);" +
                        "select last_insert_rowid();";

                    var vehicle = new VehicleEntity()
                    {
                        Make = entity.Make,
                        Model = entity.Model,
                        Price = entity.Price
                    };

                    var newVehicleId = connection.ExecuteScalar<int>(sql, vehicle);

                    if (newVehicleId <= 0)
                    {

                    }
                    return GetById(newVehicleId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have an exception: " + ex.Message);
                return null;
            }
        }

        public VehicleModel? Delete(int id)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM Vehicle WHERE VehicleId=@id";
                    int count = connection.Execute(sql, new { id });

                    if (count > 0)
                    {
                        return new VehicleModel { Id = id };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have an exception: " + ex.Message);
                return null;
            }
        }


        public VehicleModel GetAll(int id) 
        //public IEnumerable<VehicleModel>? GetAll(int id)
        {
            List<VehicleModel> vehicles = new List<VehicleModel>();
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Vehicle";
                   // var data = connection.Execute(sql);
                   // vehicles = data.ToList();
                    vehicles = connection.Query<VehicleModel>(sql).ToList();
                    var entity = connection.QuerySingle<VehicleEntity>(sql, new { vehicleId = id });

                    var vehicle = new VehicleEntity()
                    {
                        VehicleId = entity. VehicleId,
                        Make = entity.Make,
                        Model = entity.Model,
                        Price = entity.Price
                    };

                    var newVehicleId = connection.ExecuteScalar<int>(sql, vehicle);
                    return vehicles[newVehicleId];
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have an exception:");
                return null;
            }

        }

        public VehicleModel? GetById(int id)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Vehicle WHERE vehicleId=@vehicleId";
                    var entity = connection.QuerySingle<VehicleEntity>(sql, new { vehicleId = id });

                    if (entity == null)
                        return null;

                    return new VehicleModel
                    {
                        Id = entity.VehicleId,
                        Price = entity.Price,
                        PriceInclusive = entity.Price * 1.15f,
                        Series = entity.Make + entity.Model
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have an exception: " + ex.Message);
                return null;
            }
        }

        public VehicleModel? Update(int id, VehicleEntity vehicleEntity)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM Vehicle WHERE vehicleID=@vehicleID";
                    int count = connection.Execute(sql, new { vehicleID = id });

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have an exception: " + ex.Message);
                return null;
            }

        }
    }
}
        
