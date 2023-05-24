using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bmerketo.Migrations
{
    /// <inheritdoc />
    public partial class NF13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "UserProfiles",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "UserProfiles",
                newName: "Company");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "UserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AddressId",
                table: "UserProfiles",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_AddressEntity_AddressId",
                table: "UserProfiles",
                column: "AddressId",
                principalTable: "AddressEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_AddressEntity_AddressId",
                table: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AddressEntity");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_AddressId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "UserProfiles",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "UserProfiles",
                newName: "PostalCode");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
