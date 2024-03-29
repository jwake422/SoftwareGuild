USE GuildCars;
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Sale')
	DROP TABLE Sale
IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseType')
	DROP TABLE PurchaseType
IF EXISTS(SELECT * FROM sys.tables WHERE name='PhotoPath')
	DROP TABLE PhotoPath
IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicle')
	DROP TABLE Vehicle
IF EXISTS(SELECT * FROM sys.tables WHERE name='Type')
	DROP TABLE [Type]
IF EXISTS(SELECT * FROM sys.tables WHERE name='Interior')
	DROP TABLE Interior
IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmission')
	DROP TABLE Transmission
IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
	DROP TABLE Color
IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
	DROP TABLE Model
IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
	DROP TABLE Make
IF EXISTS(SELECT * FROM sys.tables WHERE name='Body')
	DROP TABLE Body
IF EXISTS(SELECT * FROM sys.tables WHERE name='ContactUs')
	DROP TABLE ContactUs
IF EXISTS(SELECT * FROM sys.tables WHERE name='Special')
	DROP TABLE Special

CREATE TABLE Make(
	MakeId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId NVARCHAR(128) NOT NULL,
	MakeName VARCHAR(20) NOT NULL,
	DateAdded DATETIME2 NOT NULL,
)

CREATE TABLE Body(
	BodyId INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	BodyType VARCHAR(9) NOT NULL
)

CREATE TABLE Model(
	ModelId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MakeId INT FOREIGN KEY REFERENCES Make(MakeId) NOT NULL,
	UserId NVARCHAR(128) NOT NULL,
	ModelName VARCHAR(20) NOT NULL,
	DateAdded DATETIME2 NOT NULL
)

CREATE TABLE Interior(
	InteriorId INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	InteriorColor varchar(20) NOT NULL
)

CREATE TABLE Color(
	ColorId INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	ColorName VARCHAR(20) NOT NULL
)

CREATE TABLE Transmission(
	TransmissionId INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	TransmissionType VARCHAR(9) NOT NULL
)

CREATE TABLE [Type](
	TypeId INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	TypeName VARCHAR(4) NOT NULL
)
CREATE TABLE Vehicle (
	VehicleId INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	MakeId INT FOREIGN KEY REFERENCES Make(MakeId) NOT NULL,
	ModelId INT FOREIGN KEY REFERENCES Model(ModelId) NOT NULL,
	BodyId INT FOREIGN KEY REFERENCES Body(BodyId) NOT NULL,
	InteriorId INT FOREIGN KEY REFERENCES Interior(InteriorId) NOT NULL,
	ColorId INT FOREIGN KEY REFERENCES Color(ColorId) NOT NULL,
	TypeID INT FOREIGN KEY REFERENCES [Type](TypeId) NOT NULL,
	TransmissionId INT FOREIGN KEY REFERENCES Transmission(TransmissionId) NOT NULL,
	[Year] INT NOT NULL,
	VIN VARCHAR(17) NOT NULL,
	Mileage INT NOT NULL,
	MSRP DECIMAL NOT NULL,
	SalePrice DECIMAL NOT NULL,
	[Description] VARCHAR(300) NOT NULL,
	PhotoPath NVARCHAR(100) NULL,
	IsSold BIT NOT NULL,
	isFeatured BIT NOT NULL,
	isDeleted BIT NOT NULL
)

CREATE TABLE PurchaseType(
	PurchaseTypeId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	PurchaseType VARCHAR(15) NOT NULL
)

CREATE TABLE Sale(
	SaleId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId NVARCHAR(128),
	PurchaseTypeId INT FOREIGN KEY REFERENCES PurchaseType(PurchaseTypeId),
	VehicleId INT FOREIGN KEY REFERENCES Vehicle(VehicleId),
	PurchasePrice DECIMAL NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Phone VARCHAR(10) NOT NULL,
	Email NVARCHAR(30) NOT NULL,
	Street1 VARCHAR(30) NOT NULL,
	Street2 VARCHAR(30) NULL,
	City VARCHAR(25) NOT NULL,
	[State] VARCHAR(19) NOT NULL,
	Zipcode VARCHAR(5) NOT NULL,
	DateSold DateTime2 NOT NULL
)

CREATE TABLE ContactUs(
	ContactUsId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	Phone VARCHAR(10)  NULL,
	Email VARCHAR(30)  NULL,
	[Message] VARCHAR(300) NOT NULL
)

CREATE TABLE Special(
	SpecialId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	SpecialTitle VARCHAR(50) NOT NULL,
	SpecialDescription VARCHAR(300) NOT NULL
)


