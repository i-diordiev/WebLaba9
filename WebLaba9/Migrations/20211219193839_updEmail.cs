using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLaba9.Migrations
{
    public partial class updEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipientEmail",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderEmail",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientEmail",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "Emails");
        }
    }
}
