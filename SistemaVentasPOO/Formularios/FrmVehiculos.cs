using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaVentasPOO.Modelos;
using SistemaVentasPOO.Repositorios;

namespace SistemaVentasPOO.Formularios
{
    public partial class FrmVehiculos : Form
    {
        private VehiculoRepositorio repositorio =
           new VehiculoRepositorio();

        private ClienteRepositorio clienteRepositorio =
            new ClienteRepositorio();

        private Vehiculo vehiculoSeleccionado = null;
        public FrmVehiculos()
        {
            InitializeComponent();
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.MultiSelect = false;
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            nudAnio.Minimum = 1900;
            nudAnio.Maximum = 2100;
            nudAnio.Value = DateTime.Now.Year;

            CargarClientes();
            CargarVehiculos();
        }

        private void CargarClientes()
        {
            try
            {
                var clientes = clienteRepositorio.ObtenerTodos();

                cmbClientes.DataSource = null;
                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "Nombre";
                cmbClientes.ValueMember = "IdCliente";
                cmbClientes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar clientes: " + ex.Message);
            }
        }

        private void CargarVehiculos()
        {
            try
            {
                dgvVehiculos.DataSource = null;
                dgvVehiculos.DataSource =
                    repositorio.ObtenerTodos();

                dgvVehiculos.ClearSelection();
                vehiculoSeleccionado = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar vehículos: " + ex.Message);
            }
        }

        private Vehiculo ObtenerDatos()
        {
            if (cmbClientes.SelectedValue == null)
                throw new Exception(
                    "Selecciona un cliente.");

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
                throw new Exception(
                    "Escribe la marca.");

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
                throw new Exception(
                    "Escribe el modelo.");

            if (string.IsNullOrWhiteSpace(txtPlacas.Text))
                throw new Exception(
                    "Escribe las placas.");

            return new Vehiculo
            {
                IdCliente =
                    Convert.ToInt32(cmbClientes.SelectedValue),
                Marca = txtMarca.Text.Trim(),
                Modelo = txtModelo.Text.Trim(),
                Anio = Convert.ToInt32(nudAnio.Value),
                Placas = txtPlacas.Text.Trim(),
                Color = txtColor.Text.Trim()
            };  
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Vehiculo vehiculo = ObtenerDatos();

                repositorio.Guardar(vehiculo);

                MessageBox.Show(
                    "Vehículo guardado correctamente.");

                CargarVehiculos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar: " + ex.Message);
            }
        }

        private void btnModificar_Click(
            object sender, EventArgs e)
        {
            if (vehiculoSeleccionado == null)
            {
                MessageBox.Show(
                    "Selecciona un vehículo.");
                return;
            }

            try
            {
                Vehiculo vehiculo = ObtenerDatos();
                vehiculo.IdVehiculo =
                    vehiculoSeleccionado.IdVehiculo;

                repositorio.Modificar(vehiculo);

                MessageBox.Show(
                    "Vehículo modificado correctamente.");

                CargarVehiculos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al modificar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (vehiculoSeleccionado == null)
            {
                MessageBox.Show(
                    "Selecciona un vehículo.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Deseas eliminar este vehículo?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                repositorio.Eliminar(
                    vehiculoSeleccionado.IdVehiculo);

                MessageBox.Show(
                    "Vehículo eliminado correctamente.");

                CargarVehiculos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        private void LimpiarCampos()
        {
            cmbClientes.SelectedIndex = -1;
            txtMarca.Clear();
            txtModelo.Clear();
            txtPlacas.Clear();
            txtColor.Clear();

            nudAnio.Value = DateTime.Now.Year;

            vehiculoSeleccionado = null;
            dgvVehiculos.ClearSelection();
        }

        private void dgvVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            vehiculoSeleccionado =
                dgvVehiculos.Rows[e.RowIndex].DataBoundItem
                as Vehiculo;

            if (vehiculoSeleccionado == null)
                return;

            cmbClientes.SelectedValue =
                vehiculoSeleccionado.IdCliente;

            txtMarca.Text =
                vehiculoSeleccionado.Marca;

            txtModelo.Text =
                vehiculoSeleccionado.Modelo;

            nudAnio.Value =
                vehiculoSeleccionado.Anio;

            txtPlacas.Text =
                vehiculoSeleccionado.Placas;

            txtColor.Text =
                vehiculoSeleccionado.Color;
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
    

