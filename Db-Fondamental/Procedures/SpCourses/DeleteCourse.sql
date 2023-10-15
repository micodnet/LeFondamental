CREATE PROCEDURE [dbo].[DeleteCourse]
	@Id INT

    AS
    BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF EXISTS (SELECT * FROM Courses WHERE Id = @Id)
        BEGIN
            
            DELETE FROM Courses WHERE Id = @Id;
            
            COMMIT;
            
            PRINT 'Le cours a été supprimé avec succès.';
        END
        ELSE
        BEGIN
            ROLLBACK;
            
            PRINT 'Le cours avec l''identifiant spécifié n''existe pas.';
        END
    END TRY
    BEGIN CATCH
        ROLLBACK;
        
        THROW;
    END CATCH;
END;
