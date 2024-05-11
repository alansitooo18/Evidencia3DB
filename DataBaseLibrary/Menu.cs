using System;

namespace DataBaseLibrary
{
    class Menu
    {
        public void MostrarMenu()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Bienvenido a la base de datos de la biblioteca *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\nPor favor, seleccione una opción:\n");
            Console.WriteLine("1. Buscar información por colección");
            Console.WriteLine("2. Buscar información modelando relación");
            Console.WriteLine("3. Actualizar información");
            Console.WriteLine("4. Eliminar información");
            Console.WriteLine("5. Salir\n");
            Console.WriteLine("*****************************************");
        }

        public void MostrarMenuColecciones()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Menú de colecciones *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\nPor favor, seleccione una colección:\n");
            Console.WriteLine("1. Autores");
            Console.WriteLine("2. Libros");
            Console.WriteLine("3. Regresar al menú principal\n");
            Console.WriteLine("*****************************************");
        }

        public void MostrarMenuAutores()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Menú de autores *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\nPor favor, seleccione una opción:\n");
            Console.WriteLine("1. Buscar autores por nombre");
            Console.WriteLine("2. Buscar autores por nacionalidad");
            Console.WriteLine("3. Mostrar todos los autores");
            Console.WriteLine("4. Regresar al menú principal\n");
            Console.WriteLine("*****************************************");
        }

        public void MostrarMenuLibros()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Menú de libros *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\nPor favor, seleccione una opción:\n");
            Console.WriteLine("1. Buscar libros por título");
            Console.WriteLine("2. Buscar libros por género");
            Console.WriteLine("3. Buscar libros por año de publicación");
            Console.WriteLine("4. Mostrar todos los libros");
            Console.WriteLine("5. Regresar al menú principal\n");
            Console.WriteLine("*****************************************");
        }

        public void MostrarMenuRelacion()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Menú de relación *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\nPor favor, seleccione una opción:\n");
            Console.WriteLine("1. Buscar libros de un autor");
            Console.WriteLine("2. Buscar autor de un libro");
            Console.WriteLine("3. Regresar al menú principal\n");
            Console.WriteLine("*****************************************");
        }

        public void MostrarMenuActualizar()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Menú de actualización *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\nPor favor, seleccione una opción:\n");
            Console.WriteLine("1. Actualizar información de un autor");
            Console.WriteLine("2. Actualizar información de un libro");
            Console.WriteLine("3. Regresar al menú principal\n");
            Console.WriteLine("*****************************************");
        }

        public void MostrarMenuActualizarAutor()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Menú de actualización de autor *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\nPor favor, seleccione una opción:\n");
            Console.WriteLine("1. Actualizar nombre");
            Console.WriteLine("2. Actualizar fecha de nacimiento");
            Console.WriteLine("3. Actualizar nacionalidad");
            Console.WriteLine("4. Actualizar biografía");
            Console.WriteLine("5. Regresar al menú de actualización\n");
            Console.WriteLine("*****************************************");
        }

        public void MostrarMenuActualizarLibro()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Menú de actualización de libro *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\nPor favor, seleccione una opción:\n");
            Console.WriteLine("1. Actualizar título");
            Console.WriteLine("2. Actualizar género");
            Console.WriteLine("3. Actualizar año de publicación");
            Console.WriteLine("4. Actualizar ISBN");
            Console.WriteLine("5. Actualizar editorial");
            Console.WriteLine("6. Actualizar resumen");
            Console.WriteLine("7. Regresar al menú de actualización\n");
            Console.WriteLine("*****************************************");
        }

        public void MostrarMenuEliminar()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Menú de eliminación *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\nPor favor, seleccione una opción:\n");
            Console.WriteLine("1. Eliminar autor");
            Console.WriteLine("2. Eliminar libro");
            Console.WriteLine("3. Regresar al menú principal\n");
            Console.WriteLine("*****************************************");
        }

        public void MostrarMensajeError()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Error: Opción no válida *");
            Console.WriteLine("*****************************************");
        }

        public void MostrarMensajeSalida()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Gracias por utilizar la base de datos de la biblioteca *");
            Console.WriteLine("*****************************************");
        }
    }
}