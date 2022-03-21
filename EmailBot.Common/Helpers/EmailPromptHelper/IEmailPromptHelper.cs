using EmailBot.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmailBot.Common.Helpers
{
    public interface IEmailPromptHelper
    {
        public Task SendPrompt(string aadObjectId);
        public List<UserEntity> GetAllUsers();
        public string JwtHandler(string token);
        public Task RegisterEmail(dynamic email, dynamic name, dynamic department);
        public UserEntity GetUserEntity(string email, string department);
    }
}
