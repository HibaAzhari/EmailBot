using AdaptiveCards;
using EmailBot.Common.Context;
using EmailBot.Common.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmailBot.Common.Helpers
{
    public class EmailPromptHelper : IEmailPromptHelper
    {
        protected readonly BotDbContext context;
        private readonly IBotFrameworkHttpAdapter _adapter;
        private readonly IConfiguration _configuration;

        private string _activityId;

        public EmailPromptHelper(BotDbContext context, IBotFrameworkHttpAdapter adapter, IConfiguration _configuration)
        {
            this.context = context;
            this._adapter = adapter;
            this._configuration = _configuration;
        }

        public string JwtHandler(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            string userEmail = jwtToken.Claims.First(claim => claim.Type == "preferred_username").Value;
            return userEmail;
        }

        public async Task SendPrompt(string userEmail)
        {
            var conRef = context.ConversationReferenceEntities.Where(r => r.RowKey == userEmail).FirstOrDefault();

            string botId = _configuration["MicrosoftAppId"];

            if (conRef != null)
            {
                ConversationReference reference = new ConversationReference()
                {
                    Conversation = new ConversationAccount()
                    {
                        Id = conRef.ConversationId
                    },
                    ServiceUrl = conRef.ServiceUrl,
                };

                await ((BotAdapter)_adapter).ContinueConversationAsync(
                       botId,
                       reference,
                       async (context, token) =>
                       {
                           IMessageActivity messageActivity = MessageFactory.Attachment(GetPrompt(conRef.Name));
                           await BotCallback(messageActivity, context, token);

                       },
                       default);
            }
        }

        public async Task RegisterEmail(dynamic email, dynamic name, dynamic department)
        {
            UserEntity user = new UserEntity
            {
                AltEmail = email,
                Name = name,
                Department = department

            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            SendMailHelper.SendMail(user);
        }

        public List<UserEntity> GetAllUsers()
        {
            return context.Users.ToList();
        }

        private async Task BotCallback(IMessageActivity message, ITurnContext turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(message);
        }

        public static Attachment GetPrompt(string name)
        {
            AdaptiveCard card = new AdaptiveCard("1.2");
            card.Body.Add(new AdaptiveTextBlock
            {
                Text = "Hi " + name + "!",
                Weight = AdaptiveTextWeight.Bolder,
                HorizontalAlignment = AdaptiveHorizontalAlignment.Center,
                Wrap = true
            });
            card.Body.Add(new AdaptiveTextBlock
            {
                Text = "Please enter your Department and Alternate email address below:",
                Wrap = true
            });
            card.Body.Add(new AdaptiveTextInput
            {
                Placeholder = "Department",
                Id = "dept"
            });
            card.Body.Add(new AdaptiveTextInput
            {
                Placeholder = "Alternate Email Address",
                Id = "email"
            });
            AdaptiveTextInput email = (AdaptiveTextInput)card.Body.Where(el => el.Id == "email").FirstOrDefault();
            AdaptiveTextInput dept = (AdaptiveTextInput)card.Body.Where(el => el.Id == "dept").FirstOrDefault();
            // Do validations
            string data = "{ \"Name\": \""+name+"\", \"AltEmail\": \""+email.Value+"\", \"Department\": \""+ dept.Value + "\" }";
            card.Actions.Add(new AdaptiveSubmitAction
            {
                Title = "Submit",
                Id = "submit",
                DataJson = data
            });
            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };

        }

        public UserEntity GetUserEntity(string email, string department)
        {
            return context.Users.Where(u => u.AltEmail==email && u.Department==department).FirstOrDefault();
        }
    }
}
