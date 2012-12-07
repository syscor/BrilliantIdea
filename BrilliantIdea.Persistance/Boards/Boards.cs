using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BrilliantIdea.Framework.Boards
{
    public class Boards
    {
        private const string ConnectionString = "mongodb://localhost";
        private readonly MongoClient _client = new MongoClient(ConnectionString);
       
        public void InitTypeBoards()
        {
            var boardTypeModel = new BoardTypeModel
            {
                Name = "Netduino Plus",
                Description = "Tarjeta Netduino Plus con microcontrolador 32-bits a 168Mhz y conexión ethernet"
            };
            var database = GetDataBase("Hardware");
            var boardsTypes = database.GetCollection<BoardTypeModel>("boards");
            var result = boardsTypes.AsQueryable().Any(x => x.Name == boardTypeModel.Name);
            if (!result)
            {
                boardsTypes.Insert(boardTypeModel);
            }
        }

        public IQueryable<BoardTypeModel> GetAllBoardTypes()
        {
            var database = GetDataBase("hardware");
            var boardsCollection = database.GetCollection<BoardTypeModel>("boards");
            var result = from p in boardsCollection.AsQueryable()
                         select p;
            return result;
        }

        private MongoDatabase GetDataBase(string name)
        {
            var server = _client.GetServer();
            return server.GetDatabase(name);
        }
    }
}
