using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boilerplate.web.Migrations
{
    /// <inheritdoc />
    public partial class addeSequenceNoinmpermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissons_MPermissions_permissionsId",
                table: "RolePermissons");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissons_Roles_mRolesId",
                table: "RolePermissons");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissons_permissionsId",
                table: "RolePermissons");

            migrationBuilder.DropColumn(
                name: "MenusId",
                table: "RolePermissons");

            migrationBuilder.RenameColumn(
                name: "mRolesId",
                table: "RolePermissons",
                newName: "MRolesId");

            migrationBuilder.RenameColumn(
                name: "permissionsId",
                table: "RolePermissons",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "RolePermissons",
                newName: "PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissons_mRolesId",
                table: "RolePermissons",
                newName: "IX_RolePermissons_MRolesId");

            migrationBuilder.AlterColumn<int>(
                name: "MRolesId",
                table: "RolePermissons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MPermissionsId",
                table: "RolePermissons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SequenceNo",
                table: "MPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissons_MPermissionsId",
                table: "RolePermissons",
                column: "MPermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissons_MPermissions_MPermissionsId",
                table: "RolePermissons",
                column: "MPermissionsId",
                principalTable: "MPermissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissons_Roles_MRolesId",
                table: "RolePermissons",
                column: "MRolesId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissons_MPermissions_MPermissionsId",
                table: "RolePermissons");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissons_Roles_MRolesId",
                table: "RolePermissons");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissons_MPermissionsId",
                table: "RolePermissons");

            migrationBuilder.DropColumn(
                name: "MPermissionsId",
                table: "RolePermissons");

            migrationBuilder.DropColumn(
                name: "SequenceNo",
                table: "MPermissions");

            migrationBuilder.RenameColumn(
                name: "MRolesId",
                table: "RolePermissons",
                newName: "mRolesId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "RolePermissons",
                newName: "permissionsId");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "RolePermissons",
                newName: "RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissons_MRolesId",
                table: "RolePermissons",
                newName: "IX_RolePermissons_mRolesId");

            migrationBuilder.AlterColumn<int>(
                name: "mRolesId",
                table: "RolePermissons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenusId",
                table: "RolePermissons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissons_permissionsId",
                table: "RolePermissons",
                column: "permissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissons_MPermissions_permissionsId",
                table: "RolePermissons",
                column: "permissionsId",
                principalTable: "MPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissons_Roles_mRolesId",
                table: "RolePermissons",
                column: "mRolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
