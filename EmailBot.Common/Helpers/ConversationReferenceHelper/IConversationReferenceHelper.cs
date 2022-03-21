using EmailBot.Common.Models;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Schema.Teams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmailBot.Common.Helpers.ConversationReferenceHelper
{
    public interface IConversationReferenceHelper
    {
        Task AddorUpdateConversationRefrenceAsync(ConversationReference reference, TeamsChannelAccount member);
        Task DeleteConversationRefrenceAsync(ConversationReference reference, TeamsChannelAccount member);
        Task<ConversationReferenceEntity> GetConversationRefrenceAsync(string upn);
    }
}
