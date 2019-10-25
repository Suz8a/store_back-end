using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TroquelApi.NestedObjects
{
    public class MaterialAdjuntoObj
    {

        public string nombre_material { get; set; }

        public double gramos { get; set; }

    }
}
