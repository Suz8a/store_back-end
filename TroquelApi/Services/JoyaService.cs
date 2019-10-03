using TroquelApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TroquelApi.Services
{
    public class JoyaService
    {
        private readonly IMongoCollection<Joya> _joyas;

        public JoyaService(ITroquelDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _joyas = database.GetCollection<Joya>(settings.JoyaCollectionName);
        }

        public List<Joya> Get() =>
            _joyas.Find(joya => true).ToList();

        public Joya Get(string id) =>
            _joyas.Find<Joya>(joya => joya.Id == id).FirstOrDefault();

        public Joya Create(Joya joya)
        {
            _joyas.InsertOne(joya);
            return joya;
        }

        public void Update(string id, Joya joyaIn) =>
            _joyas.ReplaceOne(joya => joya.Id == id, joyaIn);

        public void Remove(Joya joyaIn) =>
            _joyas.DeleteOne(joya => joya.Id == joyaIn.Id);

        public void Remove(string id) =>
            _joyas.DeleteOne(joya => joya.Id == id);
    }
}
