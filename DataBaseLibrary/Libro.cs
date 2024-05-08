using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataBaseLibrary
{
    public class Libro
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int AñoPublicacion { get; set; }
        public string ISBN { get; set; }
        public int? IdAutor { get; set; }
        public string Editorial { get; set; }
        public string Resumen { get; set; }
    }
}
