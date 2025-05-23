﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DSOO_Grupo14_TP1
{
    internal class Libro
    {
        private string titulo;
        private string autor;
        private string editorial;

        public Libro(string titulo, string autor, string editorial)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
        }
        public string getAutor()
        {
            return autor;
        }
        public void setAutor(string autor)
        {
            this.autor = autor;
        }
        public string getTitulo()
        {
            return titulo;
        }
        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }
         public string getEditorial()
        {
            return editorial;
        }
        public void setEditorial(string editorial)
        {
            this.editorial = editorial;
        }
        public override string ToString()
        {
            return "Titulo: " + titulo + " Autor: " + autor + " Editorial: " + editorial;
        }
    }
}