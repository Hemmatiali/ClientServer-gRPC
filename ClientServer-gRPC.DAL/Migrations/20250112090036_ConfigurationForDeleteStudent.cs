using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientServer_gRPC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurationForDeleteStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Students_StudentId",
                table: "PhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Students_StudentId",
                table: "PhoneNumber",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Students_StudentId",
                table: "PhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Students_StudentId",
                table: "PhoneNumber",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
