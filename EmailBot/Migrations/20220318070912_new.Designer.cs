// <auto-generated />
using EmailBot.Common.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmailBot.Migrations
{
    [DbContext(typeof(BotDbContext))]
    [Migration("20220318070912_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmailBot.Common.Models.ConversationReferenceEntity", b =>
                {
                    b.Property<string>("ConversationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AadObjectId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActivityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BotId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChannelId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RowKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConversationId");

                    b.ToTable("ConversationReferenceEntities");
                });

            modelBuilder.Entity("EmailBot.Common.Models.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AltEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
