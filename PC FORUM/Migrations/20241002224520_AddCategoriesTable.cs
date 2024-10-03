using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_FORUM.Migrations
{
    public partial class AddCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Создание таблицы Categories
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            // Добавление столбца CategoryId в таблицу Topics
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Topics",
                nullable: false,
                defaultValue: 0);

            // Создание индекса для CategoryId
            migrationBuilder.CreateIndex(
                name: "IX_Topics_CategoryId",
                table: "Topics",
                column: "CategoryId");

            // Добавление внешнего ключа для связи с таблицей Categories
            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Categories_CategoryId",
                table: "Topics",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаление внешнего ключа и столбца CategoryId при откате миграции
            migrationBuilder.DropForeignKey(name: "FK_Topics_Categories_CategoryId", table: "Topics");
            migrationBuilder.DropIndex(name: "IX_Topics_CategoryId", table: "Topics");
            migrationBuilder.DropColumn(name: "CategoryId", table: "Topics");

            // Удаление таблицы Categories при откате миграции
            migrationBuilder.DropTable(name: "Categories");
        }

    }
}
