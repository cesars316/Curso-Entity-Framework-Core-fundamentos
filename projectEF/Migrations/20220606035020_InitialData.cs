using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEF.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Usuario",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("4eaf4501-49f8-4b6a-931e-f75f2212a401"), null, "Actividades personales", 30 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("4eaf4501-49f8-4b6a-931e-f75f2212a43e"), null, "Actividades pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo", "Usuario" },
                values: new object[] { new Guid("4eaf4501-49f8-4b6a-931e-f75f2212a410"), new Guid("4eaf4501-49f8-4b6a-931e-f75f2212a43e"), null, new DateTime(2022, 6, 5, 22, 50, 20, 343, DateTimeKind.Local).AddTicks(9734), 1, "Pago de servicios publicos", null });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo", "Usuario" },
                values: new object[] { new Guid("4eaf4501-49f8-4b6a-931e-f75f2212a411"), new Guid("4eaf4501-49f8-4b6a-931e-f75f2212a401"), null, new DateTime(2022, 6, 5, 22, 50, 20, 343, DateTimeKind.Local).AddTicks(9747), 0, "Terminar de ver pelicula en netflix", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TareaId",
                keyValue: new Guid("4eaf4501-49f8-4b6a-931e-f75f2212a410"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TareaId",
                keyValue: new Guid("4eaf4501-49f8-4b6a-931e-f75f2212a411"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4eaf4501-49f8-4b6a-931e-f75f2212a401"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4eaf4501-49f8-4b6a-931e-f75f2212a43e"));

            migrationBuilder.AlterColumn<string>(
                name: "Usuario",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
