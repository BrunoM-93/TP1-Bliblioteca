using System;
using System.Collections.Generic;
using System.Text;

namespace DSOO_Grupo14_TP1
{
    internal class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;   // Lista que contiene los lectores

        public Biblioteca()
        {
            this.libros = new List<Libro>();
        }

        private Libro buscarLibro(string titulo)
        {
            Libro libroBuscado = null;
            int i = 0;
            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo))
                i++;
            if (i != libros.Count)
                libroBuscado = libros[i];
            return libroBuscado;
        }

        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado = false;
            Libro libro;
            libro = buscarLibro(titulo);
            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                libros.Add(libro);
                resultado = true;
            }
            return resultado;
        }

        public void listarLibros()
        {
            foreach (var libro in libros)
                Console.WriteLine(libro);
        }

        public bool eliminarLibro(string titulo)
        {
            bool resultado = false;
            Libro libro;
            libro = buscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                resultado = true;
            }
            return resultado;
        }

        // Agrega un lector si no está registrado
        public void altaLector(string nombre, string dni)
        {
            if (lectores == null)
                lectores = new List<Lector>();

            bool existe = false;
            foreach (Lector l in lectores)
            {
                if (l.getDni().Equals(dni))
                {
                    existe = true;
                    break;
                }
            }

            // Si el Lector no existe (existe=false) lo agrega
            if (!existe)
            {
                Lector nuevo = new Lector(nombre, dni);
                lectores.Add(nuevo);
            }
        }

        // Presta un libro a un lector si cumple las condiciones
        public string prestarLibro(string titulo, string dni)
        {
            // Control no se inicializó Lector o la lista esta vacía
            if (lectores == null || lectores.Count == 0)  
                return "LECTOR INEXISTENTE";

            // Buscar lector
            Lector lectorEncontrado = null;
            foreach (Lector l in lectores)
            {
                if (l.getDni().Equals(dni))
                {
                    lectorEncontrado = l;
                    break;
                }
            }

            if (lectorEncontrado == null)
                return "LECTOR INEXISTENTE";

            // Verificar tope de préstamo
            if (lectorEncontrado.cantidadPrestamos() >= 3)
                return "TOPE DE PRESTAMO ALCAZADO";

            // Buscar libro
            Libro libro = buscarLibro(titulo);
            if (libro == null)
                return "LIBRO INEXISTENTE";

            // Prestar libro
            libros.Remove(libro); // lo quitamos de la biblioteca
            lectorEncontrado.agregarPrestamo(libro); // lo agregamos al lector
            return "PRESTAMO EXITOSO";
        }
    }
}
