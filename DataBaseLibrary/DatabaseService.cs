using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseLibrary
{
    public class DatabaseService
    {
        private IMongoCollection<Autor> collectionAutores;
        private IMongoCollection<Libro> collectionLibros;

        public DatabaseService(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            collectionAutores = database.GetCollection<Autor>("Autores");
            collectionLibros = database.GetCollection<Libro>("Libros");
        }

        public void InsertAutores(List<Autor> autores)
        {
            foreach (var autor in autores)
            {
                var exists = collectionAutores.Find(x => x.IdAutor == autor.IdAutor).Any();
                if (!exists)
                {
                    collectionAutores.InsertOne(autor);
                }
            }
        }

        public void InsertLibros(List<Libro> libros)
        {
            foreach (var libro in libros)
            {
                var exists = collectionLibros.Find(x => x.ISBN == libro.ISBN).Any();
                if (!exists)
                {
                    collectionLibros.InsertOne(libro);
                }
            }
        }

        public List<Autor> GetAutoresPorNombre(string nombre)
        {
            return collectionAutores.Find(x => x.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
        }

        public List<Autor> GetAutoresPorNacionalidad(string nacionalidad)
        {
            return collectionAutores.Find(x => x.Nacionalidad.ToLower() == nacionalidad.ToLower()).ToList();
        }

        public List<Libro> GetLibrosPorTitulo(string titulo)
        {
            return collectionLibros.Find(x => x.Titulo.ToLower().Contains(titulo.ToLower())).ToList();
        }

        public List<Libro> GetLibrosPorGenero(string genero)
        {
            return collectionLibros.Find(x => x.Genero.ToLower() == genero.ToLower()).ToList();
        }

        public List<Libro> GetLibrosPorAñoPublicacion(int año)
        {
            return collectionLibros.Find(x => x.AñoPublicacion == año).ToList();
        }

        public Autor GetAutorDeLibro(ObjectId idLibro)
        {
            var libro = collectionLibros.Find(x => x.Id == idLibro).FirstOrDefault();
            return collectionAutores.Find(x => x.IdAutor == libro.IdAutor).FirstOrDefault();
        }

        public List<Libro> GetLibrosDeAutor(int idAutor)
        {
            return collectionLibros.Find(x => x.IdAutor == idAutor).ToList();
        }
    }
}
