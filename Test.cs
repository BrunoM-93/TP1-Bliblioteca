using System;

namespace DSOO_Grupo14_TP1
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            cargarLibros(10);
            cargarLibros(2);

            biblioteca.listarLibros();
            biblioteca.eliminarLibro("Libro5");
            biblioteca.agregarLibro("Metro 2033", "Dmitri Glujovski", "Booket");

            void cargarLibros(int cantidad)
            {
                bool pude;
                for (int i = 1; i <= cantidad; i++)
                {
                    pude = biblioteca.agregarLibro("Libro" + i, "Autor" + i, "Editorial" + i);
                    if (pude)
                        Console.WriteLine("libro" + i + " agregado correctamente.");
                    else
                        Console.WriteLine("libro" + i + " Ya existe en la biblioteca.");
                }
            }
        }
    }
}
