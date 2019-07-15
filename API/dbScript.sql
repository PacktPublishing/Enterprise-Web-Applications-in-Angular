Use TripPlannerDB
create table Users
(
	Id int primary key identity(1,1),
	FName varchar(10),
	LName varchar(10),
	Email varchar(150),
	Pwd varchar(10),
	IsActive bit
) 

create table Roles
(
	Id int primary key identity(1,1),
	Name varchar(10),
	Description varchar(250)
) 

create table UserRoles
(
	Id int primary key identity(1,1),
	UserId int foreign key references Users(id),
	RoleId int foreign key references Roles(id),
)

create table Stays
(
	Id int primary key identity(1,1),
	Name varchar(50),
	Detail varchar(250) null
)

create table Trips
(
	Id int primary key identity(1,1),
	Name varchar(50),
	Detail varchar(250) null,
	StartDate date null,
	EndDate date null,
	StayId int foreign key references Stays(id) null	
)

create table Addresses
(
	Id int primary key identity(1,1),
	Name varchar(50),
	Address1 varchar(50),
	Address2 varchar(50) null,
	City varchar(20),
	State varchar(20),
	Zip varchar(6),
	TripId int foreign key references Trips(id)	
)

create table Documents
(
	Id int primary key identity(1,1),
	Name varchar(50),
	FileName varchar(50),
	Url varchar(50) null,
	IsPublic varchar(20),
	DocumentType varchar(10),	
	TripId int foreign key references Trips(id)	
)

create table WebLinks
(
	Id int primary key identity(1,1),
	Name varchar(50),
	Link varchar(50),	
	TripId int foreign key references Trips(id)	
)