using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TroquelApi.NestedObjects
{
    public class JoyaObj
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string nombre_joya { get; set; }

        public double peso_joya { get; set; }

        [BsonSerializer(typeof(BsonIgnoreIfNullAttribute))]
        public double medida_inicial { get; set; }

        [BsonSerializer(typeof(BsonIgnoreIfNullAttribute))]
        public double medida_final { get; set; }

    }
}
