using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProyectoFinalAplicadaI.DAL;
using ProyectoFinalAplicadaI.Entidades;

namespace ProyectoFinalAplicadaI.BLL
{
    public class UsuariosBLL
    {


        public static bool Guardar(Usuarios Usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Usuario.Add(Usuario) != null)
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
    }
}