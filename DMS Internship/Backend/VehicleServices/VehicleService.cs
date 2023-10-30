using Dapper;
using DMS_Internship.Backend.Controllers;
using DMS_Internship.Backend.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
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
                    var newVehicleId = connection.ExecuteScalar<int>(sql, entity);

                    return GetById(newVehicleId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have an exception: " + ex.Message);
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM Vehicle WHERE VehicleId=@id";
                    var rowsAffected = connection.Execute(sql, new { id });

                    if (rowsAffected == 0)
                    {   
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have an exception: " + ex.Message);
                return false;
            }
        }

        public List<VehicleModel> GetAll() 
        {
            List<VehicleModel> vehicles = new List<VehicleModel>();
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Vehicle";
                    var entities= connection.Query<VehicleEntity>(sql).ToList();
                    foreach (var entity in entities)
                    {
                        var model = new VehicleModel
                        {
                            Id = entity.VehicleId,
                            Price = entity.Price,
                            PriceInclusive = entity.Price * 1.15f,
                            Series = entity.Make + entity.Model
                        };
                        vehicles.Add(model);
                    }
                    
                    return vehicles;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have an exception:");
                return new List<VehicleModel>();
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
                    var entity = connection.QuerySingleOrDefault<VehicleEntity>(sql, new { vehicleId = id });

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

        public VehicleModel? Update(int id, VehicleEntity entity)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE Vehicle SET Model = @Model, Make = @Make, Price = @Price WHERE VehicleId = @VehicleId";
                    entity.VehicleId = id;

                    var rowsAffected = connection.Execute(sql, entity);

                    if (rowsAffected == 0)
                    {
                        return null;
                    }

                    return GetById(id);
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
        
