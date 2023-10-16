using Microsoft.AspNetCore.Mvc;
using web_24BM.Models;

namespace web_24BM.Controllers
{
    public class ValidacionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnviarFormulario(Curriculum model)
        {
            string mensaje = "";
            if (ModelState.IsValid)
            {
                mensaje = "Datos Válidos";
                TempData["msj"] = mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                mensaje = "Datos no válidos";
                TempData["msj"] = mensaje;
                return View("Index");
            }
            
        }
    }
}
