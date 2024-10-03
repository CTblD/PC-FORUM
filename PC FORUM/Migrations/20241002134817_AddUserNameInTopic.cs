using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_FORUM.Migrations
{
    public partial class AddUserNameInTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Topics");
        }
    }
}
