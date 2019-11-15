using TroquelApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TroquelApi.Services
{
    public class PedidoService
    {
        private readonly IMongoCollection<Pedido> _pedidos;

        public PedidoService(ITroquelDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pedidos = database.GetCollection<Pedido>(settings.PedidoCollectionName);
        }

        public List<Pedido> Get() =>
            _pedidos.Find(pedido => true).ToList();

        public Pedido Get(string id) =>
            _pedidos.Find<Pedido>(pedido => pedido.Id == id).FirstOrDefault();

        public Pedido GetByFolio(string folio) =>
            _pedidos.Find<Pedido>(pedido => pedido.folio == folio).FirstOrDefault();

        public Pedido Create(Pedido pedido)
        {
            _pedidos.InsertOne(pedido);
            return pedido;
        }

        public void Update(string id, Pedido pedidoIn) =>
            _pedidos.ReplaceOne(pedido => pedido.Id == id, pedidoIn);

        public void Remove(Pedido pedidoIn) =>
            _pedidos.DeleteOne(pedido => pedido.Id == pedidoIn.Id);

        public void Remove(string id) =>
            _pedidos.DeleteOne(pedido => pedido.Id == id);
    }
}
