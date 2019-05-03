using Microsoft.EntityFrameworkCore.Migrations;

namespace SportEventReminder.EntityFramework.Migrations
{
    public partial class added_alernate_key_for_table_Area : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Areas_Name",
                table: "Areas",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Areas_Name",
                table: "Areas");
        }
    }
}
