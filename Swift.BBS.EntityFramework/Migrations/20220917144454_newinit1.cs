using Microsoft.EntityFrameworkCore.Migrations;

namespace Swift.BBS.EntityFramework.Migrations
{
    public partial class newinit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScanName",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScanPic",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScanType",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScanName",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ScanPic",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ScanType",
                table: "Images");
        }
    }
}
