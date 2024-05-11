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
                            // Buscar autores por nombre y que no distinga entre mayúsculas y minúsculas
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
                            // Buscar autores por nacionalidad
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
                            // Mostrar todos los autores
                            var autores = databaseService.GetAutores();
                            if (autores.Any())
                            {
                                foreach (var autor in autores)
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
                                Console.WriteLine("No se encontraron autores.");
                            }
                            break;
                        case "4":
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
                    menu.MostrarMenuActualizarAutor();
                    string opcionAutor = Console.ReadLine();
                    switch (opcionAutor)
                    {
                        case "1":
                            Console.WriteLine("Ingrese el nombre del autor:");
                            string nombreAutor = Console.ReadLine();
                            Console.WriteLine("Ingrese el nuevo nombre del autor:");
                            string nuevoNombre = Console.ReadLine();
                            // Actualizar nombre de autor
                            var autores = databaseService.GetAutoresPorNombre(nombreAutor);
                            if (autores.Any())
                            {
                                foreach (var autor in autores)
                                {
                                    databaseService.ActualizarNombreAutor(autor.IdAutor, nuevoNombre);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron autores con ese nombre.");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Ingrese el nombre del autor:");
                            string nombreAutorFecha = Console.ReadLine();
                            Console.WriteLine("Ingrese la nueva fecha de nacimiento del autor:");
                            DateTime nuevaFecha = DateTime.Parse(Console.ReadLine());
                            // Actualizar fecha de nacimiento de autor
                            var autoresFecha = databaseService.GetAutoresPorNombre(nombreAutorFecha);
                            if (autoresFecha.Any())
                            {
                                foreach (var autor in autoresFecha)
                                {
                                    databaseService.ActualizarFechaNacimientoAutor(autor.IdAutor, nuevaFecha);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron autores con esa fecha de nacimiento.");
                            }
                            break;
                        case "3":
                            Console.WriteLine("Ingrese el nombre del autor:");
                            string nombreAutorNacionalidad = Console.ReadLine();
                            Console.WriteLine("Ingrese la nueva nacionalidad del autor:");
                            string nuevaNacionalidad = Console.ReadLine();
                            // Actualizar nacionalidad de autor
                            var autoresNacionalidad = databaseService.GetAutoresPorNombre(nombreAutorNacionalidad);
                            if (autoresNacionalidad.Any())
                            {
                                foreach (var autor in autoresNacionalidad)
                                {
                                    databaseService.ActualizarNacionalidadAutor(autor.IdAutor, nuevaNacionalidad);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron autores con esa nacionalidad.");
                            }
                            break;
                        case "4":
                            Console.WriteLine("Ingrese el nombre del autor:");
                            string nombreAutorBiografia = Console.ReadLine();
                            Console.WriteLine("Ingrese la nueva biografía del autor:");
                            string nuevaBiografia = Console.ReadLine();
                            // Actualizar biografía de autor
                            var autoresBiografia = databaseService.GetAutoresPorNombre(nombreAutorBiografia);
                            if (autoresBiografia.Any())
                            {
                                foreach (var autor in autoresBiografia)
                                {
                                    databaseService.ActualizarBiografiaAutor(autor.IdAutor, nuevaBiografia);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron autores con esa biografía.");
                            }
                            break;
                        case "5":
                            break;
                        default:
                            menu.MostrarMensajeError();
                            break;
                    }
                    break;
                case "2":
                    menu.MostrarMenuActualizarLibro();
                    string opcionLibro = Console.ReadLine();
                    switch (opcionLibro)
                    {
                        case "1":
                            Console.WriteLine("Ingrese el título del libro:");
                            string tituloLibro = Console.ReadLine();
                            Console.WriteLine("Ingrese el nuevo título del libro:");
                            string nuevoTitulo = Console.ReadLine();
                            // Actualizar título de un libro
                            var libros = databaseService.GetLibrosPorTitulo(tituloLibro);
                            if (libros.Any())
                            {
                                foreach (var libro in libros)
                                {
                                    databaseService.ActualizarTituloLibro(libro.Id, nuevoTitulo);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron libros con ese título.");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Ingrese el título del libro:");
                            string tituloLibroGenero = Console.ReadLine();
                            Console.WriteLine("Ingrese el nuevo género del libro:");
                            string nuevoGenero = Console.ReadLine();
                            // Actualizar género de un libro
                            var librosGenero = databaseService.GetLibrosPorTitulo(tituloLibroGenero);
                            if (librosGenero.Any())
                            {
                                foreach (var libro in librosGenero)
                                {
                                    databaseService.ActualizarGeneroLibro(libro.Id, nuevoGenero);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron libros con ese género.");
                            }
                            break;
                        case "3":
                            Console.WriteLine("Ingrese el título del libro:");
                            string tituloLibroAño = Console.ReadLine();
                            Console.WriteLine("Ingrese el nuevo año de publicación del libro:");
                            int nuevoAño = int.Parse(Console.ReadLine());
                            // Actualizar Año de publicación de un libro
                            var librosAño = databaseService.GetLibrosPorTitulo(tituloLibroAño);
                            if (librosAño.Any())
                            {
                                foreach (var libro in librosAño)
                                {
                                    databaseService.ActualizarAñoPublicacionLibro(libro.Id, nuevoAño);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron libros con ese año de publicación.");
                            }
                            break;
                        case "4":
                            Console.WriteLine("Ingrese el título del libro:");
                            string tituloLibroISBN = Console.ReadLine();
                            Console.WriteLine("Ingrese el nuevo ISBN del libro:");
                            string nuevoISBN = Console.ReadLine();
                            // Actualizar ISBN de un libro
                            var librosISBN = databaseService.GetLibrosPorTitulo(tituloLibroISBN);
                            if (librosISBN.Any())
                            {
                                foreach (var libro in librosISBN)
                                {
                                    databaseService.ActualizarISBNLibro(libro.Id, nuevoISBN);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron libros con ese ISBN.");
                            }
                            break;
                        case "5":
                            Console.WriteLine("Ingrese el título del libro:");
                            string tituloLibroEditorial = Console.ReadLine();
                            Console.WriteLine("Ingrese la nueva editorial del libro:");
                            string nuevaEditorial = Console.ReadLine();
                            // Actualizar editorial de un libro
                            var librosEditorial = databaseService.GetLibrosPorTitulo(tituloLibroEditorial);
                            if (librosEditorial.Any())
                            {
                                foreach (var libro in librosEditorial)
                                {
                                    databaseService.ActualizarEditorialLibro(libro.Id, nuevaEditorial);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron libros con esa editorial.");
                            }
                            break;
                        case "6":
                            Console.WriteLine("Ingrese el título del libro:");
                            string tituloLibroResumen = Console.ReadLine();
                            Console.WriteLine("Ingrese el nuevo resumen del libro:");
                            string nuevoResumen = Console.ReadLine();
                            // Actualizar resumen de un libro
                            var librosResumen = databaseService.GetLibrosPorTitulo(tituloLibroResumen);
                            if (librosResumen.Any())
                            {
                                foreach (var libro in librosResumen)
                                {
                                    databaseService.ActualizarResumenLibro(libro.Id, nuevoResumen);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron libros con ese resumen.");
                            }
                            break;
                        case "7":
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

        public static void EliminarInformacion()
        {
            menu.MostrarMenuEliminar();
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Ingrese el nombre del autor:");
                    string nombreAutor = Console.ReadLine();
                    // Eliminar un autor
                    var autores = databaseService.GetAutoresPorNombreExacto(nombreAutor);
                    if (autores.Any())
                    {
                        foreach (var autor in autores)
                        {
                            databaseService.EliminarAutor(autor.IdAutor);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron autores con ese nombre.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Ingrese el título del libro:");
                    string tituloLibro = Console.ReadLine();
                    // Eliminar un libro
                    var libros = databaseService.GetLibrosPorTituloExacto(tituloLibro);
                    if (libros.Any())
                    {
                        foreach (var libro in libros)
                        {
                            databaseService.EliminarLibro(libro.Id);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron libros con ese título.");
                    }
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
