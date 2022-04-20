using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotesFinal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: false),
                    Quote = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Citation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.QuoteId);
                });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "QuoteId", "Author", "Citation", "Date", "Quote", "Subject" },
                values: new object[] { 1, "Kanye West", "Twitter", "Jan 16, 2018", "You can't look at a glass half full or empty if it's overflowing", "Perspective" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "QuoteId", "Author", "Citation", "Date", "Quote", "Subject" },
                values: new object[] { 2, "Elon Musk", "Twitter", "Apr 9, 2022", "69.420% of statistics are false", "Satire" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "QuoteId", "Author", "Citation", "Date", "Quote", "Subject" },
                values: new object[] { 3, "Abraham Lincoln", "Gettysburg Address", "Nov 19, 1863", "Four score and seven years ago our fathers brought forth on this continent, a new nation, conceived in Liberty, and dedicated to the proposition that all men are created equal.", "History" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");
        }
    }
}
