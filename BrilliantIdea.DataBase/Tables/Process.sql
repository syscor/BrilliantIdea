CREATE TABLE [dbo].[Process]
(
	[ProcessId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProcessName] NVARCHAR(50) NOT NULL, 
    [ProcessType] INT NOT NULL, 
    [InProcess] BIT NOT NULL, 
    [InitDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL 
)
