using System.Net.Mail;
using System.Net;
using web_24BM.Models;

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
                mail.Body = $"Se ha contactado la persona con el correo {data.Email} para solicitar información\n" +
                            "Sus datos:\n" +
                            $"Nombre: {data.Nombre}\n" +
                            $"Apellido: {data.Apellido}\n" +
                            $"Correo: {data.Email}\n" +
                            $"Fecha de nacimiento: {data.FechaNacimiento}\n" +
                            $"Hora de entrada: {data.HoraEntrada}\n" +
                            $"Turno: {data.Turno}\n" +
                            $"Mensaje: {data.Mensaje}";
                smtp.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
