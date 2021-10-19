using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_face_auth.Migrations
{
    public partial class AddedUserFace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersFace",
                columns: table => new
                {
                    idface = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    iduser = table.Column<int>(type: "INTEGER", nullable: false),
                    image = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFace", x => x.idface);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersFace");
        }
    }
}
