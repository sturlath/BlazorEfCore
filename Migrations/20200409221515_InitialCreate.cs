using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorEfCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostalSystem",
                columns: table => new
                {
                    PostalSystemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalSystem", x => x.PostalSystemId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    MySettingsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    PostalSystemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.MySettingsId);
                    table.ForeignKey(
                        name: "FK_Settings_PostalSystem_PostalSystemId",
                        column: x => x.PostalSystemId,
                        principalTable: "PostalSystem",
                        principalColumn: "PostalSystemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_PostalSystemId",
                table: "Settings",
                column: "PostalSystemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "PostalSystem");
        }
    }
}
