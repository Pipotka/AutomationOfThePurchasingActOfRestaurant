using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomationOfThePurchasingActOfRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                columns: table => new
                {
                    EmployeePositionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => x.EmployeePositionId);
                });

            migrationBuilder.CreateTable(
                name: "FormKeys",
                columns: table => new
                {
                    FormKeyId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchaseFormId = table.Column<Guid>(type: "uuid", nullable: false),
                    OKUD = table.Column<string>(type: "text", nullable: false),
                    OKPO = table.Column<string>(type: "text", nullable: false),
                    TIN = table.Column<string>(type: "text", nullable: false),
                    OKDP = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormKeys", x => x.FormKeyId);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnits",
                columns: table => new
                {
                    MeasurementUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OKEIKey = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnits", x => x.MeasurementUnitId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    StructuralUnit = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Approvers",
                columns: table => new
                {
                    ApproverId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvers", x => x.ApproverId);
                    table.ForeignKey(
                        name: "FK_Approvers_EmployeePositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "EmployeePositions",
                        principalColumn: "EmployeePositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeePositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "EmployeePositions",
                        principalColumn: "EmployeePositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Merchandises",
                columns: table => new
                {
                    MerchandiseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MerchandiseKey = table.Column<int>(type: "integer", nullable: false),
                    MeasurementUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandises", x => x.MerchandiseId);
                    table.ForeignKey(
                        name: "FK_Merchandises_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "MeasurementUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    SignatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApproverId = table.Column<Guid>(type: "uuid", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    SignatureDecryption = table.Column<string>(type: "text", nullable: false),
                    IsObsolete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.SignatureId);
                    table.ForeignKey(
                        name: "FK_Signatures_Approvers_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Approvers",
                        principalColumn: "ApproverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseForms",
                columns: table => new
                {
                    PurchaseFormId = table.Column<Guid>(type: "uuid", nullable: false),
                    FormKeyId = table.Column<Guid>(type: "uuid", nullable: false),
                    SponsorOrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApprovingOfficerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentNumber = table.Column<int>(type: "integer", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AddressOfPurchase = table.Column<string>(type: "text", nullable: false),
                    ProcurementSpecialistId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesmanId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseForms", x => x.PurchaseFormId);
                    table.ForeignKey(
                        name: "FK_purchaseForms_Approvers_ApprovingOfficerId",
                        column: x => x.ApprovingOfficerId,
                        principalTable: "Approvers",
                        principalColumn: "ApproverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseForms_Employees_ProcurementSpecialistId",
                        column: x => x.ProcurementSpecialistId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseForms_FormKeys_FormKeyId",
                        column: x => x.FormKeyId,
                        principalTable: "FormKeys",
                        principalColumn: "FormKeyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseForms_Organizations_SponsorOrganizationId",
                        column: x => x.SponsorOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseForms_Suppliers_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchandisePrices",
                columns: table => new
                {
                    MerchandisePriceId = table.Column<Guid>(type: "uuid", nullable: false),
                    MerchandiseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CostPerUnit = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchandisePrices", x => x.MerchandisePriceId);
                    table.ForeignKey(
                        name: "FK_MerchandisePrices_Merchandises_MerchandiseId",
                        column: x => x.MerchandiseId,
                        principalTable: "Merchandises",
                        principalColumn: "MerchandiseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchandisePurchaseForm",
                columns: table => new
                {
                    PurchaseFormsPurchaseFormId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchasedMerchandisesMerchandiseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchandisePurchaseForm", x => new { x.PurchaseFormsPurchaseFormId, x.PurchasedMerchandisesMerchandiseId });
                    table.ForeignKey(
                        name: "FK_MerchandisePurchaseForm_Merchandises_PurchasedMerchandisesM~",
                        column: x => x.PurchasedMerchandisesMerchandiseId,
                        principalTable: "Merchandises",
                        principalColumn: "MerchandiseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchandisePurchaseForm_purchaseForms_PurchaseFormsPurchase~",
                        column: x => x.PurchaseFormsPurchaseFormId,
                        principalTable: "purchaseForms",
                        principalColumn: "PurchaseFormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchandisePricePurchaseForm",
                columns: table => new
                {
                    PricesMerchandisePriceId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchaseFormsPurchaseFormId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchandisePricePurchaseForm", x => new { x.PricesMerchandisePriceId, x.PurchaseFormsPurchaseFormId });
                    table.ForeignKey(
                        name: "FK_MerchandisePricePurchaseForm_MerchandisePrices_PricesMercha~",
                        column: x => x.PricesMerchandisePriceId,
                        principalTable: "MerchandisePrices",
                        principalColumn: "MerchandisePriceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchandisePricePurchaseForm_purchaseForms_PurchaseFormsPur~",
                        column: x => x.PurchaseFormsPurchaseFormId,
                        principalTable: "purchaseForms",
                        principalColumn: "PurchaseFormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approvers_PositionId",
                table: "Approvers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchandisePricePurchaseForm_PurchaseFormsPurchaseFormId",
                table: "MerchandisePricePurchaseForm",
                column: "PurchaseFormsPurchaseFormId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchandisePrices_MerchandiseId",
                table: "MerchandisePrices",
                column: "MerchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchandisePurchaseForm_PurchasedMerchandisesMerchandiseId",
                table: "MerchandisePurchaseForm",
                column: "PurchasedMerchandisesMerchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchandises_MeasurementUnitId",
                table: "Merchandises",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseForms_ApprovingOfficerId",
                table: "purchaseForms",
                column: "ApprovingOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseForms_FormKeyId",
                table: "purchaseForms",
                column: "FormKeyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchaseForms_ProcurementSpecialistId",
                table: "purchaseForms",
                column: "ProcurementSpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseForms_SalesmanId",
                table: "purchaseForms",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseForms_SponsorOrganizationId",
                table: "purchaseForms",
                column: "SponsorOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_ApproverId",
                table: "Signatures",
                column: "ApproverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchandisePricePurchaseForm");

            migrationBuilder.DropTable(
                name: "MerchandisePurchaseForm");

            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "MerchandisePrices");

            migrationBuilder.DropTable(
                name: "purchaseForms");

            migrationBuilder.DropTable(
                name: "Merchandises");

            migrationBuilder.DropTable(
                name: "Approvers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "FormKeys");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "MeasurementUnits");

            migrationBuilder.DropTable(
                name: "EmployeePositions");
        }
    }
}
