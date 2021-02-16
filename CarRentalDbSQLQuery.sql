CREATE TABLE [dbo].[Cars]
(
	[Id] INT  NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [BrandId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    [ModelYear] INT NOT NULL, 
    [DailyPrice] DECIMAL NOT NULL, 
    [Description] NCHAR(50) NOT NULL
	FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
	FOREIGN KEY (BrandId) REFERENCES Brands(BrandId)
)

CREATE TABLE [dbo].[Brands]
(
	[BrandId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [BrandName] NCHAR(25) NOT NULL 
)

CREATE TABLE [dbo].[Colors]
(
	[ColorId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ColorName] NCHAR(25) NOT NULL 
)

INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Description)
VALUES
	('1','1','2010','200','Otomatik Benzin'),
	('2','2','2021','600','Otomatik Dizel'),
	('3','3','2015','450','Otomatik Dizel'),
	('1','3','2014','190','Manuel Benzinli');

INSERT INTO Brands(BrandName)
VALUES
	('Opel'),
	('Wolksvagen'),
	('Audi');
	


INSERT INTO Colors(ColorName)
VALUES
	('Kirmizi'),
	('Beyaz'),
	('Siyah');

CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(100) NULL, 
    [Password] NVARCHAR(50) NOT NULL,
)

CREATE TABLE [dbo].[Customers]
(
	[CustomerId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserId] INT NOT NULL, 
    [CustomerName] NVARCHAR(50) NOT NULL,
	FOREIGN KEY (UserId) REFERENCES Users(UserId), 
)

CREATE TABLE [dbo].[Rentals]
(
	[RentalId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CarId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [RentDate] DATETIME NULL, 
    [ReturnDate] DATETIME NULL,
	FOREIGN KEY (CarId) REFERENCES Cars(Id),
	FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
)