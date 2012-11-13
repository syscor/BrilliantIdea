CREATE TABLE [Temperature].[SensedData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SensorId] INT NOT NULL, 
    [CreatedDate] DATE NOT NULL, 
    [CreatedHour] INT NOT NULL, 
    [ValueSeries] NVARCHAR(MAX) NOT NULL, 
    [LastUpdated] DATETIME NOT NULL, 
    [RangeId] INT NOT NULL, 
    [Message] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_SensedData_ToTable] FOREIGN KEY (SensorId) REFERENCES [dbo].[Sensors](Id)
)

GO

CREATE INDEX [IX_SensedData_Column] ON [Temperature].[SensedData] (SensorId)

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