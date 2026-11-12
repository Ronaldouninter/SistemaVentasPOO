
using System;
using System.Windows.Forms;
using SistemaVentasPOO.Modelos;
using SistemaVentasPOO.Repositorios;
using SistemaVentasPOO.Datos;

namespace SistemaVentasPOO.Formularios
{
    public partial class FrmClientes : Form
    {
        private ClienteRepositorio repositorio =
            new ClienteRepositorio();

        private Cliente clienteSeleccionado = null;

        public FrmClientes()
        {
            InitializeComponent();

            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            CargarClientes();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Debes escribir el nombre del cliente.");
                txtNombre.Focus();
                return;
            }

            try
            {
                Cliente nuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                };

                repositorio.Guardar(nuevoCliente);

                MessageBox.Show(
                    "Cliente guardado correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarClientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show(
                    "Selecciona un cliente para modificar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "El nombre no puede estar vacío.");
                return;
            }

            try
            {
                Cliente clienteActualizado = new Cliente
                {
                    IdCliente = clienteSeleccionado.IdCliente,
                    Nombre = txtNombre.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                };

                repositorio.Modificar(clienteActualizado);

                MessageBox.Show(
                    "Cliente modificado correctamente.");

                CargarClientes();
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
            if (clienteSeleccionado == null)
            {
                MessageBox.Show(
                    "Selecciona un cliente para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que deseas eliminar este cliente?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                repositorio.Eliminar(
                    clienteSeleccionado.IdCliente);

                MessageBox.Show(
                    "Cliente eliminado correctamente.");

                CargarClientes();
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
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();

            clienteSeleccionado = null;
            dgvClientes.ClearSelection();
            txtNombre.Focus();
        }

        private void CargarClientes()
        {
            try
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource =
                    repositorio.ObtenerTodos();

                dgvClientes.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvClientes.ClearSelection();
                clienteSeleccionado = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar clientes: " + ex.Message);
            }
        }

        private void dgvClientes_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            clienteSeleccionado =
                dgvClientes.Rows[e.RowIndex].DataBoundItem
                as Cliente;

            if (clienteSeleccionado == null)
                return;

            txtNombre.Text = clienteSeleccionado.Nombre;
            txtTelefono.Text = clienteSeleccionado.Telefono;
            txtCorreo.Text = clienteSeleccionado.Correo;
            txtDireccion.Text = clienteSeleccionado.Direccion;
        }

        private void dgvClientes_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
            dgvClientes_CellClick(sender, e);
        }

        private void btnProbarConexion_Click(
            object sender, EventArgs e)
        {
            try
            {
                using (var conexion =
                    ConexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    MessageBox.Show(
                        "Conexión exitosa con SQL Server.",
                        "Conexión correcta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error de conexión: " + ex.Message);
            }
        }
    }
}
