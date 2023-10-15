CREATE PROCEDURE [dbo].[GetFormationId]
	@Id int
AS
	BEGIN
		SELECT* 
		FROM Formations
		WHERE Id = @Id
	END
