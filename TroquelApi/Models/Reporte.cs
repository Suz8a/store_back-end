using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TroquelApi.Models
{
    public class Reporte
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public ObjectId pedido_id { get; set; }

        public string descripcion { get; set; }

    }
}
