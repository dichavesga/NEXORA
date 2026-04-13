using Nexora.UI.Mantenimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void frmInicio_Load(object sender, EventArgs e)
        {
            VerificarConexion();
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
