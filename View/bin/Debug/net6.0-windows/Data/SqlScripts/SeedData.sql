INSERT INTO Regions (Name) 
VALUES ('Aragatsotn'),
	   ('Ararat'),
	   ('Armavir'),
	   ('Gegharkunik'),
	   ('Kotayk'),
	   ('Lori'),
	   ('Shirak'),
	   ('Syunik'),
	   ('Tavush'),
	   ('Vayots'),
	   ('Yerevan');

	   Go

INSERT INTO Customers (FirstName, LastName, RegionId, Address)
VALUES ('Arsaces', 'Arsacid', 1, 'Street 1'),
		('Tiridates', 'Arsacid', 2, 'Street 2'),
		('Sanatruces', 'Arsacid', 3, 'Street 3'),
		('Vologases', 'Arsacid', 4, 'Street 4');

		Go

INSERT INTO Branches (Name) 
VALUES ('Gyumri'),
	   ('Kapan'),
	   ('Hrazdan');

		Go

INSERT INTO ApplicationTypes (Name) 
VALUES ('Loan'),
	   ('Deposit');

		Go

INSERT INTO Applications (TypeId, CustomerId, Amount, Date, Rate, BranchId) 
VALUES (1, 1, 10000, GETDATE(), 10, 1),
	   (2, 2, 20000, GETDATE(), 20, 2),
	   (1, 3, 30000, GETDATE(), 30, 3),
	   (2, 4, 40000, GETDATE(), 40, 1);