using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeusApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixColumnName3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer_SupplierId",
                table: "Banks");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerSupplierId",
                table: "Banks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerSupplierId",
                table: "Banks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "Customer_SupplierId",
                table: "Banks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
