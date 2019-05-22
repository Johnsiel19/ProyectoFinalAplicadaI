using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicadaI.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalAplicadaI.Entidades;

namespace ProyectoFinalAplicadaI.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = 0;
            usuario.Nombres = "John";
            usuario.Email = "Johnsie";
            usuario.NivelUsuario = "Joh";
            usuario.Usuario = "joh";
            usuario.Clave = "1223";
            usuario.FechaIngreso = DateTime.Now;
            paso = UsuariosBLL.Guardar(usuario);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUsuariosTest()
        {
            Assert.Fail();
        }
    }
}