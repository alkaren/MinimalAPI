using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RuleCarProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DayName = table.Column<string>(type: "TEXT", nullable: false),
                    SequenceDay = table.Column<int>(type: "INTEGER", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalProduction = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleCarProductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCarProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Senin = table.Column<int>(type: "INTEGER", nullable: false),
                    Selasa = table.Column<int>(type: "INTEGER", nullable: false),
                    Rabu = table.Column<int>(type: "INTEGER", nullable: false),
                    Kamis = table.Column<int>(type: "INTEGER", nullable: false),
                    Jumat = table.Column<int>(type: "INTEGER", nullable: false),
                    Sabtu = table.Column<int>(type: "INTEGER", nullable: false),
                    Minggu = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCarProductions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RuleCarProductions",
                columns: new[] { "Id", "DayName", "Priority", "SequenceDay", "TotalProduction" },
                values: new object[] { 1, "Senin", 2, 1, 4 });

            migrationBuilder.InsertData(
                table: "RuleCarProductions",
                columns: new[] { "Id", "DayName", "Priority", "SequenceDay", "TotalProduction" },
                values: new object[] { 2, "Selasa", 1, 2, 5 });

            migrationBuilder.InsertData(
                table: "RuleCarProductions",
                columns: new[] { "Id", "DayName", "Priority", "SequenceDay", "TotalProduction" },
                values: new object[] { 3, "Rabu", 2, 3, 1 });

            migrationBuilder.InsertData(
                table: "RuleCarProductions",
                columns: new[] { "Id", "DayName", "Priority", "SequenceDay", "TotalProduction" },
                values: new object[] { 4, "Kamis", 1, 4, 7 });

            migrationBuilder.InsertData(
                table: "RuleCarProductions",
                columns: new[] { "Id", "DayName", "Priority", "SequenceDay", "TotalProduction" },
                values: new object[] { 5, "Jumat", 1, 5, 6 });

            migrationBuilder.InsertData(
                table: "RuleCarProductions",
                columns: new[] { "Id", "DayName", "Priority", "SequenceDay", "TotalProduction" },
                values: new object[] { 6, "Sabtu", 2, 6, 4 });

            migrationBuilder.InsertData(
                table: "RuleCarProductions",
                columns: new[] { "Id", "DayName", "Priority", "SequenceDay", "TotalProduction" },
                values: new object[] { 7, "Minggu", 0, 7, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RuleCarProductions");

            migrationBuilder.DropTable(
                name: "TransactionCarProductions");
        }
    }
}
