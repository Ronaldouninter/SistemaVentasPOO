using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentasPOO.Modelos
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public int IdCliente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Placas { get; set; }
        public string Color { get; set; }

        public Vehiculo()
        {
            Marca = "";
            Modelo = "";
            Placas = "";
            Color = "";
        }

        public string MostrarInformacion()
        {
            return Marca + " " + Modelo +
                   " - " + Placas;
        }
    }
}

