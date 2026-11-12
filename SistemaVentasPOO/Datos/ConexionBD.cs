
using Microsoft.Data.SqlClient;

namespace SistemaVentasPOO.Datos
{
    public static class ConexionBD
    {
        private static readonly string cadenaConexion =
            @"Server=(localdb)\MSSQLLocalDB;
              Database=TallerMecanicoDB;
              Integrated Security=True;
              TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }X|
}
