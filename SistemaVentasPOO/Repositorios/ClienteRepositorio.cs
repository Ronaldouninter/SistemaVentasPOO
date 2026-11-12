
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using SistemaVentasPOO.Datos;
using SistemaVentasPOO.Modelos;

namespace SistemaVentasPOO.Repositorios
{
    public class ClienteRepositorio
    {
  
        public void Guardar(Cliente cliente)
        {
            using (SqlConnection conexion =
                ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta =
                    @"INSERT INTO Clientes
                    (Nombre, Telefono, Correo, Direccion)
                    VALUES
                    (@Nombre, @Telefono, @Correo, @Direccion)";

                using (SqlCommand comando =
                    new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Nombre", cliente.Nombre);

                    comando.Parameters.AddWithValue(
                        "@Telefono", cliente.Telefono);

                    comando.Parameters.AddWithValue(
                        "@Correo", cliente.Correo);

                    comando.Parameters.AddWithValue(
                        "@Direccion", cliente.Direccion);

                    comando.ExecuteNonQuery();
                }
            }
        }


        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> clientes =
                new List<Cliente>();

            using (SqlConnection conexion =
                ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta =
                    @"SELECT IdCliente, Nombre,
                    Telefono, Correo, Direccion
                    FROM Clientes
                    ORDER BY IdCliente";

                using (SqlCommand comando =
                    new SqlCommand(consulta, conexion))
                using (SqlDataReader lector =
                    comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            IdCliente =
                                Convert.ToInt32(
                                    lector["IdCliente"]),

                            Nombre =
                                lector["Nombre"].ToString(),

                            Telefono =
                                lector["Telefono"].ToString(),

                            Correo =
                                lector["Correo"].ToString(),

                            Direccion =
                                lector["Direccion"].ToString()
                        };

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

   
        public void Modificar(Cliente cliente)
        {
            using (SqlConnection conexion =
                ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta =
                    @"UPDATE Clientes SET
                    Nombre = @Nombre,
                    Telefono = @Telefono,
                    Correo = @Correo,
                    Direccion = @Direccion
                    WHERE IdCliente = @IdCliente";

                using (SqlCommand comando =
                    new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdCliente", cliente.IdCliente);

                    comando.Parameters.AddWithValue(
                        "@Nombre", cliente.Nombre);

                    comando.Parameters.AddWithValue(
                        "@Telefono", cliente.Telefono);

                    comando.Parameters.AddWithValue(
                        "@Correo", cliente.Correo);

                    comando.Parameters.AddWithValue(
                        "@Direccion", cliente.Direccion);

                    comando.ExecuteNonQuery();
                }
            }
        }


        public void Eliminar(int idCliente)
        {
            using (SqlConnection conexion =
                ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta =
                    @"DELETE FROM Clientes
                    WHERE IdCliente = @IdCliente";

                using (SqlCommand comando =
                    new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdCliente", idCliente);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
