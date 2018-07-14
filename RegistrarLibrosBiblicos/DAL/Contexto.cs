using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RegistrarLibrosBiblicos.Entidades;

namespace RegistrarLibrosBiblicos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<LibrosBiblia> LibrosBiblia { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
