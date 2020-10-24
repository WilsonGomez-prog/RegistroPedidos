using Microsoft.EntityFrameworkCore;
using RegistroPedidos.DAL;
using RegistroPedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroPedidos.BLL
{
    public class SuplidoresBLL
    {
        /// <summary>
        /// Permite insertar o modificar una entidad(Suplidores) en la base de datos.
        /// </summary>
        /// <param name = "suplidor"> Es la entidad(Suplidores) que se desea Guardar.</param>
        public static bool Guardar(Suplidores suplidor)
        {
            if (!Existe(suplidor.SuplidorId))
            {
                return Insertar(suplidor);
            }
            else
            {
                return Modificar(suplidor);
            }
        }

        /// <summary>
        /// Permite buscar una entidad(Suplidores) en la base de datos.
        /// </summary>
        /// <param name = "suplidorId"> Es el ID de la entidad(Suplidores) que se desea encontrar.</param>
        public static Suplidores Buscar(int suplidorId)
        {
            Suplidores suplidor;
            Contexto contexto = new Contexto();

            try
            {
                suplidor = contexto.Suplidores.Find(suplidorId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return suplidor;
        }

        /// <summary>
        /// Permite eliminar una entidad(Suplidores) en la base de datos.
        /// </summary>
        /// <param name = "suplidorId"> Es el ID de la entidad(Suplidores) que se desea eliminar de la base de datos.</param>
        public static bool Eliminar(int suplidorId)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var suplidor = contexto.Suplidores.Find(suplidorId);

                if (suplidor != null)
                {
                    contexto.Suplidores.Remove(suplidor);
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
        /// Permite insertar una entidad(Suplidores) en la base de datos.
        /// </summary>
        /// <param name = "suplidor"> Es la entidad(Suplidores) que se desea insertar.</param>
        private static bool Insertar(Suplidores suplidor)
        {
            bool insertado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Add(suplidor);
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
        /// Permite modificar una entidad(Suplidores) en la base de datos.
        /// </summary>
        /// <param name = "suplidor"> Es la entidad(Suplidores) que se desea modificar.</param>
        private static bool Modificar(Suplidores suplidor)
        {
            bool modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
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
        /// Permite verificar la existencia de una entidad(Suplidores) en la base de datos.
        /// </summary>
        /// <param name = "suplidorId"> Es el ID de la entidad(Suplidores) de la cual se desea verificar la existencia.</param>
        public static bool Existe(int suplidorId)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Suplidores.Any(e => e.SuplidorId == suplidorId);
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

        public static bool Existe(string Nombre)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Suplidores.Any(e => e.Nombre == Nombre);
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
        /// Permite extraer una lista con las entidades(Suplidores) que posee la base de datos basada en un parametro para filtrarle(criterio).
        /// </summary>
        /// <param name = "criterio"> Es el criterio por el cual va a ser ordenada o extraida la lista.</param>
        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> criterio)
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Suplidores.Where(criterio).AsNoTracking().ToList();
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
        /// Permite extraer una lista con las entidades(Suplidores) que posee la base de datos.
        /// </summary>
        public static List<Suplidores> GetSuplidores()
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Suplidores.ToList();
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