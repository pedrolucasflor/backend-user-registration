using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend_user_registration.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    facebookId = table.Column<string>(type: "longtext", nullable: false),
                    linkedinId = table.Column<string>(type: "longtext", nullable: false),
                    twitterId = table.Column<string>(type: "longtext", nullable: false),
                    instagramId = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    socialMediaid = table.Column<int>(type: "int", nullable: true),
                    cpf = table.Column<string>(type: "longtext", nullable: false),
                    rg = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_SocialMedia_socialMediaid",
                        column: x => x.socialMediaid,
                        principalTable: "SocialMedia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.id);
                    table.ForeignKey(
                        name: "FK_Adress_User_Userid",
                        column: x => x.Userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false),
                    label = table.Column<string>(type: "longtext", nullable: false),
                    number = table.Column<string>(type: "longtext", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.id);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_User_Userid",
                        column: x => x.Userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adress_Userid",
                table: "Adress",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_Userid",
                table: "PhoneNumber",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_User_socialMediaid",
                table: "User",
                column: "socialMediaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "SocialMedia");
        }
    }
}
