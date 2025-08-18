using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortalBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobSeekerProfiles_JobSeekerProfileId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "JobSeekerProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ResumeUrl",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
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
                name: "ProfileURL",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "ProfileURL",
                table: "JobSeekerProfiles");

            migrationBuilder.DropColumn(
                name: "SavedJobIds",
                table: "JobSeekerProfiles");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "JobSeekerProfiles",
                keyColumn: "Skills",
                keyValue: null,
                column: "Skills",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "JobSeekerProfiles",
                keyColumn: "ResumeUrl",
                keyValue: null,
                column: "ResumeUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ResumeUrl",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "JobSeekerProfiles",
                keyColumn: "Phone",
                keyValue: null,
                column: "Phone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "JobSeekerProfiles",
                keyColumn: "Location",
                keyValue: null,
                column: "Location",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceYears",
                table: "JobSeekerProfiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "JobSeekerProfiles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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
