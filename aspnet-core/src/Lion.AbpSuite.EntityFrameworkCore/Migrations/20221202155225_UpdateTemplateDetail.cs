using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lion.AbpSuite.Migrations
{
    public partial class UpdateTemplateDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControlType",
                table: "SuiteTemplateDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControlType",
                table: "SuiteTemplateDetails");
        }
    }
}
