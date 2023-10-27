CREATE TABLE IF NOT EXISTS Vehicle(
	VehicleId INT PRIMARY KEY AUTOINCREMENT,
	Make VARCHAR(255),
	Model VARCHAR(255),
	Price FLOAT
);

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

SELECT * FROM Vehicle;
Select * From Vehicle Where vehicleId = 1;