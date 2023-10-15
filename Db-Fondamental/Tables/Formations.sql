CREATE TABLE [dbo].[Formations]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(150) NOT NULL, 
    [DateDebut] DATETIME2 NULL, 
    [Duree] DATETIME2 NULL, 
    [PreRequis] VARCHAR(50) NULL,
	CONSTRAINT [PK_Formations] PRIMARY KEY ([Id]),
)
