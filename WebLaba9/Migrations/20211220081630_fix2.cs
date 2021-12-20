using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLaba9.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_AspNetUsers_RecipientEmail",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_AspNetUsers_SenderEmail",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_RecipientEmail",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_SenderEmail",
                table: "Emails");

            migrationBuilder.AlterColumn<string>(
                name: "SenderEmail",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipientEmail",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipientId",
                table: "Emails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Emails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_RecipientId",
                table: "Emails",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_SenderId",
                table: "Emails",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_AspNetUsers_RecipientId",
                table: "Emails",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_AspNetUsers_SenderId",
                table: "Emails",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_AspNetUsers_RecipientId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_AspNetUsers_SenderId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_RecipientId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_SenderId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Emails");

            migrationBuilder.AlterColumn<string>(
                name: "SenderEmail",
                table: "Emails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipientEmail",
                table: "Emails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_RecipientEmail",
                table: "Emails",
                column: "RecipientEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_SenderEmail",
                table: "Emails",
                column: "SenderEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_AspNetUsers_RecipientEmail",
                table: "Emails",
                column: "RecipientEmail",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_AspNetUsers_SenderEmail",
                table: "Emails",
                column: "SenderEmail",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
