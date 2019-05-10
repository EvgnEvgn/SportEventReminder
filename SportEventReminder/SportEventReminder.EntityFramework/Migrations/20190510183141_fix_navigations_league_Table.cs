using Microsoft.EntityFrameworkCore.Migrations;

namespace SportEventReminder.EntityFramework.Migrations
{
    public partial class fix_navigations_league_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Seasons_CurrentSeasonId",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_CurrentSeasonId",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "CurrentSeasonId",
                table: "Leagues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentSeasonId",
                table: "Leagues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_CurrentSeasonId",
                table: "Leagues",
                column: "CurrentSeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Seasons_CurrentSeasonId",
                table: "Leagues",
                column: "CurrentSeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
