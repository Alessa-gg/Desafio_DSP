using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_Gestión.Models
{
    public class Motocicleta : Vehiculo
    {
        public int Cilindraje { get; set; }

        public override string TipoVehiculo => "Motocicleta";

        // Costo base reducido, con recargo si el cilindraje supera 500cc
        public override double CalcularCostoMantenimiento()
        {
            const double costoBase = 40.0;
            const double recargoAltoCilindraje = 20.0;

            if (Cilindraje > 500)
            {
                return costoBase + recargoAltoCilindraje;
            }

            return costoBase;
        }
    }
}