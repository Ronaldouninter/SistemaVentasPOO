using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaVentasPOO.Formularios;

namespace SistemaVentasPOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes ventana = new FrmClientes();
            ventana.ShowDialog();
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            FrmVehiculos ventana = new FrmVehiculos();
            ventana.ShowDialog();
        }
    }
}
