using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomStuffGeneratorPrivate.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuoteHistoryModels",
                columns: table => new
                {
                    QuoteHistoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuoteIdentifierString = table.Column<string>(nullable: true),
                    QuoteLifeStageIncrement = table.Column<int>(nullable: false),
                    QuoteLifStageDescription = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteHistoryModels", x => x.QuoteHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "QuoteModels",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuoteAuthor = table.Column<string>(nullable: true),
                    QuoteContent = table.Column<string>(nullable: true),
                    QuoteIdentifierString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteModels", x => x.QuoteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteHistoryModels");

            migrationBuilder.DropTable(
                name: "QuoteModels");
        }
    }
}
