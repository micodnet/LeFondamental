CREATE PROCEDURE [dbo].[AddCourse]
	@Title VARCHAR(50),
	@Description VARCHAR(50),
	@FormationId INT
AS
BEGIN
	INSERT INTO Courses(Title, Description, FormationId)
	VALUES (@Title, @Description, @FormationId)
END
