using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TroquelApi.NestedObjects;

namespace TroquelApi.Models
{
    public class Pedido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int folio { get; set; }

        public string servicio { get; set; }

        public string descripcion { get; set; }

        public string estado { get; set; }

        public ObjectId cliente_id { get; set; }

        public ObjectId usuario_id { get; set; }

        public ObjectId ticket_id { get; set; }

        public JoyaObj  joya { get; set; }

        public MaterialAdjuntoObj material_adjunto { get; set; }

        public MaterialUtilizarObj material_utilizar { get; set; }

        public PresupuestoObj presupuesto { get; set; }

      
    }
}
