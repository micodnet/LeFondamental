CREATE PROCEDURE [dbo].[deletePdf]
	@Id INT

    AS
    BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Vérifier si le PDF existe
        IF EXISTS (SELECT * FROM PdfCourses WHERE Id = @Id)
        BEGIN
            -- Supprimer le PDF
            DELETE FROM PdfCourses WHERE Id = @Id;
            
            -- Valider la transaction
            COMMIT;
            
            PRINT 'Le PDF a été supprimé avec succès.';
        END
        ELSE
        BEGIN
            -- Annuler la transaction si le PDF n'existe pas
            ROLLBACK;
            
            PRINT 'Le PDF avec l''identifiant spécifié n''existe pas.';
        END
    END TRY
    BEGIN CATCH
        -- En cas d'erreur, annuler la transaction
        ROLLBACK;
        
        -- Retourner l'erreur
        THROW;
    END CATCH;
END;
