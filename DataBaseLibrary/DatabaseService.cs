using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;


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

        public List<Autor> GetAutores()
        {
            return collectionAutores.Find(_ => true).ToList();
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

        public List<Libro> GetLibros()
        {
            return collectionLibros.Find(_ => true).ToList();
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

        public void ActualizarNombreAutor(int idAutor, string nuevoNombre)
        {
            var filter = Builders<Autor>.Filter.Eq(x => x.IdAutor, idAutor);
            var update = Builders<Autor>.Update.Set(x => x.Nombre, nuevoNombre);
            collectionAutores.UpdateOne(filter, update);
        }

        public void ActualizarFechaNacimientoAutor(int idAutor, DateTime nuevaFecha)
        {
            var filter = Builders<Autor>.Filter.Eq(x => x.IdAutor, idAutor);
            var update = Builders<Autor>.Update.Set(x => x.FechaNacimiento, nuevaFecha);
            collectionAutores.UpdateOne(filter, update);
        }

        public void ActualizarNacionalidadAutor(int idAutor, string nuevaNacionalidad)
        {
            var filter = Builders<Autor>.Filter.Eq(x => x.IdAutor, idAutor);
            var update = Builders<Autor>.Update.Set(x => x.Nacionalidad, nuevaNacionalidad);
            collectionAutores.UpdateOne(filter, update);
        }

        public void ActualizarBiografiaAutor(int idAutor, string nuevaBiografia)
        {
            var filter = Builders<Autor>.Filter.Eq(x => x.IdAutor, idAutor);
            var update = Builders<Autor>.Update.Set(x => x.Biografia, nuevaBiografia);
            collectionAutores.UpdateOne(filter, update);
        }

        public void ActualizarTituloLibro(ObjectId idLibro, string nuevoTitulo)
        {
            var filter = Builders<Libro>.Filter.Eq(x => x.Id, idLibro);
            var update = Builders<Libro>.Update.Set(x => x.Titulo, nuevoTitulo);
            collectionLibros.UpdateOne(filter, update);
        }

        public void ActualizarGeneroLibro(ObjectId idLibro, string nuevoGenero)
        {
            var filter = Builders<Libro>.Filter.Eq(x => x.Id, idLibro);
            var update = Builders<Libro>.Update.Set(x => x.Genero, nuevoGenero);
            collectionLibros.UpdateOne(filter, update);
        }

        public void ActualizarAñoPublicacionLibro(ObjectId idLibro, int nuevoAño)
        {
            var filter = Builders<Libro>.Filter.Eq(x => x.Id, idLibro);
            var update = Builders<Libro>.Update.Set(x => x.AñoPublicacion, nuevoAño);
            collectionLibros.UpdateOne(filter, update);
        }

        public void ActualizarISBNLibro(ObjectId idLibro, string nuevoISBN)
        {
            var filter = Builders<Libro>.Filter.Eq(x => x.Id, idLibro);
            var update = Builders<Libro>.Update.Set(x => x.ISBN, nuevoISBN);
            collectionLibros.UpdateOne(filter, update);
        }

        public void ActualizarEditorialLibro(ObjectId idLibro, string nuevaEditorial)
        {
            var filter = Builders<Libro>.Filter.Eq(x => x.Id, idLibro);
            var update = Builders<Libro>.Update.Set(x => x.Editorial, nuevaEditorial);
            collectionLibros.UpdateOne(filter, update);
        }

        public void ActualizarResumenLibro(ObjectId idLibro, string nuevoResumen)
        {
            var filter = Builders<Libro>.Filter.Eq(x => x.Id, idLibro);
            var update = Builders<Libro>.Update.Set(x => x.Resumen, nuevoResumen);
            collectionLibros.UpdateOne(filter, update);
        }

        public void EliminarAutor(int idAutor)
        {
            // Encuentra el autor en la base de datos
            var autor = collectionAutores.Find(x => x.IdAutor == idAutor).FirstOrDefault();
            if (autor != null)
            {
                // Encuentra todos los libros asociados con este autor
                var librosAutor = collectionLibros.Find(l => l.IdAutor == idAutor).ToList();

                // Actualiza el IdAutor de estos libros a null en la base de datos
                var update = Builders<Libro>.Update.Set(l => l.IdAutor, null);
                foreach (var libro in librosAutor)
                {
                    collectionLibros.UpdateOne(Builders<Libro>.Filter.Eq("ISBN", libro.ISBN), update);
                }

                // Elimina el autor de la base de datos
                collectionAutores.DeleteOne(x => x.IdAutor == idAutor);
            }
        }


        public List<Autor> GetAutoresPorNombreExacto(string nombre)
        {
            // Que sea nombre exacto, no solo uno que contenga el nombre
            return collectionAutores.Find(x => x.Nombre == nombre).ToList();
        }

        public void EliminarLibro(ObjectId idLibro)
        {
            collectionLibros.DeleteOne(x => x.Id == idLibro);
        }

        public List<Libro> GetLibrosPorTituloExacto(string nombre)
        {
            return collectionLibros.Find(x => x.Titulo == nombre).ToList();
        }

        public Autor GetAutorPorId(int idAutor)
        {
            return collectionAutores.Find(x => x.IdAutor == idAutor).FirstOrDefault();
        }
    }
}
