using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_FORUM.Migrations
{
    public partial class AddCategories : Migration
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

            // Добавление поля CategoryId в таблицу Topics с внешним ключом
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Общие проблемы с компьютером')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Процессоры')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Материнские (системные) платы')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Видеокарты')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Носители информации')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Жесткие диски, HDD')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('SSD')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('CD, DVD, Blu-ray (BD)')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Flash-накопители')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Внешние жесткие диски')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Восстановление данных')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Оперативная память')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Звук и акустические системы')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Охлаждение')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Корпуса')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Блоки питания, UPS (ИБП)')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Мониторы')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Серверы и серверное железо')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('BIOS, EFI')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Прошивки BIOS')");
        }

    }
}
