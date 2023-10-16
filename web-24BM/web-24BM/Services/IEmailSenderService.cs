using web_24BM.Models;

namespace web_24BM.Services
{
    public interface IEmailSenderService
    {
        bool SendEmail(string email);
        bool ProcesarSolicitud(EmailViewModel data);
        bool SendEmailWithData(MensajeViewModel model);
    }
}
