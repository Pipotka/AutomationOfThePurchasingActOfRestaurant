﻿// <auto-generated />
using System;
using AutomationOfThePurchasingActOfRestaurant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomationOfThePurchasingActOfRestaurant.Migrations
{
    [DbContext(typeof(PurchasingDbContext))]
    [Migration("20240819151606_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Approver", b =>
                {
                    b.Property<Guid>("ApproverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uuid");

                    b.HasKey("ApproverId");

                    b.HasIndex("PositionId");

                    b.ToTable("Approvers");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uuid");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.EmployeePosition", b =>
                {
                    b.Property<Guid>("EmployeePositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EmployeePositionId");

                    b.ToTable("EmployeePositions");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.FormKey", b =>
                {
                    b.Property<Guid>("FormKeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("OKDP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OKPO")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OKUD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PurchaseFormId")
                        .HasColumnType("uuid");

                    b.Property<string>("TIN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FormKeyId");

                    b.ToTable("FormKeys");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.MeasurementUnit", b =>
                {
                    b.Property<Guid>("MeasurementUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("OKEIKey")
                        .HasColumnType("smallint");

                    b.HasKey("MeasurementUnitId");

                    b.ToTable("MeasurementUnits");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Merchandise", b =>
                {
                    b.Property<Guid>("MerchandiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<Guid>("MeasurementUnitId")
                        .HasColumnType("uuid");

                    b.Property<int>("MerchandiseKey")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MerchandiseId");

                    b.HasIndex("MeasurementUnitId");

                    b.ToTable("Merchandises");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.MerchandisePrice", b =>
                {
                    b.Property<Guid>("MerchandisePriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("CostPerUnit")
                        .HasColumnType("double precision");

                    b.Property<Guid>("MerchandiseId")
                        .HasColumnType("uuid");

                    b.HasKey("MerchandisePriceId");

                    b.HasIndex("MerchandiseId");

                    b.ToTable("MerchandisePrices");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Organization", b =>
                {
                    b.Property<Guid>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StructuralUnit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.PurchaseForm", b =>
                {
                    b.Property<Guid>("PurchaseFormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddressOfPurchase")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ApprovingOfficerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("integer");

                    b.Property<Guid>("FormKeyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProcurementSpecialistId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SalesmanId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SponsorOrganizationId")
                        .HasColumnType("uuid");

                    b.HasKey("PurchaseFormId");

                    b.HasIndex("ApprovingOfficerId");

                    b.HasIndex("FormKeyId")
                        .IsUnique();

                    b.HasIndex("ProcurementSpecialistId");

                    b.HasIndex("SalesmanId");

                    b.HasIndex("SponsorOrganizationId");

                    b.ToTable("purchaseForms");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Signature", b =>
                {
                    b.Property<Guid>("SignatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ApproverId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsObsolete")
                        .HasColumnType("boolean");

                    b.Property<string>("Points")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SignatureDecryption")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SignatureId");

                    b.HasIndex("ApproverId");

                    b.ToTable("Signatures");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Supplier", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("MerchandisePricePurchaseForm", b =>
                {
                    b.Property<Guid>("PricesMerchandisePriceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PurchaseFormsPurchaseFormId")
                        .HasColumnType("uuid");

                    b.HasKey("PricesMerchandisePriceId", "PurchaseFormsPurchaseFormId");

                    b.HasIndex("PurchaseFormsPurchaseFormId");

                    b.ToTable("MerchandisePricePurchaseForm");
                });

            modelBuilder.Entity("MerchandisePurchaseForm", b =>
                {
                    b.Property<Guid>("PurchaseFormsPurchaseFormId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PurchasedMerchandisesMerchandiseId")
                        .HasColumnType("uuid");

                    b.HasKey("PurchaseFormsPurchaseFormId", "PurchasedMerchandisesMerchandiseId");

                    b.HasIndex("PurchasedMerchandisesMerchandiseId");

                    b.ToTable("MerchandisePurchaseForm");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Approver", b =>
                {
                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.EmployeePosition", "Position")
                        .WithMany("Approvers")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Employee", b =>
                {
                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.EmployeePosition", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Merchandise", b =>
                {
                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.MeasurementUnit", "MeasurementUnit")
                        .WithMany("Merchandises")
                        .HasForeignKey("MeasurementUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeasurementUnit");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.MerchandisePrice", b =>
                {
                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.Merchandise", "Merchandise")
                        .WithMany("Prices")
                        .HasForeignKey("MerchandiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchandise");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.PurchaseForm", b =>
                {
                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.Approver", "ApprovingOfficer")
                        .WithMany("PurchaseForms")
                        .HasForeignKey("ApprovingOfficerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.FormKey", "FormKey")
                        .WithOne("PurchaseForm")
                        .HasForeignKey("AutomationOfThePurchasingActOfRestaurant.Models.PurchaseForm", "FormKeyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.Employee", "ProcurementSpecialist")
                        .WithMany("PurchaseForms")
                        .HasForeignKey("ProcurementSpecialistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.Supplier", "Salesman")
                        .WithMany("PurchaseForms")
                        .HasForeignKey("SalesmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.Organization", "SponsorOrganization")
                        .WithMany("PurchaseForms")
                        .HasForeignKey("SponsorOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovingOfficer");

                    b.Navigation("FormKey");

                    b.Navigation("ProcurementSpecialist");

                    b.Navigation("Salesman");

                    b.Navigation("SponsorOrganization");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Signature", b =>
                {
                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.Approver", "Approver")
                        .WithMany("Signatures")
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");
                });

            modelBuilder.Entity("MerchandisePricePurchaseForm", b =>
                {
                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.MerchandisePrice", null)
                        .WithMany()
                        .HasForeignKey("PricesMerchandisePriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.PurchaseForm", null)
                        .WithMany()
                        .HasForeignKey("PurchaseFormsPurchaseFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MerchandisePurchaseForm", b =>
                {
                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.PurchaseForm", null)
                        .WithMany()
                        .HasForeignKey("PurchaseFormsPurchaseFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomationOfThePurchasingActOfRestaurant.Models.Merchandise", null)
                        .WithMany()
                        .HasForeignKey("PurchasedMerchandisesMerchandiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Approver", b =>
                {
                    b.Navigation("PurchaseForms");

                    b.Navigation("Signatures");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Employee", b =>
                {
                    b.Navigation("PurchaseForms");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.EmployeePosition", b =>
                {
                    b.Navigation("Approvers");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.FormKey", b =>
                {
                    b.Navigation("PurchaseForm")
                        .IsRequired();
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.MeasurementUnit", b =>
                {
                    b.Navigation("Merchandises");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Merchandise", b =>
                {
                    b.Navigation("Prices");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Organization", b =>
                {
                    b.Navigation("PurchaseForms");
                });

            modelBuilder.Entity("AutomationOfThePurchasingActOfRestaurant.Models.Supplier", b =>
                {
                    b.Navigation("PurchaseForms");
                });
#pragma warning restore 612, 618
        }
    }
}
