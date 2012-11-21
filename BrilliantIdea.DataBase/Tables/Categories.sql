CREATE TABLE [Core].[Categories]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Type] INT NOT NULL DEFAULT 0, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [Created] DATETIME NOT NULL, 
    CONSTRAINT [FK_Categories_CategorieTypes] FOREIGN KEY (Type) REFERENCES [Core].[CategoryTypes](Id)
)
