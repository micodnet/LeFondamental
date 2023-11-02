CREATE PROCEDURE [dbo].[AddCourse]
	@title VARCHAR(50),
	@description VARCHAR(50),
	@formationId INT
AS
BEGIN
	INSERT INTO Courses(Title, Description, FormationId)
	VALUES ('title', 'description', 'formationId')
END
