using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortalBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialSync : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobSeekerProfiles_JobSeekerProfileId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "JobSeekerProfiles",
                newName: "ProfileURL");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "Phone",
                table: "JobSeekerProfiles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceYears",
                table: "JobSeekerProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedJobIds",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyWebsite",
                table: "EmployerProfiles",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobSeekerProfiles_JobSeekerProfileId",
                table: "Applications",
                column: "JobSeekerProfileId",
                principalTable: "JobSeekerProfiles",
                principalColumn: "JobSeekerProfileId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobSeekerProfiles_JobSeekerProfileId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SavedJobIds",
                table: "JobSeekerProfiles");

            migrationBuilder.RenameColumn(
                name: "ProfileURL",
                table: "JobSeekerProfiles",
                newName: "FullName");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceYears",
                table: "JobSeekerProfiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "EmployerProfiles",
                keyColumn: "CompanyWebsite",
                keyValue: null,
                column: "CompanyWebsite",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyWebsite",
                table: "EmployerProfiles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobSeekerProfiles_JobSeekerProfileId",
                table: "Applications",
                column: "JobSeekerProfileId",
                principalTable: "JobSeekerProfiles",
                principalColumn: "JobSeekerProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
