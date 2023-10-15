CREATE PROCEDURE [dbo].[AddExplication]
    @Content NVARCHAR(MAX),
    @CourseId INT
AS
BEGIN
    INSERT INTO Explications(Content, CourseId)
    VALUES (@Content, @CourseId)
END;
