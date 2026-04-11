using Nexora.Capas.BLL;
using Nexora.Capas.Entities.Catalogos;
using Nexora.Interfaces;
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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            //IBLLCliente bllCliente = new BLLCliente();
            IBLLProvincia bllProvincia = new BLLProvincia();
            List<Provincia> lista = null;

            this.cmbProvincia.Items.Clear();
            lista = bllProvincia.GetProvinciaFromInternet();

            this.cmbProvincia.DataSource = lista;
            cmbProvincia.DisplayMember = "Descripcion";
            this.cmbProvincia.SelectedIndex = 0;
        }

        
    }
}
