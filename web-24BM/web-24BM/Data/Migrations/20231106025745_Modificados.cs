using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_24BM.Data.Migrations
{
    /// <inheritdoc />
    public partial class Modificados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CURP",
                table: "curriculums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CURP",
                table: "curriculums");
        }
    }
}
