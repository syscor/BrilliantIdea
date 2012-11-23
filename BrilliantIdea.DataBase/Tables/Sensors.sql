CREATE TABLE [dbo].[Sensors]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SensorType] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [MaxValue] FLOAT NOT NULL, 
    [MinValue] FLOAT NOT NULL, 
    [ScaleId] INT NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [BoardId] INT NOT NULL, 
    [LastModified] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Sensors_SensorTypes] FOREIGN KEY (SensorType) REFERENCES [Core].[SensorTypes](Id), 
    CONSTRAINT [FK_Sensors_Scales] FOREIGN KEY (ScaleId) REFERENCES [Core].[Scales](ScaleId), 
    CONSTRAINT [FK_Sensors_HardwareBoards] FOREIGN KEY (BoardId) REFERENCES [Core].[HardwareBoards](BoardId), 
)

GO

CREATE INDEX [IX_Sensors_Column] ON [dbo].[Sensors] (SensorType)

GO