using Microsoft.EntityFrameworkCore.Migrations;

namespace SportEventReminder.EntityFramework.Migrations
{
    public partial class create_index_for_table_Area_prop_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Areas_Name",
                table: "Areas",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Areas_Name",
                table: "Areas");
        }
    }
}
