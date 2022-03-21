using EmailBot.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailBot.Common.Context
{
    public class BotDbContext : DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options)
        { }
        public DbSet<ConversationReferenceEntity> ConversationReferenceEntities { get; set; }
        public DbSet<UserEntity> Users { get; set; }

    }
}
