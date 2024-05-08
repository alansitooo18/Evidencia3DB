using System;
using System.Security.Cryptography.X509Certificates;
using DataBaseLibrary;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataBaseLibrary
{
    public static class Switches
    {
        static Menu menu = new Menu();
        static DatabaseService databaseService = new DatabaseService("mongodb://localhost:27017", "LibraryDB");

        public static void BuscarInformacionPorColeccion()
        {
            menu.MostrarMenuColecciones();
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    menu.MostrarMenuAutores();
                    string opcionAutor = Console.ReadLine().ToLower();
                    switch (opcionAutor)
                    {
                        case "1":
                            Console.WriteLine("Ingrese el nombre del autor:");
                            string nombreAutor = Console.ReadLine();
                            // Implementar lógica para buscar autores por nombre y que no distinga entre mayúsculas y minúsculas
                            var autoresNombre = databaseService.GetAutoresPorNombre(nombreAutor);
                            if (autoresNombre.Any())
                            {
                                foreach (var autor in autoresNombre)
                                {
                                    Console.WriteLine($"Nombre: {autor.Nombre}");
                                    Console.WriteLine($"Fecha de nacimiento: {autor.FechaNacimiento}");
                                    Console.WriteLine($"Nacionalidad: {autor.Nacionalidad}");
                                    Console.WriteLine($"Biografía: {autor.Biografia}");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron autores con ese nombre.");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Ingrese la nacionalidad del autor:");
                            string nacionalidadAutor = Console.ReadLine();
                            // Implementar lógica para buscar autores por nacionalidad
                            var autoresNacionalidad = databaseService.GetAutoresPorNacionalidad(nacionalidadAutor);
                            if (autoresNacionalidad.Any())
                            {
                                foreach (var autor in autoresNacionalidad)
                                {
                                    Console.WriteLine($"Nombre: {autor.Nombre}");
                                    Console.WriteLine($"Fecha de nacimiento: {autor.FechaNacimiento}");
                                    Console.WriteLine($"Nacionalidad: {autor.Nacionalidad}");
                                    Console.WriteLine($"Biografía: {autor.Biografia}");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron autores con esa nacionalidad.");
                            }
                            break;
                        case "3":
                            break;
                        default:
                            menu.MostrarMensajeError();
                            break;
                    }
                    break;
                case "2":
                    menu.MostrarMenuLibros();
                    string opcionLibro = Console.ReadLine();
                    switch (opcionLibro)
                    {
                        case "1":
                            Console.WriteLine("Ingrese el título del libro:");
                            string tituloLibro = Console.ReadLine();
                            // Implementar lógica para buscar libros por título
                            var libros = databaseService.GetLibrosPorTitulo(tituloLibro);
                            if (libros.Any())
                            {
                                foreach (var libro in libros)
                                {
                                    Console.WriteLine($"Título: {libro.Titulo}");
                                    Console.WriteLine($"Género: {libro.Genero}");
                                    Console.WriteLine($"Año de publicación: {libro.AñoPublicacion}");
                                    Console.WriteLine($"ISBN: {libro.ISBN}");
                                    Console.WriteLine($"Editorial: {libro.Editorial}");
                                    Console.WriteLine($"Resumen: {libro.Resumen}");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron libros con ese título.");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Ingrese el género del libro:");
                            string generoLibro = Console.ReadLine();
                            // Implementar lógica para buscar libros por género
                            var librosGenero = databaseService.GetLibrosPorGenero(generoLibro);
                            if (librosGenero.Any())
                            {
                                foreach (var libro in librosGenero)
                                {
                                    Console.WriteLine($"Título: {libro.Titulo}");
                                    Console.WriteLine($"Género: {libro.Genero}");
                                    Console.WriteLine($"Año de publicación: {libro.AñoPublicacion}");
                                    Console.WriteLine($"ISBN: {libro.ISBN}");
                                    Console.WriteLine($"Editorial: {libro.Editorial}");
                                    Console.WriteLine($"Resumen: {libro.Resumen}");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron libros con ese género.");
                            }
                            break;
                        case "3":
                            Console.WriteLine("Ingrese el año de publicación del libro:");
                            int añoLibro = int.Parse(Console.ReadLine());
                            // Implementar lógica para buscar libros por año de publicación
                            var librosAño = databaseService.GetLibrosPorAñoPublicacion(añoLibro);
                            if (librosAño.Any())
                            {
                                foreach (var libro in librosAño)
                                {
                                    Console.WriteLine($"Título: {libro.Titulo}");
                                    Console.WriteLine($"Género: {libro.Genero}");
                                    Console.WriteLine($"Año de publicación: {libro.AñoPublicacion}");
                                    Console.WriteLine($"ISBN: {libro.ISBN}");
                                    Console.WriteLine($"Editorial: {libro.Editorial}");
                                    Console.WriteLine($"Resumen: {libro.Resumen}");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron libros con ese año de publicación.");
                            }
                            break;
                        case "4":
                            break;
                        default:
                            menu.MostrarMensajeError();
                            break;
                    }
                    break;
                case "3":
                    break;
                default:
                    menu.MostrarMensajeError();
                    break;
            }
        }

        public static void BuscarInformacionModelandoRelacion()
        {
            menu.MostrarMenuRelacion();
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    // Buscar libros de un autor específico
                    Console.WriteLine("Ingrese el nombre del autor:");
                    string nombreAutor = Console.ReadLine();
                    var autor = databaseService.GetAutoresPorNombre(nombreAutor).FirstOrDefault();
                    if (autor != null)
                    {
                        var librosAutor = databaseService.GetLibrosDeAutor(autor.IdAutor);
                        if (librosAutor.Any())
                        {
                            foreach (var libroAutor in librosAutor)
                            {
                                Console.WriteLine($"Título: {libroAutor.Titulo}");
                                Console.WriteLine($"Género: {libroAutor.Genero}");
                                Console.WriteLine($"Año de publicación: {libroAutor.AñoPublicacion}");
                                Console.WriteLine($"ISBN: {libroAutor.ISBN}");
                                Console.WriteLine($"Editorial: {libroAutor.Editorial}");
                                Console.WriteLine($"Resumen: {libroAutor.Resumen}");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron libros del autor.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el autor.");
                    }
                    break;
                case "2":
                    // Buscar autor de un libro específico
                    Console.WriteLine("Ingrese el nombre del libro:");
                    string tituloLibro = Console.ReadLine();
                    var libro = databaseService.GetLibrosPorTitulo(tituloLibro).FirstOrDefault();
                    if (libro != null)
                    {
                        var autorLibro = databaseService.GetAutorDeLibro(libro.Id);
                        if (autorLibro != null)
                        {
                            Console.WriteLine($"Autor: {autorLibro.Nombre}");
                            Console.WriteLine($"Fecha de nacimiento: {autorLibro.FechaNacimiento}");
                            Console.WriteLine($"Nacionalidad: {autorLibro.Nacionalidad}");
                            Console.WriteLine($"Biografía: {autorLibro.Biografia}");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el autor del libro.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el libro.");
                    }
                    break;
                case "3":
                    break;
                default:
                    menu.MostrarMensajeError();
                    break;
            }
        }

        public static void ActualizarInformacion()
        {
            menu.MostrarMenuActualizar();
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    // Implementar lógica para actualizar información de un autor
                    break;
                case "2":
                    // Implementar lógica para actualizar información de un libro
                    break;
                case "3":
                    break;
                default:
                    menu.MostrarMensajeError();
                    break;
            }
        }

        public static void EliminarInformacion()
        {
            menu.MostrarMenuEliminar();
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    // Implementar lógica para eliminar un autor
                    break;
                case "2":
                    // Implementar lógica para eliminar un libro
                    break;
                case "3":
                    break;
                default:
                    menu.MostrarMensajeError();
                    break;
            }
        }
    }
}
