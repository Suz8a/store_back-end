using TroquelApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TroquelApi.Services
{
    public class ServicioService
    {
        private readonly IMongoCollection<Servicio> _servicios;

        public ServicioService(ITroquelDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _servicios = database.GetCollection<Servicio>(settings.ServicioCollectionName);
        }

        public List<ervicio> Get() =>
            _servicios.Find(servicio => true).ToList();

        public Servicio Get(string id) =>
            _servicios.Find<Servicio>(servicio => servicio.Id == id).FirstOrDefault();

        public Servicio Create(Servicio servicio)
        {
            _servicios.InsertOne(servicio);
            return servicio;
        }

        public void Update(string id, Servicio servicioIn) =>
            _servicios.ReplaceOne(servicio => servicio.Id == id, servicioIn);

        public void Remove(Servicio servicioIn) =>
            _servicios.DeleteOne(servicio => servicio.Id == servicioIn.Id);

        public void Remove(string id) =>
            _servicios.DeleteOne(servicio => servicio.Id == id);
    }
}
