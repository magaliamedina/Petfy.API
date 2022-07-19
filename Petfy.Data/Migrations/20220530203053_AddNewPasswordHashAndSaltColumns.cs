using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petfy.Data.Migrations
{
    public partial class AddNewPasswordHashAndSaltColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccine_Pets_PetID",
                table: "PetVaccine");

            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccine_Vaccines_VaccineID",
                table: "PetVaccine");

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vaccines",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateApplied",
                table: "PetVaccine");

            migrationBuilder.RenameColumn(
                name: "VaccineID",
                table: "PetVaccine",
                newName: "VaccinesID");

            migrationBuilder.RenameColumn(
                name: "PetID",
                table: "PetVaccine",
                newName: "PetsID");

            migrationBuilder.RenameIndex(
                name: "IX_PetVaccine_VaccineID",
                table: "PetVaccine",
                newName: "IX_PetVaccine_VaccinesID");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccine_Pets_PetsID",
                table: "PetVaccine",
                column: "PetsID",
                principalTable: "Pets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccine_Vaccines_VaccinesID",
                table: "PetVaccine",
                column: "VaccinesID",
                principalTable: "Vaccines",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccine_Pets_PetsID",
                table: "PetVaccine");

            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccine_Vaccines_VaccinesID",
                table: "PetVaccine");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "VaccinesID",
                table: "PetVaccine",
                newName: "VaccineID");

            migrationBuilder.RenameColumn(
                name: "PetsID",
                table: "PetVaccine",
                newName: "PetID");

            migrationBuilder.RenameIndex(
                name: "IX_PetVaccine_VaccinesID",
                table: "PetVaccine",
                newName: "IX_PetVaccine_VaccineID");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApplied",
                table: "PetVaccine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "ID", "Address", "City", "DateOfBirth", "Name" },
                values: new object[] { 1, "Address 123", null, new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default" });

            migrationBuilder.InsertData(
                table: "Vaccines",
                columns: new[] { "ID", "Lab", "Name" },
                values: new object[] { 1, "Lab Demo", "Vaccine Demo" });

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccine_Pets_PetID",
                table: "PetVaccine",
                column: "PetID",
                principalTable: "Pets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccine_Vaccines_VaccineID",
                table: "PetVaccine",
                column: "VaccineID",
                principalTable: "Vaccines",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
