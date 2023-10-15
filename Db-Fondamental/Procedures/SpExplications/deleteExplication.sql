CREATE PROCEDURE [dbo].[deleteExplication]
	@Id INT

    AS
    BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF EXISTS (SELECT * FROM Explications WHERE Id = @Id)
        BEGIN
            
            DELETE FROM Explications WHERE Id = @Id;
            
            COMMIT;
            
            PRINT 'L''explication a été supprimé avec succès.';
        END
        ELSE
        BEGIN
            ROLLBACK;
            
            PRINT 'L''explication avec l''identifiant spécifié n''existe pas.';
        END
    END TRY
    BEGIN CATCH
        ROLLBACK;
        
        THROW;
    END CATCH;
END;
