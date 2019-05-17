using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAplicadaI.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set;}
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string NuvelUsuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public Usuarios()
        {
             UsuarioId = 0;
             Nombre = String.Empty;
             Email = String.Empty;
             NuvelUsuario = String.Empty;
             Usuario = String.Empty;
             Clave = String.Empty;
         
        }
    }
}
