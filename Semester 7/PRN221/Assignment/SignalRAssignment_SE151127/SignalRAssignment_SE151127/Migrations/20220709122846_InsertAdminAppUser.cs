using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRAssignment_SE151127.Migrations
{
    public partial class InsertAdminAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    INSERT INTO [dbo].[AppUsers]
                           ([FullName]
                           ,[Address]
                           ,[Email]
                           ,[Password])
                     VALUES
                           ('Administrator'
                           ,''
                           ,'admin@fstore.com'
                           ,'admin@@');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
