CREATE PROCEDURE [dbo].[DeleteFormation]
	@Id INT

    AS
    BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF EXISTS (SELECT * FROM Formations WHERE Id = @Id)
        BEGIN
            
            DELETE FROM Formations WHERE Id = @Id;
            
            COMMIT;
            
            PRINT 'La formation a été supprimé avec succès.';
        END
        ELSE
        BEGIN
            ROLLBACK;
            
            PRINT 'La formation avec l''identifiant spécifié n''existe pas.';
        END
    END TRY
    BEGIN CATCH
        ROLLBACK;
        
        THROW;
    END CATCH;
END;
