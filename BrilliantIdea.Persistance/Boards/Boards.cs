using System;
using System.Collections.Generic;
using System.Linq;
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
            var pinList = new List<PinFeature>();
            
            var pin = new PinFeature {Pins = "digital pins 0-1", PinDescription = "UART 1 RX, TX"};
            pinList.Add(pin);
            var pin1 = new PinFeature { Pins = "digital pins 2-3", PinDescription = "UART 2 RX, TX/PWM" };
            pinList.Add(pin1);
            var pin2 = new PinFeature { Pins = "digital pins 5-6", PinDescription = "PWM, PWM" };
            pinList.Add(pin2);
            var pin3 = new PinFeature { Pins = "digital pins 7-8", PinDescription = "UART 3 RX, TX (también funciona como UART 2 RTS, CTS" };
            pinList.Add(pin3);
            var pin4 = new PinFeature { Pins = "digital pins 9-10", PinDescription = "PWM, PWM" };
            pinList.Add(pin4);
            var pin5 = new PinFeature { Pins = "digital pins 11-13", PinDescription = "PWM/MOSI, MISO" };
            pinList.Add(pin5);
            var pin6 = new PinFeature { Pins = "digital pin SD/SC", PinDescription = "SDA/SCL (también funciona como UART 4 RX, TX" };
            pinList.Add(pin6);

            var boardTypeModel = new BoardType
                {
                    Name = "Netduino Plus",
                    TypeId = Guid.NewGuid(),
                    Description = "Tarjeta Netduino Plus con microcontrolador 32-bits a 168Mhz y conexión ethernet",
                    PinFeatures = pinList
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
                Enable = true,
                LastUpdate = DateTime.Now
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

        public BoardTypesResult GetAllBoardTypes()
        {
            var result = new BoardTypesResult {BoardTypeList = _typeRepository.GetAllRows().ToList()};
            return result;
        }

        public IEnumerable<BoardDevice> GetAllBoards()
        {
            return _deviceRepository.GetAllRows();
        }

        public bool SaveBoard(BoardDevice boardDevice)
        {
            try
            {
                _deviceRepository.Insert(boardDevice);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public class BoardTypesResult
        {
            public List<BoardType> BoardTypeList { get; set; }  
        }
    }
}
