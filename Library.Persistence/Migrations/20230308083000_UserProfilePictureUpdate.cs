using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserProfilePictureUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "/images/default-user-img.jpg",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "/images/empty-book-img.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "/images/empty-book-img.png",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "/images/default-user-img.jpg");
        }
    }
}
