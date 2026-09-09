using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_Gestión.Models
{
    public abstract class Vehiculo
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public double Kilometraje { get; set; }

        public abstract string TipoVehiculo { get; }

        public abstract double CalcularCostoMantenimiento();

        public virtual string ObtenerResumen()
        {
            return $"{Marca} {Modelo} ({Anio}) - Placa: {Placa}";
        }
    }
}