using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TroquelApi.NestedObjects
{
    public class MaterialAdjuntoObj
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string nombre_material { get; set; }

        public double gramos { get; set; }

    }
}
