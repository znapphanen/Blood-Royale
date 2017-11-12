use br;

/*DROP TABLE IF EXISTS UserPlayingGames; */
DROP TABLE IF EXISTS Contracts;
DROP TABLE IF EXISTS MarriageOffers;
DROP TABLE IF EXISTS Characters;
DROP TABLE IF EXISTS Dynasties;
DROP TABLE IF EXISTS Games;
DROP TABLE IF EXISTS Users;




CREATE TABLE IF NOT EXISTS Users (
	UserId INT NOT NULL AUTO_INCREMENT,
	UserName varchar (11) NOT NULL,
    Password varchar(64) NOT NULL,
    Email varchar (64)  NULL DEFAULT'',
	LastLogin DateTime,
	PRIMARY KEY (UserId)
);

CREATE TABLE IF NOT EXISTS Games(
	GameId INT NOT NULL AUTO_INCREMENT,
	GameName varchar (64),
	Turn TINYINT,
	DynasticSequence TINYINT DEFAULT 0, /*1-Births, 2-Survival 3-Marriages 4- Event & Combat */
	Creator INT NOT NULL,
    CONSTRAINT FOREIGN KEY (Creator) REFERENCES Users (UserId),
	PRIMARY KEY (GameId)
);

CREATE TABLE IF NOT EXISTS Dynasties(
	DynastyId INT NOT NULL AUTO_INCREMENT,
	DynastyName VARCHAR (15),
	Country VARCHAR (1),
	UserId INT NOT NULL,  
	GameId INT NOT NULL,
	CONSTRAINT FOREIGN KEY (GameId) REFERENCES Games (GameId),
	CONSTRAINT FOREIGN KEY (UserId) REFERENCES Users (UserId),
	PRIMARY KEY (DynastyId)
);

CREATE TABLE IF NOT EXISTS Characters(
	CharacterId INT NOT NULL AUTO_INCREMENT,
    FirstName varchar(15),
    Str TINYINT,
    Cha TINYINT,
    Con TINYINT,
	BirthRollesMade TINYINT DEFAULT 0,  
	Male BOOLEAN,
	Born TINYINT,
	Dead BOOLEAN DEFAULT false,
	Prisoner Boolean DEFAULT false,
	King Boolean,
	FatherId INT,  /*can be null, so no FK*/
	MotherId INT,
	SpouseId INT,
	GameId INT NOT NULL,
	DynastyId INT NOT NULL,
	CONSTRAINT FOREIGN KEY (DynastyId) REFERENCES Dynasties (DynastyId),
	CONSTRAINT FOREIGN KEY (GameId) REFERENCES Games (GameId),
	PRIMARY KEY (CharacterId)
);

CREATE TABLE IF NOT EXISTS MarriageOffers(
	MarriageOfferId INT NOT NULL AUTO_INCREMENT,
	OffererId INT NOT NULL ,
	ContractText varchar(256),
	TargetId INT NOT NULL,
	GameId INT NOT NULL,
	CONSTRAINT FOREIGN KEY (GameId) REFERENCES Games (GameId),
	CONSTRAINT FOREIGN KEY (OffererId) REFERENCES Characters (CharacterId),
	CONSTRAINT FOREIGN KEY (TargetId) REFERENCES Characters (CharacterId),
	PRIMARY KEY (MarriageOfferId)
);

CREATE TABLE IF NOT EXISTS Contracts(
	ContractId INT NOT NULL AUTO_INCREMENT,
	ContractText varchar(256),
	PartOne INT NOT NULL,
	PartTwo	INT NOT NULL,
	GameId INT NOT NULL,
	CONSTRAINT FOREIGN KEY (GameId) REFERENCES Games (GameId),
	CONSTRAINT FOREIGN KEY (PartOne) REFERENCES Characters (CharacterId),
	CONSTRAINT FOREIGN KEY (PartTwo) REFERENCES Characters (CharacterId),
	PRIMARY KEY (ContractId)
);




