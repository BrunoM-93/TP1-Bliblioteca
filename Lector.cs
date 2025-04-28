using System;
using System.Collections.Generic;
using System.Text;

namespace DSOO_Grupo14_TP1
{
    internal class Lector
    {
        private string nombre;
        private string dni;
        private List<Libro> prestamosVigentes;

        public Lector(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.prestamosVigentes = new List<Libro>();
        }
        public string getNombre()
        {
            return nombre;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string getDni()
        {
            return dni;
        }

        public int cantidadPrestamos()
        {
            return prestamosVigentes.Count;
        }

        public void agregarPrestamo(Libro libro)
        {
            prestamosVigentes.Add(libro);
        }
    }
}
