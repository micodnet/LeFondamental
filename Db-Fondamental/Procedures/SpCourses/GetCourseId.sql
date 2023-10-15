CREATE PROCEDURE [dbo].[GetCourseId]
	@Id int
AS
	BEGIN
		SELECT* 
		FROM Courses
		WHERE Id = @Id
	END
