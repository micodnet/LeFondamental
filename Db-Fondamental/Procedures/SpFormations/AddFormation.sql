CREATE PROCEDURE [dbo].[AddFormation]
	@Name VARCHAR(50),
    @Description VARCHAR(150),
    @DateDebut DATETIME2(7),
    @Duree DATETIME2(7),
    @PreRequis VARCHAR(50)
AS
BEGIN
    INSERT INTO Formations(Name, Description, DateDebut, Duree, PreRequis)
    VALUES ('@Name', '@Description', '@DateDebut', '@Duree', '@PreRequis')
END;