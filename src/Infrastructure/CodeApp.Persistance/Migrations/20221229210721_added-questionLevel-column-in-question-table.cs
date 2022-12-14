using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeApp.Persistance.Migrations
{
    public partial class addedquestionLevelcolumninquestiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Questions");
        }
    }
}
