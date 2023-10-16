using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_24BM.Models;
using web_24BM.Services;

namespace web_24BM.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailSenderService _emailSenderService;
        public SendEmailController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        [HttpPost]
        [Route("SendData")]
        public IActionResult Send([FromBody] MensajeViewModel model)
        {
            var result = _emailSenderService.SendEmailWithData(model);

            if (result)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest(model);
            }
        }
    }
}
