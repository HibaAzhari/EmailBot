using Microsoft.EntityFrameworkCore.Migrations;

namespace EmailBot.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConversationReferenceEntities",
                columns: table => new
                {
                    ConversationId = table.Column<string>(nullable: false),
                    ActivityId = table.Column<string>(nullable: true),
                    ChannelId = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    ServiceUrl = table.Column<string>(nullable: true),
                    BotId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    UPN = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AadObjectId = table.Column<string>(nullable: true),
                    RowKey = table.Column<string>(nullable: true),
                    PartitionKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationReferenceEntities", x => x.ConversationId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AltEmail = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversationReferenceEntities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
