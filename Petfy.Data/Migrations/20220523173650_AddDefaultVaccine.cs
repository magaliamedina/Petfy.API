using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petfy.Data.Migrations
{
    public partial class AddDefaultVaccine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //    table: "Vaccines",
            //    columns: new[] { "ID", "Lab", "Name" },
            //    values: new object[] { 1, "Lab Demo", "Vaccine Demo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Vaccines",
            //    keyColumn: "ID",
            //    keyValue: 1);
        }
    }
}
