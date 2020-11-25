using Microsoft.EntityFrameworkCore.Migrations;

namespace FootBall.Web.Migrations
{
    public partial class IndexOnTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clubs_Name",
                table: "Clubs",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clubs_Name",
                table: "Clubs");
        }
    }
}
