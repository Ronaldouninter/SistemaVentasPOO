
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SistemaVentasPOO.Datos;
using SistemaVentasPOO.Modelos;

namespace SistemaVentasPOO.Repositorios
{
    public class VehiculoRepositorio
    {
        public void Guardar(Vehiculo vehiculo)
        {
            using (SqlConnection conexion =
                ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql =
                    @"INSERT INTO Vehiculos
                    (IdCliente, Marca, Modelo, Anio, Placas, Color)
                    VALUES
                    (@IdCliente, @Marca, @Modelo, @Anio, @Placas, @Color)";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, vehiculo);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Vehiculo> ObtenerTodos()
        {
            List<Vehiculo> vehiculos =
                new List<Vehiculo>();

            using (SqlConnection conexion =
                ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = "SELECT * FROM Vehiculos";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                using (SqlDataReader lector =
                    comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Vehiculo vehiculo = new Vehiculo
                        {
                            IdVehiculo =
                                Convert.ToInt32(lector["IdVehiculo"]),
                            IdCliente =
                                Convert.ToInt32(lector["IdCliente"]),
                            Marca = lector["Marca"].ToString(),
                            Modelo = lector["Modelo"].ToString(),
                            Anio = Convert.ToInt32(lector["Anio"]),
                            Placas = lector["Placas"].ToString(),
                            Color = lector["Color"].ToString()
                        };

                        vehiculos.Add(vehiculo);
                    }
                }
            }

            return vehiculos;
        }

        public void Modificar(Vehiculo vehiculo)
        {
            using (SqlConnection conexion =
                ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql =
                    @"UPDATE Vehiculos SET
                    IdCliente = @IdCliente,
                    Marca = @Marca,
                    Modelo = @Modelo,
                    Anio = @Anio,
                    Placas = @Placas,
                    Color = @Color
                    WHERE IdVehiculo = @IdVehiculo";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                {
                    AgregarParametros(comando, vehiculo);
                    comando.Parameters.AddWithValue(
                        "@IdVehiculo", vehiculo.IdVehiculo);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int idVehiculo)
        {
            using (SqlConnection conexion =
                ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql =
                    "DELETE FROM Vehiculos WHERE IdVehiculo = @IdVehiculo";

                using (SqlCommand comando =
                    new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdVehiculo", idVehiculo);

                    comando.ExecuteNonQuery();
                }
            }
        }

        private void AgregarParametros(
            SqlCommand comando, Vehiculo vehiculo)
        {
            comando.Parameters.AddWithValue(
                "@IdCliente", vehiculo.IdCliente);
            comando.Parameters.AddWithValue(
                "@Marca", vehiculo.Marca);
            comando.Parameters.AddWithValue(
                "@Modelo", vehiculo.Modelo);
            comando.Parameters.AddWithValue(
                "@Anio", vehiculo.Anio);
            comando.Parameters.AddWithValue(
                "@Placas", vehiculo.Placas);
            comando.Parameters.AddWithValue(
                "@Color", vehiculo.Color);
        }
    }
}
