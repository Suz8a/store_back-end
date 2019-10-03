using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TroquelApi.Models
{
    public class Joya
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string nombre { get; set; }

    }
}
