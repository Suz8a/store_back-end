﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TroquelApi.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string nombre { get; set; }

        public string apellido_materno { get; set; }

        public string apellido_paterno { get; set; }

        public string correo { get; set; }

        public decimal telefono { get; set; }
    }
}