using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmailBot.Common.Models
{
    public class ConversationReferenceEntity
    {
        private string _upn;
        public string ActivityId { get; set; }
        public string ChannelId { get; set; }
        public string Locale { get; set; }
        public string ServiceUrl { get; set; }
        public string BotId { get; set; }
        public string UserId { get; set; }

        public string UPN
        {
            get => _upn;
            set => _upn = value.ToLower();
        }
        public string Name { get; set; }
        public string AadObjectId { get; set; }

        [Key]
        public string ConversationId { get; set; }
        public string RowKey { get; set; }
        public string PartitionKey { get; set; }
    }
}
