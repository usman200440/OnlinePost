using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONLINE_POST.Migrations
{
    public partial class form : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    f_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.f_id);
                });

            // Insert a row into the Forms table
            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "f_name", "status" },
                values: new object[] { "form", "off" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
