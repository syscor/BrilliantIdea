CREATE TABLE [dbo].[CurrentValue]
(
	[Id] INT NOT NULL IDENTITY , 
    [SensorId] INT NOT NULL, 
    [Value] NVARCHAR(MAX) NOT NULL, 
    [LastModified] DATETIME NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_CurrentValue_ToTable] FOREIGN KEY (SensorId) REFERENCES [dbo].[Sensors](Id), 
    PRIMARY KEY ([Id]) 
)
