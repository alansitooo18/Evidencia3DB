using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using DataBaseLibrary;
using Amazon.Runtime.Internal;

namespace DataBaseLibrary
{
    public class Program
    {              
        static void Main(string[] args)
        {
            // Conexión a la base de datos y colecciones
            var databaseService = new DatabaseService("mongodb://localhost:27017", "LibraryDB");

            // Creación autores
            var autores = new List<Autor>
            {
                new Autor { IdAutor = 1, Nombre = "Gabriel García Márquez", FechaNacimiento = new DateTime(1927, 3, 6), Nacionalidad = "Colombiano", Biografia = "Gabriel José de la Concordia García Márquez fue un escritor, guionista, editor y periodista colombiano. En 1982 recibió el Premio Nobel de Literatura." },
                new Autor { IdAutor = 2, Nombre = "Julio Cortázar", FechaNacimiento = new DateTime(1914, 8, 26), Nacionalidad = "Argentino", Biografia = "Julio Florencio Cortázar fue un escritor, traductor e intelectual argentino. Es uno de los autores más innovadores y originales de su tiempo, maestro del relato corto, la prosa poética y la narrativa." },
                new Autor { IdAutor = 3, Nombre = "Mario Vargas Llosa", FechaNacimiento = new DateTime(1936, 3, 28), Nacionalidad = "Peruano", Biografia = "Jorge Mario Pedro Vargas Llosa, conocido como Mario Vargas Llosa, es un escritor, político, periodista y ensayista peruano, nacionalizado español en 1993. Se le considera una de las figuras más importantes e influyentes de la literatura contemporánea." },
                new Autor { IdAutor = 4, Nombre = "Pablo Neruda", FechaNacimiento = new DateTime(1904, 7, 12), Nacionalidad = "Chileno", Biografia = "Ricardo Eliécer Neftalí Reyes Basoalto, conocido como Pablo Neruda, fue un poeta chileno, considerado entre los más destacados e influyentes artistas de su siglo; «el más grande poeta del siglo XX en cualquier idioma», según Gabriel García Márquez." },
                new Autor { IdAutor = 5, Nombre = "Isabel Allende", FechaNacimiento = new DateTime(1942, 8, 2), Nacionalidad = "Chileno", Biografia = "Isabel Allende Llona es una escritora chilena, miembro de la Academia Estadounidense de las Artes y las Letras desde 2004. Ha vendido más de 74 millones de ejemplares. Su obra ha sido traducida a más de 27 idiomas." },
                new Autor { IdAutor = 6, Nombre = "Jorge Luis Borges", FechaNacimiento = new DateTime(1899, 8, 24), Nacionalidad = "Argentino", Biografia = "Jorge Francisco Isidoro Luis Borges Acevedo fue un escritor, poeta, ensayista y bibliotecario argentino, uno de los autores más destacados de la literatura del siglo XX. Nacido en una familia de larga tradición militar." },
                new Autor { IdAutor = 7, Nombre = "Carlos Fuentes", FechaNacimiento = new DateTime(1928, 11, 11), Nacionalidad = "Mexicano", Biografia = "Carlos Fuentes Macías fue un escritor, guionista y diplomático mexicano. Es considerado como uno de los autores más destacados de la literatura en lengua española del siglo XX. Su obra abarca diversos géneros y registra una constante preocupación por los problemas políticos, sociales y morales de la realidad mexicana y universal." }
            };

            // Creación libros
            var libros = new List<Libro>
            {
                new Libro { Id = ObjectId.GenerateNewId(), Titulo = "Cien años de soledad", Genero = "Novela", AñoPublicacion = 1967, ISBN = "978-8437604947", IdAutor = 1, Editorial = "Editorial Sudamericana", Resumen = "La novela cuenta la historia de la familia Buendía a lo largo de siete generaciones en el pueblo ficticio de Macondo." },
                new Libro { Id = ObjectId.GenerateNewId(), Titulo = "Rayuela", Genero = "Novela", AñoPublicacion = 1963, ISBN = "978-9875666461", IdAutor = 2, Editorial = "Editorial Sudamericana", Resumen = "Una novela que se puede leer de varias maneras y no tiene un argumento fijo." },
                new Libro { Id = ObjectId.GenerateNewId(), Titulo = "La fiesta del chivo", Genero = "Novela histórica", AñoPublicacion = 2000, ISBN = "978-8420434640", IdAutor = 3, Editorial = "Alfaguara", Resumen = "Narra los últimos días de la dictadura de Trujillo en República Dominicana." },
                new Libro { Id = ObjectId.GenerateNewId(), Titulo = "Veinte poemas de amor y una canción desesperada", Genero = "Poesía", AñoPublicacion = 1924, ISBN = "978-9561225755", IdAutor = 4, Editorial = "Nascimento", Resumen = "Uno de los más famosos libros de Pablo Neruda, que consta de 20 poemas de amor." },
                new Libro { Id = ObjectId.GenerateNewId(), Titulo = "La casa de los espíritus", Genero = "Novela", AñoPublicacion = 1982, ISBN = "978-9500700515", IdAutor = 5, Editorial = "Editorial Sudamericana", Resumen = "Narrativa que relata la saga de la familia Trueba durante varias generaciones en Chile." },
                new Libro { Id = ObjectId.GenerateNewId(), Titulo = "Ficciones", Genero = "Cuentos", AñoPublicacion = 1944, ISBN = "978-8420633129", IdAutor = 6, Editorial = "Emecé Editores", Resumen = "Colección de cuentos en los que Jorge Luis Borges juega con elaboradas tramas de ironía y sombras de lo sobrenatural." },
                new Libro { Id = ObjectId.GenerateNewId(), Titulo = "Aura", Genero = "Novela corta", AñoPublicacion = 1962, ISBN = "978-9684111812", IdAutor = 7, Editorial = "Era", Resumen = "Una novela corta que explora los temas de la identidad y la realidad a través de la historia de un joven historiador contratado para editar las memorias de un general del siglo XIX." },
                new Libro { Id = ObjectId.GenerateNewId(), Titulo = "El amor en los tiempos del cólera", Genero = "Novela", AñoPublicacion = 1985, ISBN = "978-8432216427", IdAutor = 1, Editorial = "Editorial Sudamericana", Resumen = "La historia de amor entre Fermina Daza y Florentino Ariza." },
                new Libro { Id = ObjectId.GenerateNewId(), Titulo = "Bestiario", Genero = "Cuentos", AñoPublicacion = 1951, ISBN = "978-9875666454", IdAutor = 2, Editorial = "Editorial Sudamericana", Resumen = "Una colección de ocho cuentos que exploran lo inusual y lo fantástico." },
                new Libro { Id = ObjectId.GenerateNewId(), Titulo = "El coronel no tiene quien le escriba", Genero = "Novela", AñoPublicacion = 1961, ISBN = "978-8439728280", IdAutor = 1, Editorial = "Editorial Sudamericana", Resumen = "La historia de un veterano de guerra que espera la pensión que nunca llega." }
            };

            // Insertar los datos en las coleeciones
            databaseService.InsertAutores(autores);
            databaseService.InsertLibros(libros);

            bool continuar = true;
            while (continuar)
            {
                Menu menu = new Menu();
                menu.MostrarMenu();
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Switches.BuscarInformacionPorColeccion();
                        break;
                    case "2":
                        Switches.BuscarInformacionModelandoRelacion();
                        break;
                    case "3":
                        Switches.ActualizarInformacion();
                        break;
                    case "4":
                        Switches.EliminarInformacion();
                        break;
                    case "5":
                        menu.MostrarMensajeSalida();
                        continuar = false;
                        break;
                    default:
                        menu.MostrarMensajeError();
                        break;
                }
            }
        }
    }
}