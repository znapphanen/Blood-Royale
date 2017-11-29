USE BR;

DROP TABLE IF EXISTS Contracts;
DROP TABLE IF EXISTS MarriageOffers;
DROP TABLE IF EXISTS Characters;
DROP TABLE IF EXISTS Dynasties;
DROP TABLE IF EXISTS Games;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Security;


CREATE TABLE  Users (
	UserId INT NOT NULL Identity(1,1) PRIMARY KEY,
	UserName varchar (11) NOT NULL,
    Password varchar(64) NOT NULL,
    Email varchar (64)  NULL DEFAULT'',
	LastLogin DateTime,
	
);


CREATE TABLE Games(
	GameId INT NOT NULL Identity(1,1) PRIMARY KEY,
	GameName varchar (64),
	Turn INT,
	DynasticSequence TINYINT DEFAULT 0, /*1-Births, 2-Survival 3-Marriages 4- Event & Combat */
	Creator INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),	
);

CREATE TABLE  Dynasties(
	DynastyId INT NOT NULL Identity(1,1) PRIMARY KEY,
	DynastyName VARCHAR (15),
	Country VARCHAR (1),
	UserId INT  FOREIGN KEY REFERENCES Users (UserId),  
	GameId INT NOT NULL FOREIGN KEY REFERENCES Games (GameId)
);


CREATE TABLE Characters(
	CharacterId INT NOT NULL Identity(1,1) PRIMARY KEY,
    FirstName varchar(15),
    Str SMALLINT,
    Cha SMALLINT,
    Con SMALLINT,
	BirthRollsMade TINYINT DEFAULT 0,  
	Gender varchar(1), /*M or F */
	Born INT,
	Dead bit DEFAULT 0,
	Prisoner bit DEFAULT 0,
	King bit,
	FatherId INT,  /*can be null, so no FK*/
	MotherId INT,
	SpouseId INT,
	GameId INT NOT NULL FOREIGN KEY REFERENCES Games (GameId),
	DynastyId INT NOT NULL FOREIGN KEY REFERENCES Dynasties (DynastyId)
	
);

CREATE TABLE MarriageOffers(
	MarriageOfferId INT NOT NULL Identity(1,1) PRIMARY KEY,
	OffererId INT NOT NULL FOREIGN KEY REFERENCES Characters (CharacterId),
	ContractText varchar(256),
	TargetId INT NOT NULL FOREIGN KEY REFERENCES Characters (CharacterId),
	GameId INT NOT NULL FOREIGN KEY REFERENCES Games (GameId)	
);

CREATE TABLE Contracts(
	ContractId INT NOT NULL Identity(1,1) PRIMARY KEY,
	ContractText varchar(256),
	PartOne INT NOT NULL FOREIGN KEY REFERENCES Characters (CharacterId),
	PartTwo	INT NOT NULL FOREIGN KEY REFERENCES Characters (CharacterId),
	GameId INT NOT NULL FOREIGN KEY  REFERENCES Games (GameId)
);

CREATE TABLE Security(
	Passkey varchar(256)

);