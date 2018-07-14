using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistrarLibrosBiblicos.Entidades
{
    public class LibrosBiblia
    {
        [Key]

        public int LibrosId { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public string Siglas { get; set; }

        public int Tipo { get; set; }


        public LibrosBiblia()
        {
            LibrosId = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
            Siglas = string.Empty;
            Tipo = 0;
        }
    }
}
