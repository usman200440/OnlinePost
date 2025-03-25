using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONLINE_POST.Migrations
{
    public partial class addbranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "branch_name",
                table: "Delivery_Histories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "branch_name",
                table: "Delivery_Histories");
        }
    }
}
