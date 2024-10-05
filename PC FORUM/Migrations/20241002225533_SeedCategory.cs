using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_FORUM.Migrations
{
    public partial class SeedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Общие проблемы с компьютером')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Процессоры')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Материнские (системные) платы')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Видеокарты')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Носители информации')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Жесткие диски, HDD')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'SSD')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'CD, DVD, Blu-ray (BD)')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Flash-накопители')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Внешние жесткие диски')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Восстановление данных')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Оперативная память')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Звук и акустические системы')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Охлаждение')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Корпуса')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Блоки питания, UPS (ИБП)')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Мониторы')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Серверы и серверное железо')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'BIOS, EFI')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES (N'Прошивки BIOS')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
