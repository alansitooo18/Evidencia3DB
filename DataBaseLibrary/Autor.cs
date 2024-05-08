using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataBaseLibrary
{
    public class Autor
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Biografia { get; set; }
    }
}
