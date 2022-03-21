using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EmailBot.Common.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using EmailBot.Common.Models;
using System.Collections.Generic;

namespace EmailBot.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmailPromptController : ControllerBase
    {
        protected readonly IEmailPromptHelper promptHelper;
        public EmailPromptController(IEmailPromptHelper notificationHelper)
        {
            this.promptHelper = notificationHelper;
        }

        [HttpPost("sendPrompt")]
        public async Task SendPrompt()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userEmail = promptHelper.JwtHandler(token);
            await promptHelper.SendPrompt(userEmail);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("registerEmail")]
        public void Register([FromQuery] string department, [FromQuery] string email)
        {
            UserEntity user = promptHelper.GetUserEntity(email, department);
            promptHelper.RegisterEmail(email, user.Name, department);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("allEmails")]
        public async Task<IList<UserEntity>> GetAllUsers()
        {
            return promptHelper.GetAllUsers();
        }
    }
}
