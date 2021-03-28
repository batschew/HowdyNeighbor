using Microsoft.EntityFrameworkCore.Migrations;

namespace HowdyNeighbor.Data.Migrations
{
    public partial class SearchList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CostOfLivingImportance",
                table: "SearchList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternetProvidersImportance",
                table: "SearchList",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostOfLivingImportance",
                table: "SearchList");

            migrationBuilder.DropColumn(
                name: "InternetProvidersImportance",
                table: "SearchList");
        }
    }
}
