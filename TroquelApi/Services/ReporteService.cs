using TroquelApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TroquelApi.Services
{
    public class ReporteService
    {
        private readonly IMongoCollection<Reporte> _reportes;

        public ReporteService(ITroquelDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _reportes = database.GetCollection<Reporte>(settings.ReporteCollectionName);
        }

        public List<Reporte> Get() =>
            _reportes.Find(reporte => true).ToList();

        public Reporte Get(string id) =>
            _reportes.Find<Reporte>(reporte => reporte.Id == id).FirstOrDefault();

        public Reporte Create(Reporte reporte)
        {
            _reportes.InsertOne(reporte);
            return reporte;
        }

        public void Update(string id, Reporte reporteIn) =>
            _reportes.ReplaceOne(reporte => reporte.Id == id, reporteIn);

        public void Remove(Reporte reporteIn) =>
            _reportes.DeleteOne(reporte => reporte.Id == reporteIn.Id);

        public void Remove(string id) =>
            _reportes.DeleteOne(reporte => reporte.Id == id);
    }
}
