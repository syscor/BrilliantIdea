using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BrilliantIdea.Framework.Boards;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace BrilliantIdea.Framework.DAL
{
    public class Repository<T> :IRepository<T> where T:class
    {
        public MongoDatabase Database { get; private set; }

        public Repository(string connectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            Database = server.GetDatabase(dbName);
            CollectionName = collectionName;
        }

        public IEnumerable<T> GetAllRows()
        {
            var result = from p in GetMongoCollection.AsQueryable()
                         select p;
            return result;
        }

        public IEnumerable<T> GetAllRowsWhere(Func<T, bool> exp)
        {
            return GetMongoCollection.AsQueryable().Where(exp);
        }

        public bool Any(Func<T, bool> exp)
        {
            return GetMongoCollection.AsQueryable().Any(exp);
        }

        public T Single(Func<T, bool> exp)
        {
            return GetMongoCollection.AsQueryable().SingleOrDefault(exp);
        }

        public T First(Func<T, bool> exp)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ObjectId id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            WriteConcernResult result = GetMongoCollection.Remove(query);
            return result.DocumentsAffected == 1;
        }

        public void Insert(T entity)
        {
            GetMongoCollection.Insert(entity);
        }

        public void Update(T entity)
        {
            GetMongoCollection.Save(entity);
        }

        public T New()
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        private MongoCollection<T> GetMongoCollection
        {
            get { return Database.GetCollection<T>(CollectionName); }
        }

        private string CollectionName { get; set; }

        public interface IDataBase
        {
            MongoDatabase Database { get; }
        }
    }
}
