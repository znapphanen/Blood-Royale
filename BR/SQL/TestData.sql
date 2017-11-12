use BR;

SET IDENTITY_INSERT Users ON;


INSERT INTO Users (UserId, UserName,Password,Email) VALUES (1,'Admin','psw', null);
INSERT INTO Users (UserId, UserName,Password,Email) VALUES (2,'Per','psw', null);
INSERT INTO Users (UserId, UserName,Password,Email) VALUES (3,'Player3','psw', null);
INSERT INTO Users (UserId, UserName,Password,Email) VALUES (4,'Player4','psw', null);
INSERT INTO Users (UserId, UserName,Password,Email) VALUES (5,'Player5','psw', null);


/*INSERT INTO Games (GameId, GameName, Turn,Creator,DynasticSequence) VALUES (1,'Testgame',5,2,4); 


INSERT INTO Dynasties(DynastyName,Country,UserId,GameId) VALUES ('York','E',2,1);

INSERT INTO Characters (Firstname,Str,Cha,Con,BirthRollesMade,Male,Born,Dead,Prisoner,GameId,DynastyId, King) VALUES ('King George',2,-1,0,0,TRUE,-5,FALSE,FALSE,1,1, True);
INSERT INTO Characters (Firstname,Str,Cha,Con,BirthRollesMade,Male,Born,Dead,Prisoner,GameId,DynastyId, SpouseId) VALUES ('Queen Hanna',1,0,0,0,False,-4,FALSE,FALSE,1,1,1);
INSERT INTO Characters (Firstname,Str,Cha,Con,BirthRollesMade,Male,Born,Dead,Prisoner,GameId, DynastyId,SpouseId, FatherId, MotherId) VALUES ('Princes Oldest',1,-1,0,0,False,-1,False,FALSE,1,1,6,1,2);
INSERT INTO Characters (Firstname,Str,Cha,Con,BirthRollesMade,Male,Born,Dead,Prisoner,GameId, DynastyId,SpouseId, FatherId, MotherId) VALUES ('Prince Dead',1,-1,0,0,TRUE,0,True,FALSE,1,1,6,1,2);

INSERT INTO Characters (Firstname,Str,Cha,Con,BirthRollesMade,Male,Born,Dead,Prisoner,GameId,DynastyId, FatherId, MotherId) VALUES ('Prince Luke1',3,-1,0,0,TRUE,0,FALSE,FALSE,1,1,1,2);
INSERT INTO Characters (Firstname,Str,Cha,Con,BirthRollesMade,Male,Born,Dead,Prisoner,GameId,DynastyId, FatherId, MotherId) VALUES ('Prince Fredric2',2,-3,0,0,TRUE,0,FALSE,FALSE,1,1,1,2);
INSERT INTO Characters (Firstname,Str,Cha,Con,BirthRollesMade,Male,Born,Dead,Prisoner,GameId,DynastyId,SpouseId, FatherId) VALUES ('Son of dead',2,-0,2,0,TRUE,3,FALSE,FALSE,1,1,7,4);
INSERT INTO Characters (Firstname,Str,Cha,Con,BirthRollesMade,Male,Born,Dead,Prisoner,GameId,DynastyId, SpouseId, FatherId) VALUES ('Girl of dead',1,0,0,0,False,0,FALSE,FALSE,1,1,1,4);
INSERT INTO Characters (Firstname,Str,Cha,Con,BirthRollesMade,Male,Born,Dead,Prisoner,GameId,DynastyId, SpouseId, FatherId) VALUES ('Princes Young',1,0,0,0,False,0,FALSE,FALSE,1,1,1,1);
*/
/*
INSERT INTO UserPlayingGames (UserId, GameId) Values (2,1);
INSERT INTO UserPlayingGames (UserId, GameId) Values (2,2); */
