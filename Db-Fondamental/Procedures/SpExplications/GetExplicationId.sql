CREATE PROCEDURE [dbo].[GetExplicationId]
	@Id int
AS
	BEGIN
		SELECT* 
		FROM Explications
		WHERE Id = @Id
	END
