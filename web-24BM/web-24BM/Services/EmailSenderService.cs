using System.Net.Mail;
using System.Net;
using web_24BM.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace web_24BM.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public bool SendEmail(string email)
        {
            bool result = false;
            try
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
                result = true;
            }
            catch(Exception ex)
            {

            }
            return result;
        }

        public bool ProcesarSolicitud(EmailViewModel data)
        {
            bool result = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("mail.shapp.mx", 587);

                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");
                mail.From = new MailAddress("moises.puc@shapp.mx", "Administrador");
                mail.To.Add(data.Email);
                mail.Subject = "Notificación de contacto";
                mail.IsBodyHtml = true;
                mail.Body = $"Se ha contactado la persona con el correo {data.Email} para solicitar información<br><br>" +
                            "Sus datos:<br>" +
                            $"Nombre: {data.Nombre}<br>" +
                            $"Apellido: {data.Apellido}<br>" +
                            $"Correo: {data.Email}<br>" +
                            $"Fecha de nacimiento: {data.FechaNacimiento}<br>" +
                            $"Hora de entrada: {data.HoraEntrada}<br>" +
                            $"Turno: {data.Turno}<br>" +
                            $"Mensaje: {data.Mensaje}";
                smtp.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool SendEmailWithData(MensajeViewModel model)
        {
            bool result = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("mail.shapp.mx", 587);

                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");
                mail.From = new MailAddress("moises.puc@shapp.mx", "Administrador");
                mail.To.Add(model.Email);
                mail.Subject = model.Subject;
                mail.IsBodyHtml = true;
                mail.Body = model.Content;
                result = true;
                smtp.Send(mail);
            }
            catch (Exception e)
            {

            }
            return result;
        }
    }
}
