using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StackOverFlow.Migrations
{
    public partial class AddConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Answers__Questio__65370702",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDAnswers",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "Fk_BadgeIDBadge",
                table: "BadgesEarnedByUser");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDBadge",
                table: "BadgesEarnedByUser");

            migrationBuilder.DropForeignKey(
                name: "FK__Bookmarks__Quest__5F7E2DAC",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK__Bookmarks__UserI__5E8A0973",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK__Companies__UserI__7755B73D",
                table: "CompaniesToExclude");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDEducation",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK__Industrie__UserI__6BE40491",
                table: "IndustriesToExclude");

            migrationBuilder.DropForeignKey(
                name: "FK__JobProfil__UserI__690797E6",
                table: "JobProfile");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDQuestion",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK__Tags__QuestionID__625A9A57",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDTech",
                table: "TechnologiesUsedAsStudent");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDTechInJob",
                table: "TechnologiesUsedByUserInJob");

            migrationBuilder.DropForeignKey(
                name: "FK__TechPrefe__UserI__6EC0713C",
                table: "TechPreferNotToWorkWith");

            migrationBuilder.DropForeignKey(
                name: "FK__TechWantT__UserI__719CDDE7",
                table: "TechWantToWorkWith");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TechWantToWorkWith",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TechPreferNotToWorkWith",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TechnologiesUsedByUserInJob",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TechnologiesUsedAsStudent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Vote",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalViews",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfAsk",
                table: "Questions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "JobProfile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "IndustriesToExclude",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "CompaniesToExclude",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Bookmarks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Bookmarks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "BadgesEarnedByUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEarned",
                table: "BadgesEarnedByUser",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BadgeID",
                table: "BadgesEarnedByUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BadgeName",
                table: "Badges",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VisitedDays",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Reputation",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfileViews",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Vote",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Answers__Questio__65370702",
                table: "Answers",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDAnswers",
                table: "Answers",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_BadgeIDBadge",
                table: "BadgesEarnedByUser",
                column: "BadgeID",
                principalTable: "Badges",
                principalColumn: "BadgeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDBadge",
                table: "BadgesEarnedByUser",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Bookmarks__Quest__5F7E2DAC",
                table: "Bookmarks",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Bookmarks__UserI__5E8A0973",
                table: "Bookmarks",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Companies__UserI__7755B73D",
                table: "CompaniesToExclude",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDEducation",
                table: "Education",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Industrie__UserI__6BE40491",
                table: "IndustriesToExclude",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__JobProfil__UserI__690797E6",
                table: "JobProfile",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDQuestion",
                table: "Questions",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Tags__QuestionID__625A9A57",
                table: "Tags",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDTech",
                table: "TechnologiesUsedAsStudent",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDTechInJob",
                table: "TechnologiesUsedByUserInJob",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__TechPrefe__UserI__6EC0713C",
                table: "TechPreferNotToWorkWith",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__TechWantT__UserI__719CDDE7",
                table: "TechWantToWorkWith",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Answers__Questio__65370702",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDAnswers",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "Fk_BadgeIDBadge",
                table: "BadgesEarnedByUser");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDBadge",
                table: "BadgesEarnedByUser");

            migrationBuilder.DropForeignKey(
                name: "FK__Bookmarks__Quest__5F7E2DAC",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK__Bookmarks__UserI__5E8A0973",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK__Companies__UserI__7755B73D",
                table: "CompaniesToExclude");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDEducation",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK__Industrie__UserI__6BE40491",
                table: "IndustriesToExclude");

            migrationBuilder.DropForeignKey(
                name: "FK__JobProfil__UserI__690797E6",
                table: "JobProfile");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDQuestion",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK__Tags__QuestionID__625A9A57",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDTech",
                table: "TechnologiesUsedAsStudent");

            migrationBuilder.DropForeignKey(
                name: "Fk_UserIDTechInJob",
                table: "TechnologiesUsedByUserInJob");

            migrationBuilder.DropForeignKey(
                name: "FK__TechPrefe__UserI__6EC0713C",
                table: "TechPreferNotToWorkWith");

            migrationBuilder.DropForeignKey(
                name: "FK__TechWantT__UserI__719CDDE7",
                table: "TechWantToWorkWith");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TechWantToWorkWith",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TechPreferNotToWorkWith",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TechnologiesUsedByUserInJob",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TechnologiesUsedAsStudent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Tags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Vote",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TotalViews",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfAsk",
                table: "Questions",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "JobProfile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "IndustriesToExclude",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Education",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "CompaniesToExclude",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Bookmarks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Bookmarks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "BadgesEarnedByUser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEarned",
                table: "BadgesEarnedByUser",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "BadgeID",
                table: "BadgesEarnedByUser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BadgeName",
                table: "Badges",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "VisitedDays",
                table: "AppUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Reputation",
                table: "AppUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileViews",
                table: "AppUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Vote",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK__Answers__Questio__65370702",
                table: "Answers",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDAnswers",
                table: "Answers",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Fk_BadgeIDBadge",
                table: "BadgesEarnedByUser",
                column: "BadgeID",
                principalTable: "Badges",
                principalColumn: "BadgeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDBadge",
                table: "BadgesEarnedByUser",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Bookmarks__Quest__5F7E2DAC",
                table: "Bookmarks",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Bookmarks__UserI__5E8A0973",
                table: "Bookmarks",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Companies__UserI__7755B73D",
                table: "CompaniesToExclude",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDEducation",
                table: "Education",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Industrie__UserI__6BE40491",
                table: "IndustriesToExclude",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__JobProfil__UserI__690797E6",
                table: "JobProfile",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDQuestion",
                table: "Questions",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Tags__QuestionID__625A9A57",
                table: "Tags",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDTech",
                table: "TechnologiesUsedAsStudent",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Fk_UserIDTechInJob",
                table: "TechnologiesUsedByUserInJob",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__TechPrefe__UserI__6EC0713C",
                table: "TechPreferNotToWorkWith",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__TechWantT__UserI__719CDDE7",
                table: "TechWantToWorkWith",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
