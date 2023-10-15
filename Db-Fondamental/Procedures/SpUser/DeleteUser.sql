CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int 
AS
BEGIN
    -- Vérifier si l'utilisateur existe
    IF EXISTS (SELECT 1 FROM Users WHERE Id = @Id)
    BEGIN
        -- Supprimer l'utilisateur
        DELETE FROM Users WHERE Id = @Id
        PRINT 'Utilisateur supprimé avec succès.'
    END
    ELSE
    BEGIN
        PRINT 'L''utilisateur spécifié existe pas.'
    END
END

