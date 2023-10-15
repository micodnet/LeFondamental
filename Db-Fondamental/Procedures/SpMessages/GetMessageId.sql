CREATE PROCEDURE [dbo].[GetMessageId]
	@Id int
AS
	BEGIN
		SELECT* 
		FROM MessagesHub
		WHERE Id = @Id
	END
