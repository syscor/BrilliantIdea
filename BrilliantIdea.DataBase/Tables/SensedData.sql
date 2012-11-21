CREATE TABLE [Temperature].[SensedData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SensorId] INT NOT NULL, 
	[ProcessId] INT NOT NULL, 
    [CreatedDate] DATE NOT NULL, 
    [CreatedHour] INT NOT NULL, 
    [ValueSeries] NVARCHAR(MAX) NOT NULL, 
    [LastUpdated] DATETIME NOT NULL, 
    [RangeId] INT NOT NULL, 
    [Message] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_SensedData_ToSensors] FOREIGN KEY (SensorId) REFERENCES [dbo].[Sensors](Id), 
    CONSTRAINT [FK_SensedData_ToProcess] FOREIGN KEY (ProcessId) REFERENCES [dbo].[Process](ProcessId)
)

GO

CREATE INDEX [IX_SensedData_Sensor] ON [Temperature].[SensedData] (SensorId)

GO

CREATE INDEX [IX_SensedData_Process] ON [Temperature].[SensedData] (ProcessId)

GO

CREATE TRIGGER [Temperature].[Trigger_SensedData]
    ON [Temperature].[SensedData]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
		DECLARE @SensorID INT
		DECLARE @Value FLOAT

		SELECT @SensorID = (SELECT SensorId from inserted)
		SELECT @Value = (SELECT ValueSeries from inserted)  

		UPDATE CurrentValue
		SET Value=@Value, LastModified=GETDATE()
		WHERE SensorId=@SensorID
    END
GO

