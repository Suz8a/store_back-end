using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TroquelApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string nombre { get; set; }

        public string apellido_materno { get; set; }

        public string apellido_paterno { get; set; }

        public string correo { get; set; }

        public decimal telefono { get; set; }
    }
}