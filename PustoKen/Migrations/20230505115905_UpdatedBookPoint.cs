using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PustoKen.Migrations
{
    public partial class UpdatedBookPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Point",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
