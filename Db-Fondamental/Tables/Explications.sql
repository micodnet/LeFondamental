CREATE TABLE [dbo].[Explications]
(
	[Id] INT NOT NULL IDENTITY, 
    [Content] VARCHAR(MAX) NOT NULL, 
    [CourseId] INT NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([Id]),
    CONSTRAINT FK_Explications_CourseId FOREIGN KEY (CourseId) REFERENCES Courses(Id)
)
