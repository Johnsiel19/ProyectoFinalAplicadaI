using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProyectoFinalAplicadaI.DAL;
using ProyectoFinalAplicadaI.Entidades;
using System.Linq.Expressions;

namespace ProyectoFinalAplicadaI.BLL
{
    public class UsuariosBLL
    {
        public static List<Usuarios> Usuarios { get; private set; }

        public static bool Guardar(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Usuario.Add(usuario) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                if(contexto.SaveChanges() > 0)
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
                Usuarios usuario = contexto.Usuario.Find(id);

                contexto.Usuario.Remove(usuario);

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

        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            _ = new Usuarios();
            Usuarios usuario;
            try
            {
                usuario = contexto.Usuario.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;

        }

        public static List<Usuarios> GetUsuarios(Expression<Func<Usuarios, bool >> expression)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            Contexto contexto = new Contexto();

            try
            {
                Usuarios = contexto.Usuario.Where(expression).ToList();
                contexto.Dispose();

            }
            catch
            {
                throw;
            }
            return Usuarios;

        }


    }
}