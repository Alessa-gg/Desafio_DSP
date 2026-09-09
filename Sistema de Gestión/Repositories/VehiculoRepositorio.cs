using System.Collections.Generic;
using Sistema_de_Gestion.Models;
namespace Sistema_de_Gestion.Repositories

{
    public class VehiculoRepositorio
    {
        private static Dictionary<string, Vehiculo> _vehiculos =
            new Dictionary<string, Vehiculo>();

        // Agregar un vehículo
        public bool Agregar(Vehiculo v)
        {
            if (v == null || string.IsNullOrWhiteSpace(v.Placa))
                return false;

            if (_vehiculos.ContainsKey(v.Placa))
                return false;

            _vehiculos.Add(v.Placa, v);
            return true;
        }

        // Obtener todos los vehículos
        public List<Vehiculo> ObtenerTodos()
        {
            return new List<Vehiculo>(_vehiculos.Values);
        }

        // Buscar un vehículo por placa
        public Vehiculo ObtenerPorPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return null;

            Vehiculo vehiculo;

            if (_vehiculos.TryGetValue(placa, out vehiculo))
                return vehiculo;

            return null;
        }

        // Actualizar un vehículo
        public bool Actualizar(string placa, Vehiculo v)
        {
            if (string.IsNullOrWhiteSpace(placa) || v == null)
                return false;

            if (!_vehiculos.ContainsKey(placa))
                return false;

            _vehiculos[placa] = v;
            return true;
        }

        // Eliminar un vehículo
        public bool Eliminar(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            return _vehiculos.Remove(placa);
        }
    }
}