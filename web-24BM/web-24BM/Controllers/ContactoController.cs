using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using web_24BM.Models;
using web_24BM.Services;

namespace web_24BM.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IEmailSenderService _emailSenderService;

        public ContactoController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Formulario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarEmail(string email, string comentario)
        {
            TempData["EmailT"] = email;
            TempData["ComentarioT"] = comentario;
            EnviarEmailSmtp(email);
            return View("Index", "Contacto");
        }

        [HttpPost]
        public IActionResult EnviarFormulario(EmailViewModel model)
        {
            TempData["EmailT"] = model.Email;
            TempData["ComentarioT"] = model.Mensaje;
            //EnviarEmailSmtp(model.Email);

            var result = _emailSenderService.SendEmail(model.Email);

            if (!result)
            {
                TempData["EmailT"] = null;
                TempData["EmailError"] = "Ocurrió un error";
            }
            return View("Formulario", model);
        }

        public bool EnviarEmailSmtp(string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("mail.shapp.mx", 587);

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");
            mail.From = new MailAddress("moises.puc@shapp.mx", "Administrador");
            mail.To.Add(email);
            mail.Subject = "Aviso de contacto";
            mail.IsBodyHtml = true;
            mail.Body = $"Se ha contactado la persona con el correo {email} para solicitar informacion";
            smtp.Send(mail);
            return true;
        }
    }
}
