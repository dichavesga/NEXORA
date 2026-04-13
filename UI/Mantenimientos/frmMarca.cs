using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nexora.UI.Mantenimientos
{
    public partial class frmMarca : Form
    {
        public frmMarca()
        {
            InitializeComponent();
        }

        private void frmMarca_Load(object sender, EventArgs e)
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
    }
}
