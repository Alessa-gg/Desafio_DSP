using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_Gestion.Models
{
    public class Camion : Vehiculo
    {
        public double CapacidadCargaToneladas { get; set; }

        public override string TipoVehiculo => "Camión";

        public override double CalcularCostoMantenimiento()
        {
            const double costoBase = 150.0;
            const double recargoPorTonelada = 25.0;
            return costoBase + (CapacidadCargaToneladas * recargoPorTonelada);
        }
    }
}
