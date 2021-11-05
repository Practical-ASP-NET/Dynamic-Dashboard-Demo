using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicDashboards.Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dashboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Panel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    ComponentType = table.Column<string>(type: "TEXT", nullable: true),
                    DashboardId = table.Column<int>(type: "INTEGER", nullable: true),
                    DashboardId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Panel_Dashboards_DashboardId",
                        column: x => x.DashboardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Panel_Dashboards_DashboardId1",
                        column: x => x.DashboardId1,
                        principalTable: "Dashboards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Panel_DashboardId",
                table: "Panel",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Panel_DashboardId1",
                table: "Panel",
                column: "DashboardId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Panel");

            migrationBuilder.DropTable(
                name: "Dashboards");
        }
    }
}
