CREATE PROCEDURE [dbo].[GetUserById]
	@Id int
AS
BEGIN
	SELECT * 
	FROM Users
	WHERE Id = @Id
END