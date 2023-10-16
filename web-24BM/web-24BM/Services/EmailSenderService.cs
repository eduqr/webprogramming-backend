using System.Net.Mail;
using System.Net;

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
    }
}
