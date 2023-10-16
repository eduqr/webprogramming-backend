using Microsoft.AspNetCore.Mvc;
using web_24BM.Models;
using web_24BM.Services;

namespace web_24BM.Controllers
{
    public class FormularioController : Controller
    {
        private readonly IEmailSenderService _emailSenderService;

        public FormularioController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        public IActionResult Index()
        {
            return View();  // Esta creo q no hizo falta crearla
        }

        public IActionResult FormularioCompleto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarFormulario(EmailViewModel userData)
        {
            TempData["EmailT"] = userData.Email;
            TempData["ComentarioT"] = userData.Mensaje;
            //EnviarEmailSmtp(model.Email); esto hace q se mande doble el mail

            var result = _emailSenderService.ProcesarSolicitud(userData);

            if (!result)
            {
                TempData["EmailT"] = null;
                TempData["EmailError"] = "Ocurrió un error";
            }
            return View("FormularioCompleto", userData);    // Ahí el nombre de la vista
        }

    }
}
