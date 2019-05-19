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
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Usuario.Add(usuario) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
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
            Usuarios usuarios = new Usuarios();
            Contexto contexto = new Contexto();
            
            
            try
            {
                usuarios = contexto.Usuario.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;

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