CREATE PROCEDURE [dbo].[AddPdf]
	@Title NVARCHAR(250),
    @Content NVARCHAR(MAX),
    @CourseId INT
AS
BEGIN
    INSERT INTO PdfCourses(Title, Content, CourseId)
    VALUES (@Title, @Content, @CourseId);
END;
