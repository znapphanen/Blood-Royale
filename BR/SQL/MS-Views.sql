
DROP VIEW vCharacters
DROP VIEW vMarriageOffers
DROP VIEW  vContracts
GO

CREATE VIEW vCharacters AS
	SELECT
		c.CharacterId,
		c.FirstName,
		d.DynastyName,
		d.Country,
		c.Str,
		c.Cha,
		c.Con,
		c.Born,
		c.Gender,
		c.SpouseId,
		c.BirthRollsMade,
		c.DynastyId,
		c.King,
		c.FatherId,
		c.MotherId,
		c.Dead,
		c.Prisoner,
		c.GameId,
		g.Turn

	FROM
		Characters c
		INNER JOIN
		Dynasties d ON d.DynastyId = c.DynastyId
		INNER JOIN
		Games g ON g.GameId = c.GameId;
GO




CREATE VIEW vMarriageOffers AS
	SELECT
		mo.GameId,
		mo.MarriageOfferId,
		mo.OffererId,
		mo.TargetId,
		co.DynastyId as OffererDynasty, /*Offerer */
		ct.DynastyId as TargetDynasty,  /*Target*/
		mo.ContractText

	FROM
		MarriageOffers mo
		INNER JOIN
		Characters co ON mo.OffererId = co.CharacterId
		INNER JOIN
		Characters ct ON mo.TargetId = ct.CharacterId
go





CREATE VIEW vContracts AS
	SELECT
	co.ContractText,
	cOne.FirstName AS NameOne,
	cOne.CharacterId AS IdOne,
	dOne.DynastyName AS DynastyNameOne,
	dOne.DynastyId AS DynastyIdOne,
	cTwo.FirstName AS NameTwo,
	cTwo.CharacterId AS IdTwo,
	dTwo.DynastyName AS DynastyNameTwo,
	dTwo.DynastyId AS DynastyIdTwo

	FROM
	Contracts co
	INNER JOIN
	Characters cOne  ON co.PartOne = cOne.CharacterId
	INNER JOIN
	Dynasties dOne ON cOne.DynastyId = dOne.DynastyId
	INNER JOIN
	Characters cTwo  ON co.PartTwo = cTwo.CharacterId
	INNER JOIN
	Dynasties dTwo ON cTwo.DynastyId = dTwo.DynastyId
go	


		