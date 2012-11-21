CREATE TABLE [Core].[Process]
(
	[ProcessId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryId] INT NOT NULL, 
	[ProcessName] NVARCHAR(50) NOT NULL, 
    [ProcessType] INT NOT NULL, 
    [InProcess] BIT NOT NULL, 
    [InitDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Process_Categories] FOREIGN KEY (CategoryId) REFERENCES [Core].[Categories]([Id]) 
)
