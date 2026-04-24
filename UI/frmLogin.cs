using iTextSharp.xmp;
using log4net;
using Nexora.Capas.BLL;
using Nexora.Capas.Entities;
using Nexora.Extensiones;
using Nexora.Interfaces;
using Nexora.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitarios;

namespace Nexora.UI
{
    public partial class frmLogin : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private int contador = 0;

        public frmLogin()
        {
            //Cambio del profe
            InitializeComponent();
            string pass = Cryptography.EncrypthAES("vend123");
            Clipboard.SetText(pass);

            MessageBox.Show("Contraseña copiada al portapapeles");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            // Debe validar los datos requeridos
            IBLLUsuario bllUsuario = new BLLUsuario();
            epError.Clear();
            Usuario oUsuario = null;
            try
            {
                //Realiza las validaciones para poder realizar la consulta a la base de datos
                if (string.IsNullOrEmpty(this.txtLogin.Text))
                {
                    epError.SetError(txtLogin, "Usuario requerido");
                    this.txtLogin.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    epError.SetError(txtPassword, "Contrasena requerida");
                    this.txtPassword.Focus();
                    return;
                }

                //Crea la Instancia con los datos de usuario y contraseña
                //Guarda todos los datos del usuario tales como usuario, rol, contraseña, nombre y estado
                oUsuario = bllUsuario.Login(this.txtLogin.Text.Trim(),
                                           this.txtPassword.Text.Trim());
                if (oUsuario == null)
                {
                    ++contador;
                    MessageBox.Show("Error en el acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Si el contador es 3 cierre la aplicación
                    if (contador == 3)
                    {
                        // se devuelve Cancel
                        MessageBox.Show("Se equivocó en 3 ocasiones, el Sistema se Cerrará por seguridad", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _myLogControlEventos.WarnFormat("Se equivocó + de 3 ocasiones Login: {0}", this.txtLogin.Text);
                        this.DialogResult = DialogResult.Cancel;
                        Application.Exit();
                    }
                }
                else
                {
                    //Valida configuración por Default en AppConfig
                    Settings.Default.Login = this.txtLogin.Text.Trim();
                    Settings.Default.Nombre = oUsuario.Nombre;
                    Settings.Default.RolId = oUsuario.IdPerfil.ToString();
                    Settings.Default.Save();
                    //EfectoConexionNoAsync();

                    // Log de errores
                    _myLogControlEventos.InfoFormat("Accedió a la aplicación :{0}", Settings.Default.Nombre);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

   
}

}
