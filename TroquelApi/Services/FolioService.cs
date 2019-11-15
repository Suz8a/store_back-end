using System;
using System.Collections.Generic;
using MongoDB.Driver;
using TroquelApi.Models;

namespace TroquelApi.Services
{
    public class FolioService
    {
        private readonly IMongoCollection<Folio> _folios;
        readonly ContrasenaGen _contrasenaGen;

        public FolioService (ITroquelDatabaseSettings settings, ContrasenaGen contrasenaGen)
        {
            _contrasenaGen = contrasenaGen;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _folios = database.GetCollection<Folio>(settings.FolioCollectionName);
        }

        public string ValidateFolio()
        {
            var folio = _contrasenaGen.GenerateRandomFolio().ToString();

            if (GetFolio(folio) != null)
            {
                folio = ValidateFolio();
            }

            return folio;
        }

        public Folio Create(Folio folio)
        {
            _folios.InsertOne(folio);
            return folio;
        }

        public List<Folio> Get() =>
            _folios.Find(folio => true).ToList();

        public Folio GetFolio(string numFolio) =>
            _folios.Find<Folio>(folio => folio.folio == numFolio).FirstOrDefault();



    }
}
