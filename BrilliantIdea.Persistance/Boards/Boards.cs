using System;
using System.Collections.Generic;
using BrilliantIdea.Framework.DAL;

namespace BrilliantIdea.Framework.Boards
{
    public class Boards
    {
        private const string ConnectionString = "mongodb://localhost";
        private const string DatabaseName = "Hardware";
        private const string TableName = "boards";
        readonly Repository<BoardTypeModel> _repository = new Repository<BoardTypeModel>(ConnectionString, DatabaseName, TableName);

        public void InitTypeBoards()
        {

            var boardTypeModel = new BoardTypeModel
            {
                Name = "Netduino Plus",
                BoardId = Guid.NewGuid(),
                Description = "Tarjeta Netduino Plus con microcontrolador 32-bits a 168Mhz y conexión ethernet"
            };

            if (!_repository.Any(x=>x.Name == boardTypeModel.Name))
            {
                _repository.Insert(boardTypeModel);
            }
        }

        public IEnumerable<BoardTypeModel> GetAllBoardTypes()
        {
            return _repository.GetAllRows();
        }
    }
}
