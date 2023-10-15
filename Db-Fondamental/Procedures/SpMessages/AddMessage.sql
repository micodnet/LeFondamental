CREATE PROCEDURE [dbo].[AddMessage]
	@Content NVARCHAR(MAX),
    @UserIdEnvoi INT,
    @UserIdRecu INT,
    @DateEnvoi DateTime2(7)
AS
BEGIN
    INSERT INTO MessagesHub(Content, UserIdEnvoi,UserIdRecu, DateEnvoi)
    VALUES (@Content, @UserIdEnvoi,@UserIdRecu, @DateEnvoi)
END;
