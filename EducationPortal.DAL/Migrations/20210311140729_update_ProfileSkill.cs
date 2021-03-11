using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationPortal.DAL.Migrations
{
    public partial class update_ProfileSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileSkill_Skills_SkillId",
                table: "ProfileSkill");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "ProfileSkill",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileSkill_SkillId",
                table: "ProfileSkill",
                newName: "IX_ProfileSkill_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileSkill_Skills_Id",
                table: "ProfileSkill",
                column: "Id",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileSkill_Skills_Id",
                table: "ProfileSkill");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProfileSkill",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileSkill_Id",
                table: "ProfileSkill",
                newName: "IX_ProfileSkill_SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileSkill_Skills_SkillId",
                table: "ProfileSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
