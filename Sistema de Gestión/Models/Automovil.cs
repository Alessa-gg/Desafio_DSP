using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_Gestión.Models
{
    public class Automovil : Vehiculo
    {
        public string TipoCombustible { get; set; }

        public override string TipoVehiculo => "Automóvil";

        // Costo base + recargo si el combustible es Gasolina Premium
        public override double CalcularCostoMantenimiento()
        {
            const double costoBase = 80.0;
            const double recargoPremium = 30.0;

            if (TipoCombustible != null &&
                TipoCombustible.Equals("Gasolina Premium", System.StringComparison.OrdinalIgnoreCase))
            {
                return costoBase + recargoPremium;
            }

            return costoBase;
        }

        // Ejemplo de override que reutiliza el resumen de la clase base
        public override string ObtenerResumen()
        {
            return $"{base.ObtenerResumen()} - Combustible: {TipoCombustible}";
        }
    }
}