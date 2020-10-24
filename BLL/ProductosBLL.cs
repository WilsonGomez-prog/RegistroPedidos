using Microsoft.EntityFrameworkCore;
using RegistroPedidos.DAL;
using RegistroPedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroPedidos.BLL
{
    public class ProductosBLL
    {
        /// <summary>
        /// Permite insertar o modificar una entidad(Productos) en la base de datos.
        /// </summary>
        /// <param name = "articulos"> Es la entidad(Productos) que se desea Guardar.</param>
        public static bool Guardar(Productos articulos)
        {
            if (!Existe(articulos.ProductoId))
            {
                return Insertar(articulos);
            }
            else
            {
                return Modificar(articulos);
            }
        }

        /// <summary>
        /// Permite buscar una entidad(Productos) en la base de datos.
        /// </summary>
        /// <param name = "productoId"> Es el ID de la entidad(Productos) que se desea encontrar.</param>
        public static Productos Buscar(int productoId)
        {
            Productos articulos;
            Contexto contexto = new Contexto();

            try
            {
                articulos = contexto.Productos.Find(productoId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return articulos;
        }

        /// <summary>
        /// Permite eliminar una entidad(Productos) en la base de datos.
        /// </summary>
        /// <param name = "productoId"> Es el ID de la entidad(Productos) que se desea eliminar de la base de datos.</param>
        public static bool Eliminar(int productoId)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var articulos = contexto.Productos.Find(productoId);

                if (articulos != null)
                {
                    contexto.Productos.Remove(articulos);
                    eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eliminado;
        }

        /// <summary>
        /// Permite insertar una entidad(Productos) en la base de datos.
        /// </summary>
        /// <param name = "articulos"> Es la entidad(Productos) que se desea insertar.</param>
        private static bool Insertar(Productos articulos)
        {
            bool insertado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Add(articulos);
                insertado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return insertado;
        }

        /// <summary>
        /// Permite modificar una entidad(Productos) en la base de datos.
        /// </summary>
        /// <param name = "articulos"> Es la entidad(Productos) que se desea modificar.</param>
        private static bool Modificar(Productos articulos)
        {
            bool modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(articulos).State = EntityState.Modified;
                modificado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return modificado;
        }

        /// <summary>
        /// Permite verificar la existencia de una entidad(Productos) en la base de datos.
        /// </summary>
        /// <param name = "productoId"> Es el ID de la entidad(Productos) de la cual se desea verificar la existencia.</param>
        public static bool Existe(int productoId)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Productos.Any(e => e.ProductoId == productoId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Existe(string Descripcion)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Productos.Any(e => e.Descripcion == Descripcion);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        /// <summary>
        /// Permite extraer una lista con las entidades(Productos) que posee la base de datos basada en un parametro para filtrarle(criterio).
        /// </summary>
        /// <param name = "criterio"> Es el criterio por el cual va a ser ordenada o extraida la lista.</param>
        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Productos.Where(criterio).AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        /// <summary>
        /// Permite extraer una lista con las entidades(Productos) que posee la base de datos.
        /// </summary>
        public static List<Productos> GetProductos()
        {
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Productos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}