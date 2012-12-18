using System;
using System.Collections.Generic;
using BrilliantIdea.Framework.DAL;

namespace BrilliantIdea.Framework.Boards
{
    public class Boards
    {
        private const string ConnectionString = "mongodb://localhost";
        private const string DatabaseName = "Hardware";

        private readonly Repository<BoardType> _typeRepository = new Repository<BoardType>(ConnectionString, DatabaseName, "BoardTypes");
        private readonly Repository<BoardDevice> _deviceRepository = new Repository<BoardDevice>(ConnectionString, DatabaseName, "Boards");

        //Initialize the basic Type Boards supported
        public void InitTypeBoards()
        {
            var boardTypeModel = new BoardType
                {
                    Name = "Netduino Plus",
                    BoardId = Guid.NewGuid(),
                    Description = "Tarjeta Netduino Plus con microcontrolador 32-bits a 168Mhz y conexión ethernet"
                };

            if (!_typeRepository.Any(x => x.Name == boardTypeModel.Name))
            {
                _typeRepository.Insert(boardTypeModel);
            }
        }

        //Initialize the basic Boards supported
        public void InitBoards()
        {
            var sensorType = new Repository<SensorType>(ConnectionString, DatabaseName, "SensorTypes");
            var sensors = new Repository<Sensor>(ConnectionString, DatabaseName, "Sensors");

            var ports = new List<Port>();
            var temperatureSensor = new SensorType
                {SensorTypeId = Guid.NewGuid(), Name = "Temperatura", Description = "Medición de temperatura"};
            if (!sensorType.Any(x=>x.Name==temperatureSensor.Name))
            {
                sensorType.Insert(temperatureSensor);
            }

            var genericSensor = new Sensor
                {
                    SensorId = Guid.NewGuid(),
                    Name = "Sensor LM35",
                    Description = "Sensor de temperatura modelo LM35",
                    SensorType = temperatureSensor
                };
            if (!sensors.Any(x=>x.Name==genericSensor.Name))
            {
                sensors.Insert(genericSensor);
            }
            
            var boardModel = new BoardDevice
            {
                DeviceId = Guid.NewGuid(),
                Name = "Tarjeta Principal",
                Description = "Tarjeta de adquisición de datos tipo Netduino, con configuración inicial",
                Url = "10.1.0.0",
            };

            if (!_deviceRepository.Any(x => x.Name == boardModel.Name))
            {
                for (var i = 0; i < 22; i++)
                {
                    var port = new Port {PortNumber = i, AttachedSensor = null, InputType = 0, Enable = false};
                    if (i == 5)
                    {
                        port.AttachedSensor = genericSensor;
                        port.Enable = true;
                    }
                    ports.Add(port);
                }

                boardModel.PortsConfiguration = ports;
                var deviceType = _typeRepository.Single(y => y.Name == "Netduino Plus");
                boardModel.Type = deviceType;

                _deviceRepository.Insert(boardModel);

            }

        }

        public IEnumerable<BoardType> GetAllBoardTypes()
        {
            return _typeRepository.GetAllRows();
        }

        public IEnumerable<BoardDevice> GetAllBoards()
        {
            return _deviceRepository.GetAllRows();
        }
    }
}
