using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinalAplicadaI.Entidades;
using ProyectoFinalAplicadaI.BLL;

namespace ProyectoFinalAplicadaI
{
    public partial class rUsuario : Form
    {
        public rUsuario()
        {
            InitializeComponent();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        private void Limpiar()
        {
            UsuarioIdnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            NivelUsuariocomboBox.Text = string.Empty;
            ClavetextBox.Text = string.Empty;
            UsuariotextBox.Text = string.Empty;
            ConfirmarClavetextBox.Text = string.Empty;
          

        }

        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Convert.ToInt32(UsuarioIdnumericUpDown.Value);
            usuario.Nombre = NombretextBox.Text;
            usuario.Email = EmailtextBox.Text;
            usuario.NivelUsuario = NivelUsuariocomboBox.Text;
            usuario.Clave = ClavetextBox.Text;
            usuario.Usuario = UsuariotextBox.Text;
            usuario.FechaIngreso = FechaIngresodateTimePicker.Value;
            return usuario;
            
        }

        private void LlenaCampo(Usuarios usuario)
        {
            UsuarioIdnumericUpDown.Value = usuario.UsuarioId;
            NombretextBox.Text = usuario.Nombre;
            EmailtextBox.Text = usuario.Email;
            NivelUsuariocomboBox.Text = usuario.NivelUsuario;
            ClavetextBox.Text = usuario.NivelUsuario;
            UsuariotextBox.Text = usuario.Usuario;
            FechaIngresodateTimePicker.Value = usuario.FechaIngreso;

        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Usuarios usuario = UsuariosBLL.Buscar((int)UsuarioIdnumericUpDown.Value);
            return (usuario != null);

        }

        private bool Validar()
        {

            bool paso = true;
            errorProvider1.Clear();

            if (NombretextBox.Text == string.Empty)
            {
                errorProvider1.SetError(NombretextBox, "El campo Nombre no puede estar vacio");
                NombretextBox.Focus();
                paso = false;

            }

            return paso;

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Usuarios persona;
            bool paso = false;

            if (!Validar())
                return;

            persona = LlenaClase();
            Limpiar();


            //Determinar si es guardar o modificar

            if (UsuarioIdnumericUpDown.Value == 0)

                paso = UsuariosBLL.Guardar(persona);

            else

            {

                if (!ExisteEnLaBaseDeDatos())

                {

                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }

                paso = UsuariosBLL.Modificar(persona);

            }



            //Informar el resultado

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



    }
}
