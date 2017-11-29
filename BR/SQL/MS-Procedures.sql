USE BR;


DROP PROCEDURE CreateGame;
DROP PROCEDURE  CreateDynasty;
DROP PROCEDURE  CreateCharacter;
DROP PROCEDURE Marriage;
DROP PROCEDURE  GetBreedingCharacters;
DROP PROCEDURE  GetNewlyBorns;
DROP PROCEDURE  GetAvailable;
DROP PROCEDURE GetAllAvailable;
DROP PROCEDURE DeleteGame;
GO





CREATE PROCEDURE CreateGame	@GameName varchar(64),	@Creator INT
AS
BEGIN

	IF (NOT EXISTS (SELECT GameId FROM Games WHERE GameName = @GameName ))
		INSERT INTO Games (GameName,Turn,Creator) VALUES (@GameName,-1,@Creator);
        SELECT * FROM Games where GameName = @GameName;
		
END
GO



CREATE PROCEDURE CreateDynasty
	@DynastyName varchar (15),
	@Country varchar (1),
	@UserId INT,
	@GameId INT

AS
BEGIN
	INSERT INTO Dynasties (DynastyName,Country,UserId,GameId) VALUES (@DynastyName,@Country,@UserId,@GameId);
	SELECT SCOPE_IDENTITY() AS 'Last Insert';
END
GO




CREATE PROCEDURE CreateCharacter
	@FirstName varchar(15),
	@Str SMALLINT,
	@Cha SMALLINT,
	@Con SMALLINT,
	@Gender varchar(1),
	@Born INT,
	@GameId INT,
	@FatherId INT,
	@MotherId INT,
	@DynastyId INT
AS
BEGIN
	
	INSERT INTO Characters (FirstName,Str,Cha,Con,Gender,Born,GameId,FatherId,MotherId,DynastyId) VALUES (@FirstName, @Str,@Cha,@Con,@Gender,@Born,@GameId,@FatherId,@MotherId,@DynastyId);
	SELECT SCOPE_IDENTITY() AS 'Last Insert';
END
GO


CREATE PROCEDURE Marriage
	@Husband INT,
	@Wife INT
AS
BEGIN
	
	UPDATE Characters SET SpouseId = @Husband WHERE CharacterId = @Wife;
	UPDATE Characters SET SpouseId = @Wife WHERE CharacterId = @Husband;
END
GO




CREATE PROCEDURE GetBreedingCharacters
	@GameId INT, /*GameId needed so we can get from all Dynasties*/
	@DynastyId INT /*If -1 get from all Dynasties*/

AS
BEGIN
DECLARE @ddl NVARCHAR(200)
		/*This select cant be any longer*/
	Set @ddl ='SELECT * FROM vCharacters WHERE Dead=0 AND SpouseId IN (SELECT CharacterId FROM Characters where Dead=0 AND Prisoner=0 AND SpouseId IS NOT NULL AND GameId = @gid AND Gender=''M'''
	
	IF (@DynastyId> 0)
	BEGIN
		SET @ddl = CONCAT(@ddl,' AND DynastyId = @did')
	END
	SET @ddl = CONCAT(@ddl,')')
	EXEC sp_executesql @ddl, N'@gid INT, @did INT', @gid = @GameId, @did = @DynastyId
END
GO



CREATE PROCEDURE GetNewlyBorns
	@GameId INT,
	@DynastyId INT

AS
BEGIN
	SELECT * FROM vCharacters WHERE DynastyId = @DynastyId AND Born = (Select Turn FROM Games WHERE GameId = @GameId);
END
GO




CREATE PROCEDURE GetAvailable
	@DynastyId INT
AS
BEGIN
	SELECT * FROM vCharacters WHERE DynastyId = @DynastyId AND SpouseId IS NULL AND Dead = 'FALSE' AND Prisoner = 'FALSE' AND (Turn - Born) > 2 ORDER BY Gender;
END
go

CREATE PROCEDURE GetAllAvailable
	@GameId INT
AS
BEGIN
	SELECT * FROM vCharacters WHERE GameId = @GameId AND SpouseId IS NULL AND Dead = 'FALSE' AND Prisoner = 'FALSE' AND (Turn - Born) > 2 ORDER BY Gender;
END
go




CREATE PROCEDURE DeleteGame
	@GameId TINYINT

AS
BEGIN
	IF(EXISTS (SELECT GameId FROM GAMES WHERE GameId= @GameId)) 
	BEGIN
		DELETE FROM Contracts WHERE GameId = @GameId;
		DELETE FROM Characters WHERE GameId = @GameId;
		DELETE FROM MarriageOffers WHERE GameId = @GameId;
		DELETE FROM Dynasties WHERE GameId = @GameId;
		DELETE FROM Games WHERE GameId = @GameId;
    END
    
END
go


