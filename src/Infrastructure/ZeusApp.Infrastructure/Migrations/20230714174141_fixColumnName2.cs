using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeusApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixColumnName2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_Customer_Suppliers_CustomerSupplierId",
                table: "Banks");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Customer_Suppliers_CustomerSupplierId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Suppliers_CustomerCategories_CustomerCategoryId",
                table: "Customer_Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherAddresses_Customer_Suppliers_CustomerSupplierId",
                table: "OtherAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedPersons_Customer_Suppliers_CustomerSupplierId",
                table: "RelatedPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Customer_Suppliers_CustomerSupplierId",
                table: "SalesInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Suppliers",
                table: "Customer_Suppliers");

            migrationBuilder.RenameTable(
                name: "Customer_Suppliers",
                newName: "CustomerSuppliers");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Suppliers_CustomerCategoryId",
                table: "CustomerSuppliers",
                newName: "IX_CustomerSuppliers_CustomerCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerSuppliers",
                table: "CustomerSuppliers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_CustomerSuppliers_CustomerSupplierId",
                table: "Banks",
                column: "CustomerSupplierId",
                principalTable: "CustomerSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CustomerSuppliers_CustomerSupplierId",
                table: "Contacts",
                column: "CustomerSupplierId",
                principalTable: "CustomerSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSuppliers_CustomerCategories_CustomerCategoryId",
                table: "CustomerSuppliers",
                column: "CustomerCategoryId",
                principalTable: "CustomerCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherAddresses_CustomerSuppliers_CustomerSupplierId",
                table: "OtherAddresses",
                column: "CustomerSupplierId",
                principalTable: "CustomerSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedPersons_CustomerSuppliers_CustomerSupplierId",
                table: "RelatedPersons",
                column: "CustomerSupplierId",
                principalTable: "CustomerSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_CustomerSuppliers_CustomerSupplierId",
                table: "SalesInvoices",
                column: "CustomerSupplierId",
                principalTable: "CustomerSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_CustomerSuppliers_CustomerSupplierId",
                table: "Banks");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CustomerSuppliers_CustomerSupplierId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSuppliers_CustomerCategories_CustomerCategoryId",
                table: "CustomerSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherAddresses_CustomerSuppliers_CustomerSupplierId",
                table: "OtherAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_RelatedPersons_CustomerSuppliers_CustomerSupplierId",
                table: "RelatedPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_CustomerSuppliers_CustomerSupplierId",
                table: "SalesInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerSuppliers",
                table: "CustomerSuppliers");

            migrationBuilder.RenameTable(
                name: "CustomerSuppliers",
                newName: "Customer_Suppliers");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSuppliers_CustomerCategoryId",
                table: "Customer_Suppliers",
                newName: "IX_Customer_Suppliers_CustomerCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Suppliers",
                table: "Customer_Suppliers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_Customer_Suppliers_CustomerSupplierId",
                table: "Banks",
                column: "CustomerSupplierId",
                principalTable: "Customer_Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Customer_Suppliers_CustomerSupplierId",
                table: "Contacts",
                column: "CustomerSupplierId",
                principalTable: "Customer_Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Suppliers_CustomerCategories_CustomerCategoryId",
                table: "Customer_Suppliers",
                column: "CustomerCategoryId",
                principalTable: "CustomerCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherAddresses_Customer_Suppliers_CustomerSupplierId",
                table: "OtherAddresses",
                column: "CustomerSupplierId",
                principalTable: "Customer_Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedPersons_Customer_Suppliers_CustomerSupplierId",
                table: "RelatedPersons",
                column: "CustomerSupplierId",
                principalTable: "Customer_Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Customer_Suppliers_CustomerSupplierId",
                table: "SalesInvoices",
                column: "CustomerSupplierId",
                principalTable: "Customer_Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
