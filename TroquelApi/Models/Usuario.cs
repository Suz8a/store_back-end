using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TroquelApi.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string rol{ get; set; }

        public string correo { get; set; }

        public string contrasena { get; set; }


    }
}
