using System.Web.Mvc;
using Sistema_de_Gestion.Models;
using Sistema_de_Gestion.Repositories;

namespace Sistema_de_Gestion.Controllers
{
    public class VehiculosController : Controller
    {
        private VehiculoRepositorio repositorio = new VehiculoRepositorio();

        // GET: Vehiculos
        public ActionResult Index()
        {
            var vehiculos = repositorio.ObtenerTodos();
            return View(vehiculos);
        }

        // GET: Vehiculos/Details/ABC123
        public ActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return HttpNotFound();

            var vehiculo = repositorio.ObtenerPorPlaca(id);

            if (vehiculo == null)
                return HttpNotFound();

            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            string tipo,
            string placa,
            string marca,
            string modelo,
            int anio,
            double kilometraje,
            double? capacidadCargaToneladas, 
            string tipoCombustible,
            int? cilindraje)                 
        {
            Vehiculo vehiculo;

            if (tipo == "Camion")
            {
                vehiculo = new Camion
                {
                    Placa = placa,
                    Marca = marca,
                    Modelo = modelo,
                    Anio = anio,
                    Kilometraje = kilometraje,
                    CapacidadCargaToneladas = capacidadCargaToneladas ?? 0 // Si viene vacío, guarda 0
                };
            }
            else if (tipo == "Automovil")
            {
                vehiculo = new Automovil
                {
                    Placa = placa,
                    Marca = marca,
                    Modelo = modelo,
                    Anio = anio,
                    Kilometraje = kilometraje,
                    TipoCombustible = tipoCombustible
                };
            }
            else if (tipo == "Motocicleta")
            {
                vehiculo = new Motocicleta
                {
                    Placa = placa,
                    Marca = marca,
                    Modelo = modelo,
                    Anio = anio,
                    Kilometraje = kilometraje,
                    Cilindraje = cilindraje ?? 0 // Si viene vacío, guarda 0
                };
            }
            else
            {
                ViewBag.Error = "Seleccione un tipo de vehículo.";
                return View();
            }

            if (repositorio.Agregar(vehiculo))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Ya existe un vehículo con esa placa.";
            return View();
        }

        // GET: Vehiculos/Edit/ABC123
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return HttpNotFound();

            var vehiculo = repositorio.ObtenerPorPlaca(id);

            if (vehiculo == null)
                return HttpNotFound();

            return View(vehiculo);
        }

        // POST: Vehiculos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            string placaOriginal,
            string tipo,
            string placa,
            string marca,
            string modelo,
            int anio,
            double kilometraje,
            double? capacidadCargaToneladas, 
            string tipoCombustible,
            int? cilindraje)                
        {
            Vehiculo vehiculo;

            if (tipo == "Camion")
            {
                vehiculo = new Camion
                {
                    Placa = placa,
                    Marca = marca,
                    Modelo = modelo,
                    Anio = anio,
                    Kilometraje = kilometraje,
                    CapacidadCargaToneladas = capacidadCargaToneladas ?? 0
                };
            }
            else if (tipo == "Automovil")
            {
                vehiculo = new Automovil
                {
                    Placa = placa,
                    Marca = marca,
                    Modelo = modelo,
                    Anio = anio,
                    Kilometraje = kilometraje,
                    TipoCombustible = tipoCombustible
                };
            }
            else
            {
                vehiculo = new Motocicleta
                {
                    Placa = placa,
                    Marca = marca,
                    Modelo = modelo,
                    Anio = anio,
                    Kilometraje = kilometraje,
                    Cilindraje = cilindraje ?? 0
                };
            }

            if (placaOriginal != placa)
            {
                if (repositorio.ObtenerPorPlaca(placa) != null)
                {
                    ViewBag.Error = "La nueva placa ya existe.";
                    return View(vehiculo);
                }

                repositorio.Eliminar(placaOriginal);
                repositorio.Agregar(vehiculo);
            }
            else
            {
                repositorio.Actualizar(placaOriginal, vehiculo);
            }

            return RedirectToAction("Index");
        }

        // GET: Vehiculos/Delete/ABC123
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return HttpNotFound();

            var vehiculo = repositorio.ObtenerPorPlaca(id);

            if (vehiculo == null)
                return HttpNotFound();

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string placa)
        {
            repositorio.Eliminar(placa);
            return RedirectToAction("Index");
        }
    }
}
