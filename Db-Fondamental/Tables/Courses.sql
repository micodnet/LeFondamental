CREATE TABLE [dbo].[Courses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    [FormationId] INT NOT NULL,
    CONSTRAINT FK_Courses_FormationId FOREIGN KEY (FormationId) REFERENCES Formations(Id)
)
