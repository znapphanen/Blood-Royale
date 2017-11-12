DELIMITER $$
/***************CreateGame******************/
DROP PROCEDURE IF EXISTS CreateGame;
$$
CREATE PROCEDURE CreateGame(
	_GameName varchar(64),
	_Creator TINYINT
)
proc_label:BEGIN
	IF (NOT EXISTS (SELECT GameId FROM Games WHERE GameName = _GameName )) THEN
		INSERT INTO Games (GameName,Turn,Creator) VALUES (_GameName,-1,_Creator);
        SELECT * FROM Games where GameName = _GameName;
	END IF;

	
END
$$
/*********************************deleteGame***********************/
DELIMITER $$
DROP PROCEDURE IF EXISTS DeleteGame;
$$
CREATE PROCEDURE DeleteGame(
	_GameId TINYINT
)

proc_label:BEGIN
	IF(EXISTS (SELECT GameId FROM GAMES WHERE GameId= _GameId)) THEN
		DELETE FROM Contracts WHERE GameId = _GameId;
		DELETE FROM Characters WHERE GameId = _GameId;
		DELETE FROM MarriageOffers WHERE GameId = _GameId;
		DELETE FROM Dynasties WHERE GameId = _GameId;
		DELETE FROM Games WHERE GameId = _GameId;
    
    END IF;
END
$$

/**************CreateCharacter****************/
DELIMITER $$
DROP PROCEDURE IF EXISTS CreateCharacter;
$$
CREATE PROCEDURE CreateCharacter(
	_FirstName varchar(15),
	_Str TINYINT,
	_Cha TINYINT,
	_Con TINYINT,
	_Male BOOLEAN,
	_Born TINYINT,
	_GameId INT,
	_FatherId INT,
	_MotherId INT,
	_DynastyId INT

)
proc_label:BEGIN
	
	INSERT INTO Characters (FirstName,Str,Cha,Con,Male,Born,GameId,FatherId,MotherId,DynastyId) VALUES (_FirstName, _Str,_Cha,_Con,_Male,_Born,_GameId,_FatherId,_MotherId,_DynastyId);
	select last_insert_id();
END
$$

/********************Marriage****************/
DELIMITER $$
DROP PROCEDURE IF EXISTS Marriage;
$$
CREATE PROCEDURE Marriage(
	_Husband INT,
	_Wife INT
)
proc_label:BEGIN
	
	UPDATE Characters SET SpouseId = _Husband WHERE CharacterId = _Wife;
	UPDATE Characters SET SpouseId = _Wife WHERE CharacterId = _Husband;
END
$$

/****************Login*****************/
DELIMITER $$
DROP PROCEDURE IF EXISTS Login;
$$

DELIMITER $$
CREATE PROCEDURE Login(
	_UserName varchar (15),
	_Password varchar (64)
)
proc_label:BEGIN
	SET @UserId = -1;
 --	Select UserId INTO @UserId FROM Users WHERE LOWER(UserName) = _UserName AND Password = _Password;   /*collataion on database must be _cs (case sensitive)*/
	Select UserId INTO @UserId FROM Users WHERE UserName = _UserName AND Password = _Password;

	IF(@UserId>0) THEN
		UPDATE Users SET LastLogin=Now() WHERE UserId=@UserId;
	END IF;
	Select @UserId;
END
$$


/*******************CreateDynasty**********************/
DELIMITER $$
DROP PROCEDURE IF EXISTS CreateDynasty;
$$
CREATE PROCEDURE CreateDynasty(
	_DynastyName varchar (15),
	_Country varchar (1),
	_UserId TINYINT,
	_GameId TINYINT
)
proc_label:BEGIN
	INSERT INTO Dynasties (DynastyName,Country,UserId,GameId) VALUES (_DynastyName,_Country,_UserId,_GameId);
	select last_insert_id();
END
$$

/********************GetBreedingCharacters**************/
DELIMITER $$
DROP PROCEDURE IF EXISTS GetBreedingCharacters;
$$
CREATE PROCEDURE GetBreedingCharacters(
	_GameId INT, /*GameId needed so we can get from all Dynasties*/
	_DynastyId INT /*If -1 get from all Dynasties*/

)
proc_label:BEGIN
	Set @ddl ='SELECT * FROM vCharacters WHERE SpouseId IN (SELECT CharacterId FROM br.characters where Dead = false AND Prisoner =  false AND SpouseId IS NOT NULL AND GameId =';
	SET @ddl =CONCAT(@ddl, _GameId, ' AND Male = true');
	IF (_DynastyId> 0)THEN
		SET @ddl = CONCAT(@ddl,' AND DynastyId =',_DynastyId);
		END IF;
	SET @ddl = CONCAT(@ddl,');');
	PREPARE stmt FROM @ddl;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
END
$$



/********************GetNewlyBorns**************/
DELIMITER $$
DROP PROCEDURE IF EXISTS GetNewlyBorns;
$$
CREATE PROCEDURE GetNewlyBorns(
	_GameId INT,
	_DynastyId INT

)
proc_label:BEGIN
	SELECT * FROM vCharacters WHERE DynastyId = _DynastyId AND Born = (Select Turn FROM Games WHERE GameId = _GameId);
END
$$

/********************GetAvailable**************/
DELIMITER $$
DROP PROCEDURE IF EXISTS GetAvailable;
$$
CREATE PROCEDURE GetAvailable(	
	_DynastyId INT
)
proc_label:BEGIN
	SELECT * FROM vCharacters WHERE DynastyId = _DynastyId AND SpouseId IS NULL AND Dead = false AND Prisoner = false AND (Turn - Born) > 2 ORDER BY Male;
END
$$

/********************GetAvailable**************/
DELIMITER $$
DROP PROCEDURE IF EXISTS GetAllAvailable;
$$
CREATE PROCEDURE GetAllAvailable(
	_GameId INT
)
proc_label:BEGIN
	SELECT * FROM vCharacters WHERE GameId = _GameId AND SpouseId IS NULL AND Dead = false AND Prisoner = false AND (Turn - Born) > 2 ORDER BY Male;
END
$$