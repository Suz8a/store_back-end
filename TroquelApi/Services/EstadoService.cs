using TroquelApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TroquelApi.Services
{
    public class EstadoService
    {
        private readonly IMongoCollection<Estado> _estados;

        public EstadoService(ITroquelDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _estados = database.GetCollection<Estado>(settings.EstadoCollectionName);
        }

        public List<Estado> Get() =>
            _estados.Find(estado => true).ToList();

        public Estado Get(string id) =>
            _estados.Find<Estado>(estado => estado.Id == id).FirstOrDefault();

        public Estado Create(Estado estado)
        {
            _estados.InsertOne(estado);
            return estado;
        }

        public void Update(string id, Estado estadoIn) =>
            _estados.ReplaceOne(estado => estado.Id == id, estadoIn);

        public void Remove(Estado estadoIn) =>
            _estados.DeleteOne(estado => estado.Id == estadoIn.Id);

        public void Remove(string id) =>
            _estados.DeleteOne(estado => estado.Id == id);
    }
}
