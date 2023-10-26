﻿using Dapper;
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
                    var rowsAffected = connection.Execute(sql, new { id });

                    if (rowsAffected == 0)
                    {
                        return null;
                    }

                    var vehicle = new VehicleModel
                    {
                        Id = id
                    };

                    return vehicle;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have an exception: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<VehicleModel> GetAll()
        {
            List<VehicleModel> vehicles = new List<VehicleModel>();
                try
                {
                    using (var connection = new SqliteConnection(_connectionString))
                    {
                        connection.Open();

                        string sql = "SELECT * FROM Vehicle";
                        vehicles = connection.Query<VehicleModel>(sql).ToList();
                    }
                    return vehicles;
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

        public VehicleModel? Update(int id)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have an exception: " + ex.Message);
                return null;
            }

        }
    }
}
        
    //mapper
//prices vat
//private ienum<summary> bmwmanange  entity(){
//code code
//if null 
//return null
//}