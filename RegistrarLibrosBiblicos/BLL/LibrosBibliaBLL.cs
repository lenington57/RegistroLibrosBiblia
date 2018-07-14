using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using RegistrarLibrosBiblicos.DAL;
using RegistrarLibrosBiblicos.Entidades;

namespace RegistrarLibrosBiblicos.BLL
{
    public class LibrosBibliaBLL
    {
        public static bool Guardar(LibrosBiblia librosBiblia)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.LibrosBiblia.Add(librosBiblia) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(LibrosBiblia librosBiblia)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(librosBiblia).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                LibrosBiblia librosBiblia = contexto.LibrosBiblia.Find(id);

                contexto.LibrosBiblia.Remove(librosBiblia);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static LibrosBiblia Buscar(int id)
        {
            Contexto contexto = new Contexto();
            LibrosBiblia librosBiblia = new LibrosBiblia();
            try
            {
                librosBiblia = contexto.LibrosBiblia.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return librosBiblia;
        }


        public static List<LibrosBiblia> GetList(Expression<Func<LibrosBiblia, bool>> expression)
        {
            List<LibrosBiblia> ListaLibrosBiblias = new List<LibrosBiblia>();
            Contexto contexto = new Contexto();

            try
            {
                ListaLibrosBiblias = contexto.LibrosBiblia.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return ListaLibrosBiblias;
        }

    }
}
