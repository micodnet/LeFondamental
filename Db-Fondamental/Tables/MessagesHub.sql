CREATE TABLE [dbo].[MessagesHub]
(
	[Id] INT NOT NULL IDENTITY, 
    [Content] VARCHAR(250) NULL, 
    [UserIdEnvoi] INT NULL, 
    [UserIdRecu] INT NULL,
    [DateEnvoi] DATETIME2 NULL, 
    CONSTRAINT [PK_MessagesHub] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MessagesHub] FOREIGN KEY ([UserIdEnvoi]) REFERENCES Users(Id),
    FOREIGN KEY ([UserIdRecu]) REFERENCES Users(Id)
)
