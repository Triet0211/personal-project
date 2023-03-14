using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObject.Migrations
{
    public partial class AddPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "pub_id", "city", "country", "publisher_name", "state" },
                values: new object[] { 1, "Hà Nội", "Việt Nam", "NXB Kim Đồng", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "pub_id",
                keyValue: 1);
        }
    }
}
