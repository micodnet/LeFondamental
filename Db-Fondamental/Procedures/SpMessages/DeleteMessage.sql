CREATE PROCEDURE [dbo].[DeleteMessage]
	@Id INT

    AS
    BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF EXISTS (SELECT * FROM MessagesHub WHERE Id = @Id)
        BEGIN
            
            DELETE FROM MessagesHub WHERE Id = @Id;
            
            COMMIT;
            
            PRINT 'Le message a été supprimé avec succès.';
        END
        ELSE
        BEGIN
            ROLLBACK;
            
            PRINT 'Le message avec l''identifiant spécifié n''existe pas.';
        END
    END TRY
    BEGIN CATCH
        ROLLBACK;
        
        THROW;
    END CATCH;
END;
