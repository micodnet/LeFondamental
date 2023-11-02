CREATE TABLE [dbo].[Courses]
(
	[Id] INT NOT NULL IDENTITY, 
    [Title] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    [FormationId] INT NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([Id]),
    CONSTRAINT FK_Courses_FormationId FOREIGN KEY (FormationId) REFERENCES Formations(Id),
)
