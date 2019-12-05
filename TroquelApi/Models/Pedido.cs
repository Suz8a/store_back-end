using System;
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

        public string folio { get; set; }

        public string contrasena { get; set; }

        public string servicio { get; set; }

        public string descripcion { get; set; }

        public string estado { get; set; }

        public string estado_tienda { get; set; }

        public string estado_taller { get; set; }

        public string link_imagen { get; set;}

        public string link_imagen_taller { get; set; }

        public string cliente_id { get; set; }

        public string usuario_id { get; set; }

        public string ticket_id { get; set; }

        public JoyaObj  joya { get; set; }

        public MaterialAdjuntoObj[] material_adjunto { get; set; }

        public MaterialUtilizarObj[] material_utilizar { get; set; }

        public PresupuestoObj presupuesto { get; set; }

      
    }
}
