CREATE PROCEDURE [dbo].[UpdateUser]
	@UserId INT,
    @NewLastName NVARCHAR(50),
    @NewFirstName NVARCHAR(50),
    @NewNickName NVARCHAR(50),
    @NewEmail NVARCHAR(150),
    @NewPsswdHash NVARCHAR(250),
    @NewRoleId INT
AS
BEGIN
    -- Vérifier si l'utilisateur existe
    IF EXISTS (SELECT 1 FROM Users WHERE Id = @UserId)
    BEGIN
        -- Modifier les informations de l'utilisateur
        UPDATE Users
        SET LastName = @NewLastName,
            FirstName = @NewFirstName,
            NickName = @NewNickName,
            Email = @NewEmail,
            PsswdHash = @NewPsswdHash,
            RoleId = @NewRoleId
        WHERE Id = @UserId

        PRINT ('Informations lutilisateur modifié avec succès.')
    END
    ELSE
    BEGIN
        PRINT ('L''utilisateur spécifié existe pas.')
    END
END







