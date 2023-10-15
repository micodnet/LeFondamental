CREATE PROCEDURE [dbo].[GetPdfId]
	@Id int
AS
	BEGIN
		SELECT* 
		FROM PdfCourses
		WHERE Id = @Id
	END

