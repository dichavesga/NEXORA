using log4net;
using Nexora.Extensiones;
using Nexora.Properties;
using Nexora.UI.Mantenimientos;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nexora.UI
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }
        private static readonly ILog _myLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");


        private void frmInicio_Load(object sender, EventArgs e)
        {
            //VerificarConexion();
            try
            {
                //Utils.CultureInfo();
                this.Text = ConfigurationManager.AppSettings["NombreEmpresa"] + " " + Application.ProductName + " Versión:  " + Application.ProductVersion;
                toolStripStatusLabel1.Text = "Usuario Conectado: " + Settings.Default.Login + "/" + Settings.Default.Nombre;
                if (!Directory.Exists(@"C:\temp"))
                    Directory.CreateDirectory(@"C:\temp");
                _myLogControlEventos.InfoFormat("Conectado a Form Principal");
                // Activar Seguridad
                Seguridad();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void Seguridad()
        {
            List<string> menus = new List<string>();
            // Se deshabilita TODO primero
            foreach (ToolStripItem opcionMenu in this.mspMenuPrincipal.Items) //para cada opción de la barra de menú
            {
                // deshabita todos !
                ((ToolStripItem)(opcionMenu)).Enabled = false;
            }
            // Tabla Rol
            // IdRol DescripcionRol
            // 1   	Administrador
            // 2   	Vendedor
            // 3   	Reportes
            // Siempre permitir el MENU Acercade para todos los usuarios y salir si se requiere 
            menus.Add("toolStripMenuItemAcercaDe");
            //Recordemos que los datos están en el usuario o bien son modificados en el Settings para mejor acceso al sistema
            // Admin
            if (Settings.Default.RolId.Equals("1"))
            {
                menus.Add("toolStripMenuItemMantenimientos");
                menus.Add("toolStripMenuItemProcesos");
                menus.Add("reportesToolStripMenuItemReportes");
                menus.Add("administracionToolStripMenuItem");
            }

            // Vendedor
            if (Settings.Default.RolId.Equals("2"))
            {
                menus.Add("toolStripMenuItemMantenimientos");
                menus.Add("toolStripMenuItemProcesos");
            }

            // Reportes
            if (Settings.Default.RolId.Equals("3"))
            {
                menus.Add("reportesToolStripMenuItemReportes");
            }

            foreach (ToolStripItem opcionMenu in this.mspMenuPrincipal.Items) //para cada opción de la barra de menú
            {
                if (opcionMenu is ToolStripDropDownButton)
                {
                    foreach (ToolStripMenuItem oToolStripMenuItem in ((ToolStripDropDownButton)opcionMenu).DropDownItems)
                    {
                        oToolStripMenuItem.Enabled = menus.Exists(p => p.Equals(oToolStripMenuItem.Name, StringComparison.InvariantCultureIgnoreCase));
                    }
                }
                // Habilita solo las opciones que se encuentrna en la lista "menu"
                opcionMenu.Enabled = menus.Exists(p => p.Equals(opcionMenu.Name, StringComparison.InvariantCultureIgnoreCase));
            }
        }


        private void VerificarConexion()
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    toolStripStatusLabel1.Text = "🟢 Conectado";
                    toolStripStatusLabel1.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "🔴 Sin conexión";
                toolStripStatusLabel1.ForeColor = Color.Red;

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frmClientes;
            try
            {
                frmClientes = new frmCliente();
                frmClientes.Show();
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto frmProducto;
            try
            {
                frmProducto = new frmProducto();
                frmProducto.Show();
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarca frmMarcas;
            try
            {
                frmMarcas = new frmMarca();
                frmMarcas.Show();
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void tipoDispositivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoDispositivo frmTipoDispositivo;
            try
            {
                frmTipoDispositivo = new frmTipoDispositivo();
                frmTipoDispositivo.Show();
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
