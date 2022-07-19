using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petfy.Data.Migrations
{
    public partial class SeedOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "City",
            //    table: "Owners",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.InsertData(
            //    table: "Owners",
            //    columns: new[] { "ID", "Address", "City", "DateOfBirth", "Name" },
            //    values: new object[] { 1, "Address 123", null, new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Owners",
            //    keyColumn: "ID",
            //    keyValue: 1);

            //migrationBuilder.AlterColumn<string>(
            //    name: "City",
            //    table: "Owners",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);
        }
    }
}
