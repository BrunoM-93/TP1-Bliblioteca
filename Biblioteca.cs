using System;
using System.Collections.Generic;
using System.Text;

namespace DSOO_Grupo14_TP1
{
    internal class Biblioteca
    {
        private List<Libro> libros; // Lista que contiene los libros
        private List<Lector> lectores;  // Lista que contiene los lectores
        public Biblioteca()
        {
            this.libros = new List<Libro>();    // Inicializamos la lista libros
            this.lectores = new List<Lector>(); // Inicializamos la lista lectores
        }
        private Libro buscarLibro(string titulo)
        {
            Libro libroBuscado = null;
            int i = 0;
            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo, StringComparison.OrdinalIgnoreCase))
                i++;
            if (i != libros.Count)
                libroBuscado = libros[i];
            return libroBuscado;
        }
        // Buscar libro por titulo desde el menu
        public Libro obtenerLibroPorTitulo(string titulo)
        {
            return buscarLibro(titulo);
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
        // Listar lectores registrados
        public void listarLectores()
        {
            if (lectores == null || lectores.Count == 0)
            {
                Console.WriteLine("No hay lectores registrados.");
                return;
            }
            Console.WriteLine("Lectores registrados: ");
            foreach (Lector lector in lectores)
            {
                Console.WriteLine($"- {lector.getNombre()} (DNI: {lector.getDni()})");
            }
        }
        // Metodo para validar DNI
        private bool validarDni(string dni)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d{8}$");
        }
        // Agrega un lector si no está registrado
        public string altaLector(string nombre, string dni)
        {
            if (!validarDni(dni))
                return "DNI inválido. Debe contener exactamente 8 dígitos numéricos.";

            foreach (Lector l in lectores)
            {
                if (l.getDni().Trim().Equals(dni.Trim()))
                    return "El lector ya existe.";
            }
            // Si el Lector no existe (existe=false) lo agrega
            Lector nuevo = new Lector(nombre, dni);
            lectores.Add(nuevo);
            return "Lector dado de alta.";
        }
        // Dar de baja lector
        public string bajaLector(string dni)
        {
            if (!validarDni(dni))
                return "DNI inválido. Debe contener exactamente 8 dígitos numéricos.";

            if (lectores == null || lectores.Count == 0)
                return "No hay lectores registrados.";
            for (int i = 0; i < lectores.Count; i++)
            {
                if (lectores[i].getDni().Trim().Equals(dni.Trim()))
                {
                    if (lectores[i].cantidadPrestamos() > 0)
                        return "No se puede dar de baja: el lector tiene prestamos pendientes.";
                    lectores.RemoveAt(i);
                    return "Lector dado de baja correctamente.";
                }
            }
            return "Lector no encontrado.";
        }
        // Presta un libro a un lector si cumple las condiciones
        public string prestarLibro(string titulo, string dni)
        {
            if (!validarDni(dni))
                return "DNI inválido. Debe contener exactamente 8 dígitos numéricos.";

            // Verificamos si existen lectores
            if (lectores == null || lectores.Count == 0)
                return "LECTOR INEXISTENTE";
            // Buscar lector para verificar que esta registrado
            Lector lectorEncontrado = null;
            foreach (Lector l in lectores)
            {
                if (l.getDni().Trim().Equals(dni.Trim()))
                {
                    lectorEncontrado = l;
                    break;
                }
            }
            if (lectorEncontrado == null)
                return "LECTOR INEXISTENTE";
            //Buscar libro para verificar que existe
            Libro libro = buscarLibro(titulo);
            if (libro == null)
                return "LIBRO INEXISTENTE";
            // Verificar tope de préstamo
            if (lectorEncontrado.cantidadPrestamos() >= 3)
                return "TOPE DE PRESTAMO ALCAZADO";
            // Prestar libro
            libros.Remove(libro); // Lo quitamos de la biblioteca
            lectorEncontrado.agregarPrestamo(libro); // Lo agregamos al lector
            return "PRESTAMO EXITOSO";
        }
        public void listarLectoresConPrestamos()
        {
            if (lectores == null || lectores.Count == 0)
            {
                Console.Write("No hay lectores registrados.");
                return;
            }
            foreach (Lector lector in lectores)
            {
                Console.WriteLine($"Lector: {lector.getNombre()} (DNI: {lector.getDni()})");
                List<Libro> prestamos = lector.getPrestamos();

                if (prestamos.Count == 0)
                {
                    Console.WriteLine(" - No tiene libros prestados.");
                }
                else
                {
                    Console.WriteLine(" Libros prestados:");
                    foreach (Libro libro in prestamos)
                    {
                        Console.WriteLine(" - " + libro.ToString());
                    }
                }
                Console.WriteLine(); // Linea en blanco para separar los lectores
            }
        }
    }
}