using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootBall.Web.Migrations
{
    public partial class addTypeClassification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeSessionId",
                table: "Sessions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeSessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSessions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TypeSessionId",
                table: "Sessions",
                column: "TypeSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_TypeSessions_TypeSessionId",
                table: "Sessions",
                column: "TypeSessionId",
                principalTable: "TypeSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_TypeSessions_TypeSessionId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "TypeSessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_TypeSessionId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TypeSessionId",
                table: "Sessions");
        }
    }
}
