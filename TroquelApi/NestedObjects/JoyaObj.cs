using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TroquelApi.NestedObjects
{
    public class JoyaObj
    {

        public string nombre_joya { get; set; }

        public double peso_joya { get; set; }

        
        public Nullable <double> medida_inicial { get; set; }

    
        public Nullable<double> medida_final { get; set; }

    }
}
