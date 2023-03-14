using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRAssignment_SE151127.Migrations
{
    public partial class InsertCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    INSERT INTO [dbo].[PostCategories]
                           ([CategoryName]
                           ,[Description])
                     VALUES
                           (N'Công nghệ thông tin'
                           ,'IT'),
		                   (N'Sức khỏe'
                           ,'Health'),
                            (N'Thời trang'
                           ,'Fashion');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
