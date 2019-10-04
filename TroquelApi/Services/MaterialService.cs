using TroquelApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TroquelApi.Services
{
    public class MaterialService
    {
        private readonly IMongoCollection<Material> _materiales;

        public MaterialService(ITroquelDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _materiales = database.GetCollection<Material>(settings.MaterialCollectionName);
        }

        public List<Material> Get() =>
            _materiales.Find(material => true).ToList();

        public Material Get(string id) =>
            _materiales.Find<Material>(material => material.Id == id).FirstOrDefault();

        public Material Create(Material material)
        {
            _materiales.InsertOne(material);
            return material;
        }

        public void Update(string id, Material materialIn) =>
            _materiales.ReplaceOne(material => material.Id == id, materialIn);

        public void Remove(Material materialIn) =>
            _materiales.DeleteOne(material => material.Id == materialIn.Id);

        public void Remove(string id) =>
            _materiales.DeleteOne(material => material.Id == id);
    }
}
