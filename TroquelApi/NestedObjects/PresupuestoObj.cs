using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TroquelApi.NestedObjects
{
    public class PresupuestoObj
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string hechura { get; set; }

        public double total { get; set; }


    }
}
