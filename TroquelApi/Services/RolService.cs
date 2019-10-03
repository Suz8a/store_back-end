using TroquelApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TroquelApi.Services
{
    public class RolService
    {
        private readonly IMongoCollection<Rol> _roles;

        public RolService(ITroquelDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _roles = database.GetCollection<Rol>(settings.RolCollectionName);
        }

        public List<Rol> Get() =>
            _roles.Find(rol => true).ToList();

        public Rol Get(string id) =>
            _roles.Find<Rol>(rol => rol.Id == id).FirstOrDefault();

        public Rol Create(Rol rol)
        {
            _roles.InsertOne(rol);
            return rol;
        }

        public void Update(string id, Rol rolIn) =>
            _roles.ReplaceOne(rol => rol.Id == id, rolIn);

        public void Remove(Rol rolIn) =>
            _roles.DeleteOne(rol => rol.Id == rolIn.Id);

        public void Remove(string id) =>
            _roles.DeleteOne(rol => rol.Id == id);
    }
}
