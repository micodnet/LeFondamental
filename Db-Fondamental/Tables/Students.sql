CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL IDENTITY, 
    [NickName] VARCHAR(50) NOT NULL,
    [Email] VARCHAR(150) NOT NULL, 
    [PsswdHash] NVARCHAR(MAX) NOT NULL,
    [UserId] INT NOT NULL, 
    CONSTRAINT [PK_Students] PRIMARY KEY ([Id]),
    CONSTRAINT FK_Students_NickName FOREIGN KEY (NickName) REFERENCES Users(NickName),
    CONSTRAINT FK_Students_Email FOREIGN KEY (Email) REFERENCES Users(Email),
    CONSTRAINT FK_Students_UserId FOREIGN KEY (UserId) REFERENCES Users(Id),
    
)
