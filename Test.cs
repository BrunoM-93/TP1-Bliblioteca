using System;

namespace DSOO_Grupo14_TP1
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            // Precargamos algunos libros para poder mostrar al listar libros
            biblioteca.agregarLibro("El Principito", "Antoine de Saint-Exupéry", "Editorial Salamandra");
            biblioteca.agregarLibro("Cien Años de Soledad", "Gabriel García Márquez", "Sudamericana");
            biblioteca.agregarLibro("Rayuela", "Julio Cortázar", "Sudamericana");
            biblioteca.agregarLibro("1984", "George Orwell", "Planeta");
            biblioteca.agregarLibro("Crimen y Castigo", "Fiódor Dostoievski", "Editorial Alianza");
            biblioteca.agregarLibro("Armada", "Ernest Cline", "Planeta");
            // Precargamos algunos usuarios
            biblioteca.altaLector("Jose", "33552257");
            biblioteca.altaLector("Martina", "31685604");
            biblioteca.altaLector("Sofia", "32065933");
            string opcion;

            do
            {
                Console.WriteLine("\n--- MENU BIBLIOTECA ---");
                Console.WriteLine("1. Buscar libro por titulo");
                Console.WriteLine("2. Agregar libro");
                Console.WriteLine("3. Eliminar libro");
                Console.WriteLine("4. Listar libros");
                Console.WriteLine("5. Alta lector");
                Console.WriteLine("6. Baja lector");
                Console.WriteLine("7. Listar lectores registrados");
                Console.WriteLine("8. Mostrar libros prestados por lector");
                Console.WriteLine("9. Prestar libro");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese el titulo del libro: ");
                        string tituloBusqueda = Console.ReadLine();
                        Libro encontrado = biblioteca.obtenerLibroPorTitulo(tituloBusqueda);
                        if (encontrado != null)
                            Console.WriteLine("Libro encontrado: " + encontrado);
                        else
                            Console.WriteLine("El libro no existe.");
                        break;
                    case "2":
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("Editorial: ");
                        string editorial = Console.ReadLine();
                        if (biblioteca.agregarLibro(titulo, autor, editorial))
                            Console.WriteLine("Libro agregado exitosamente.");
                        else
                            Console.WriteLine("El libro ya existe.");
                        break;
                    // Eliminar libro
                    case "3":
                        Console.WriteLine("Ingrese el titulo del libro a eliminar: ");
                        string tituloEliminar = Console.ReadLine();
                        if (biblioteca.eliminarLibro(tituloEliminar))
                            Console.WriteLine("Libro eliminado correctamente.");
                        else
                            Console.WriteLine("Libro no encontrado.");
                        break;
                    // Listar libros
                    case "4":
                        Console.WriteLine("Libros en la biblioteca:");
                        biblioteca.listarLibros();
                        break;
                    // Alta lector
                    case "5":
                        Console.Write("Nombre del lector: ");
                        string nombre = Console.ReadLine();
                        Console.Write("DNI del lector: ");
                        string dni = Console.ReadLine();
                        Console.WriteLine(biblioteca.altaLector(nombre, dni));
                        break;
                    // Baja lector
                    case "6":
                        Console.WriteLine("Ingrese el DNI del lector a dar de baja: ");
                        string dniBaja = Console.ReadLine();
                        Console.WriteLine(biblioteca.bajaLector(dniBaja));
                        break;
                    // Listar lectores registrados
                    case "7":
                        biblioteca.listarLectores();
                        break;
                    // Mostrar libros prestados por lector
                    case "8":
                        biblioteca.listarLectoresConPrestamos();
                        break;
                    // Prestar libro
                    case "9":
                        Console.Write("Título del libro a prestar: ");
                        string tituloPrestamo = Console.ReadLine();
                        Console.Write("DNI del lector: ");
                        string dniPrestamo = Console.ReadLine();
                        Console.WriteLine(biblioteca.prestarLibro(tituloPrestamo, dniPrestamo));
                        break;
                    // Salir menu
                    case "0":
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            } while (opcion != "0");
        }
    }
}
