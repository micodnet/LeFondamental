CREATE TABLE [dbo].[PdfCourses]
(
	[Id] INT NOT NULL IDENTITY, 
    [Title] NCHAR(10) NULL, 
    [Content] NVARCHAR(MAX) NULL, 
    [CourseId] INT NULL,
    CONSTRAINT [PK_PdfCourses] PRIMARY KEY ([Id]),
    CONSTRAINT FK_PdfCourses_CourseId FOREIGN KEY (CourseId) REFERENCES Courses(Id)
)
