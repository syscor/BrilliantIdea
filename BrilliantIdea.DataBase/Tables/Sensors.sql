CREATE TABLE [dbo].[Sensors]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SensorType] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [MaxValue] FLOAT NOT NULL, 
    [MinValue] FLOAT NOT NULL, 
    [ScaleId] INT NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
)

GO

CREATE INDEX [IX_Sensors_Column] ON [dbo].[Sensors] (SensorType)

GO