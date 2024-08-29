using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomationOfThePurchasingActOfRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class renamedIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MerchandisePricePurchaseForm_MerchandisePrices_PricesMercha~",
                table: "MerchandisePricePurchaseForm");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchandisePricePurchaseForm_purchaseForms_PurchaseFormsPur~",
                table: "MerchandisePricePurchaseForm");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchandisePurchaseForm_Merchandises_PurchasedMerchandisesM~",
                table: "MerchandisePurchaseForm");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchandisePurchaseForm_purchaseForms_PurchaseFormsPurchase~",
                table: "MerchandisePurchaseForm");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Suppliers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SignatureId",
                table: "Signatures",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PurchaseFormId",
                table: "purchaseForms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "Organizations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MerchandiseId",
                table: "Merchandises",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PurchasedMerchandisesMerchandiseId",
                table: "MerchandisePurchaseForm",
                newName: "PurchasedMerchandisesId");

            migrationBuilder.RenameColumn(
                name: "PurchaseFormsPurchaseFormId",
                table: "MerchandisePurchaseForm",
                newName: "PurchaseFormsId");

            migrationBuilder.RenameIndex(
                name: "IX_MerchandisePurchaseForm_PurchasedMerchandisesMerchandiseId",
                table: "MerchandisePurchaseForm",
                newName: "IX_MerchandisePurchaseForm_PurchasedMerchandisesId");

            migrationBuilder.RenameColumn(
                name: "MerchandisePriceId",
                table: "MerchandisePrices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PurchaseFormsPurchaseFormId",
                table: "MerchandisePricePurchaseForm",
                newName: "PurchaseFormsId");

            migrationBuilder.RenameColumn(
                name: "PricesMerchandisePriceId",
                table: "MerchandisePricePurchaseForm",
                newName: "PricesId");

            migrationBuilder.RenameIndex(
                name: "IX_MerchandisePricePurchaseForm_PurchaseFormsPurchaseFormId",
                table: "MerchandisePricePurchaseForm",
                newName: "IX_MerchandisePricePurchaseForm_PurchaseFormsId");

            migrationBuilder.RenameColumn(
                name: "MeasurementUnitId",
                table: "MeasurementUnits",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FormKeyId",
                table: "FormKeys",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeePositionId",
                table: "EmployeePositions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ApproverId",
                table: "Approvers",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchandisePricePurchaseForm_MerchandisePrices_PricesId",
                table: "MerchandisePricePurchaseForm",
                column: "PricesId",
                principalTable: "MerchandisePrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchandisePricePurchaseForm_purchaseForms_PurchaseFormsId",
                table: "MerchandisePricePurchaseForm",
                column: "PurchaseFormsId",
                principalTable: "purchaseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchandisePurchaseForm_Merchandises_PurchasedMerchandisesId",
                table: "MerchandisePurchaseForm",
                column: "PurchasedMerchandisesId",
                principalTable: "Merchandises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchandisePurchaseForm_purchaseForms_PurchaseFormsId",
                table: "MerchandisePurchaseForm",
                column: "PurchaseFormsId",
                principalTable: "purchaseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MerchandisePricePurchaseForm_MerchandisePrices_PricesId",
                table: "MerchandisePricePurchaseForm");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchandisePricePurchaseForm_purchaseForms_PurchaseFormsId",
                table: "MerchandisePricePurchaseForm");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchandisePurchaseForm_Merchandises_PurchasedMerchandisesId",
                table: "MerchandisePurchaseForm");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchandisePurchaseForm_purchaseForms_PurchaseFormsId",
                table: "MerchandisePurchaseForm");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suppliers",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Signatures",
                newName: "SignatureId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "purchaseForms",
                newName: "PurchaseFormId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Organizations",
                newName: "OrganizationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Merchandises",
                newName: "MerchandiseId");

            migrationBuilder.RenameColumn(
                name: "PurchasedMerchandisesId",
                table: "MerchandisePurchaseForm",
                newName: "PurchasedMerchandisesMerchandiseId");

            migrationBuilder.RenameColumn(
                name: "PurchaseFormsId",
                table: "MerchandisePurchaseForm",
                newName: "PurchaseFormsPurchaseFormId");

            migrationBuilder.RenameIndex(
                name: "IX_MerchandisePurchaseForm_PurchasedMerchandisesId",
                table: "MerchandisePurchaseForm",
                newName: "IX_MerchandisePurchaseForm_PurchasedMerchandisesMerchandiseId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MerchandisePrices",
                newName: "MerchandisePriceId");

            migrationBuilder.RenameColumn(
                name: "PurchaseFormsId",
                table: "MerchandisePricePurchaseForm",
                newName: "PurchaseFormsPurchaseFormId");

            migrationBuilder.RenameColumn(
                name: "PricesId",
                table: "MerchandisePricePurchaseForm",
                newName: "PricesMerchandisePriceId");

            migrationBuilder.RenameIndex(
                name: "IX_MerchandisePricePurchaseForm_PurchaseFormsId",
                table: "MerchandisePricePurchaseForm",
                newName: "IX_MerchandisePricePurchaseForm_PurchaseFormsPurchaseFormId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MeasurementUnits",
                newName: "MeasurementUnitId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FormKeys",
                newName: "FormKeyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmployeePositions",
                newName: "EmployeePositionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Approvers",
                newName: "ApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchandisePricePurchaseForm_MerchandisePrices_PricesMercha~",
                table: "MerchandisePricePurchaseForm",
                column: "PricesMerchandisePriceId",
                principalTable: "MerchandisePrices",
                principalColumn: "MerchandisePriceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchandisePricePurchaseForm_purchaseForms_PurchaseFormsPur~",
                table: "MerchandisePricePurchaseForm",
                column: "PurchaseFormsPurchaseFormId",
                principalTable: "purchaseForms",
                principalColumn: "PurchaseFormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchandisePurchaseForm_Merchandises_PurchasedMerchandisesM~",
                table: "MerchandisePurchaseForm",
                column: "PurchasedMerchandisesMerchandiseId",
                principalTable: "Merchandises",
                principalColumn: "MerchandiseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchandisePurchaseForm_purchaseForms_PurchaseFormsPurchase~",
                table: "MerchandisePurchaseForm",
                column: "PurchaseFormsPurchaseFormId",
                principalTable: "purchaseForms",
                principalColumn: "PurchaseFormId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
