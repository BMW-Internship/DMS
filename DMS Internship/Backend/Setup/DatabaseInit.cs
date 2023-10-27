using Dapper;
using DMS_Internship.Backend.Models;
using DMS_Internship.Backend.VehicleServices;
using Microsoft.Data.Sqlite;

namespace DMS_Internship.Backend.Setup
{
    public class DatabaseInit
    {

        private readonly string? _connectionString;

        public DatabaseInit(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public void IntDatabase()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
CREATE TABLE IF NOT EXISTS 
Vehicle(
	VehicleId INTEGER PRIMARY KEY AUTOINCREMENT,
	Make VARCHAR(255),
	Model VARCHAR(255),
	Price FLOAT
);
";
                connection.Execute(sql);

                var count = connection.ExecuteScalar<int>("Select Count(VehicleId) From Vehicle");

                if (count == 0)
                {
                    SeedDatabase();
                }
            }
        }

        private void SeedDatabase()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(1, 'BMW', '7 Series', 2225000);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(2, 'BMW', '3 Series', 820000);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(3, 'BMW', 'X1', 780000);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(4, 'BMW', 'X5', 1690000);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(5, 'BMW', '1 Series', 685000);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(6, 'BMW', 'X7', 2000000);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(7, 'BMW', '2 Series Gran Coupe', 719608);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(8, 'BMW', 'X4', 1180000);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(9, 'BMW', '2 Series', 840000);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(10, 'BMW', 'iX3', 1361400);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(11, 'BMW', 'M2 Coupe', 1485000);
INSERT INTO Vehicle(VehicleId ,Make, Model, Price) VALUES(12, 'BMW', 'X6', 1810000);
";
                connection.Execute(sql);
            }
        }
    }
}
