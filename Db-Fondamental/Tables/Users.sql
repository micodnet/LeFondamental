CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY, 
    [LastName] VARCHAR(50) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [Birthdate] DATETIME2 NOT NULL, 
    [NickName] VARCHAR(50) NOT NULL UNIQUE, 
    [Email] VARCHAR(150) NOT NULL UNIQUE, 
    [PsswdHash] NVARCHAR(250) NOT NULL, 
    [RoleId] INT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]), 
   

)
