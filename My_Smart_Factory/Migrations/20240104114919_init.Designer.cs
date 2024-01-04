﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My_Smart_Factory.Data;

#nullable disable

namespace My_Smart_Factory.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240104114919_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("ProviderKey", "LoginProvider");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("My_Smart_Factory.Models.CaseLotModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LotNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Unit")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CaseLotModels");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.FullInspRecordModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FullInspectionNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FullInspRecordModels");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.Insp.InspEquipModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("InspEquipName")
                        .HasColumnType("longtext");

                    b.Property<string>("Unit")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("InspEquipModels");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.Insp.InspEquipSettingRecordModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal?>("Accuracy")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("FullInspRecordModelId")
                        .HasColumnType("int");

                    b.Property<decimal?>("IES")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("InspEquipId")
                        .HasColumnType("int");

                    b.Property<int?>("InspSpecId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InspectionDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("FullInspRecordModelId");

                    b.HasIndex("InspEquipId");

                    b.HasIndex("InspSpecId");

                    b.ToTable("InspEquipSettingRecordModels");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.Insp.InspProdRecordModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal?>("Accuracy")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("FullInspRecordModelId")
                        .HasColumnType("int");

                    b.Property<int?>("InspSpecId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InspectionDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsPassed")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal?>("MeasuredValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("ProdCtrlNoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FullInspRecordModelId");

                    b.HasIndex("InspSpecId");

                    b.HasIndex("ProdCtrlNoId");

                    b.ToTable("InspProdRecordModels");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.Insp.InspSpecModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ETR")
                        .HasColumnType("int");

                    b.Property<int?>("InspEquipId")
                        .HasColumnType("int");

                    b.Property<string>("InspSpecName")
                        .HasColumnType("longtext");

                    b.Property<int?>("ProdInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InspEquipId");

                    b.HasIndex("ProdInfoId");

                    b.ToTable("InspSpecModels");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.OutgoingInspModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BubbleDefect")
                        .HasColumnType("int");

                    b.Property<int>("CapacityDefect")
                        .HasColumnType("int");

                    b.Property<int>("CaseDefect")
                        .HasColumnType("int");

                    b.Property<int>("CenterDefect")
                        .HasColumnType("int");

                    b.Property<string>("ConfirmorId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Controlnumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EpoxyDefect")
                        .HasColumnType("int");

                    b.Property<int>("EtcDefect")
                        .HasColumnType("int");

                    b.Property<string>("EtcInfo")
                        .HasColumnType("longtext");

                    b.Property<int>("InnerDiameterDefect")
                        .HasColumnType("int");

                    b.Property<int>("InspectionResult")
                        .HasColumnType("int");

                    b.Property<DateTime>("InspectionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InspectorId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("LossDefect")
                        .HasColumnType("int");

                    b.Property<int>("MarkDefect")
                        .HasColumnType("int");

                    b.Property<string>("ProcessName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ConfirmorId");

                    b.HasIndex("InspectorId");

                    b.ToTable("OutgoingInspModels");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.ProcessStatusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DefectiveQuantity")
                        .HasColumnType("int");

                    b.Property<string>("OperatorId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ProdInfoModelId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperatorId");

                    b.HasIndex("ProdInfoModelId");

                    b.ToTable("ProcessStatusModels");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.Prod.ProdCtrlNoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProdCtrlNo")
                        .HasColumnType("longtext");

                    b.Property<int?>("ProdInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdInfoId");

                    b.ToTable("ProdCtrlNoModels");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.Prod.ProdInfoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProdCode")
                        .HasColumnType("longtext");

                    b.Property<string>("ProdName")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("ProdWeight")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("ProdInfoModels");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.UserIdentity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("My_Smart_Factory.Models.WorkOrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CurrentWorkQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("ProdInfoId")
                        .HasColumnType("int");

                    b.Property<string>("QRURL")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("WorkOrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("WorkOrderIssuerId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("WorkOrderNumber")
                        .HasColumnType("longtext");

                    b.Property<int?>("WorkQuantity")
                        .HasColumnType("int");

                    b.Property<string>("WorkStatus")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProdInfoId");

                    b.HasIndex("WorkOrderIssuerId");

                    b.ToTable("WorkOrderModels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("My_Smart_Factory.Models.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("My_Smart_Factory.Models.FullInspRecordModel", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.WorkOrderModel", "WorkOrder")
                        .WithOne("FullInspection")
                        .HasForeignKey("My_Smart_Factory.Models.FullInspRecordModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkOrder");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.Insp.InspEquipSettingRecordModel", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.FullInspRecordModel", null)
                        .WithMany("InspEquipSettingRecords")
                        .HasForeignKey("FullInspRecordModelId");

                    b.HasOne("My_Smart_Factory.Models.Insp.InspEquipModel", "InspEquip")
                        .WithMany()
                        .HasForeignKey("InspEquipId");

                    b.HasOne("My_Smart_Factory.Models.Insp.InspSpecModel", "InspSpec")
                        .WithMany()
                        .HasForeignKey("InspSpecId");

                    b.Navigation("InspEquip");

                    b.Navigation("InspSpec");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.Insp.InspProdRecordModel", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.FullInspRecordModel", null)
                        .WithMany("InspProdRecords")
                        .HasForeignKey("FullInspRecordModelId");

                    b.HasOne("My_Smart_Factory.Models.Insp.InspSpecModel", "InspSpec")
                        .WithMany()
                        .HasForeignKey("InspSpecId");

                    b.HasOne("My_Smart_Factory.Models.Prod.ProdCtrlNoModel", "ProdCtrlNo")
                        .WithMany()
                        .HasForeignKey("ProdCtrlNoId");

                    b.Navigation("InspSpec");

                    b.Navigation("ProdCtrlNo");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.Insp.InspSpecModel", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.Insp.InspEquipModel", "InspEquip")
                        .WithMany()
                        .HasForeignKey("InspEquipId");

                    b.HasOne("My_Smart_Factory.Models.Prod.ProdInfoModel", "ProdInfo")
                        .WithMany()
                        .HasForeignKey("ProdInfoId");

                    b.Navigation("InspEquip");

                    b.Navigation("ProdInfo");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.OutgoingInspModel", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.UserIdentity", "Confirmor")
                        .WithMany()
                        .HasForeignKey("ConfirmorId");

                    b.HasOne("My_Smart_Factory.Models.UserIdentity", "Inspector")
                        .WithMany()
                        .HasForeignKey("InspectorId");

                    b.Navigation("Confirmor");

                    b.Navigation("Inspector");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.ProcessStatusModel", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.UserIdentity", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId");

                    b.HasOne("My_Smart_Factory.Models.Prod.ProdInfoModel", "ProdInfoModel")
                        .WithMany()
                        .HasForeignKey("ProdInfoModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operator");

                    b.Navigation("ProdInfoModel");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.Prod.ProdCtrlNoModel", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.Prod.ProdInfoModel", "ProdInfo")
                        .WithMany()
                        .HasForeignKey("ProdInfoId");

                    b.Navigation("ProdInfo");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.WorkOrderModel", b =>
                {
                    b.HasOne("My_Smart_Factory.Models.Prod.ProdInfoModel", "ProdInfo")
                        .WithMany()
                        .HasForeignKey("ProdInfoId");

                    b.HasOne("My_Smart_Factory.Models.UserIdentity", "WorkOrderIssuer")
                        .WithMany()
                        .HasForeignKey("WorkOrderIssuerId");

                    b.Navigation("ProdInfo");

                    b.Navigation("WorkOrderIssuer");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.FullInspRecordModel", b =>
                {
                    b.Navigation("InspEquipSettingRecords");

                    b.Navigation("InspProdRecords");
                });

            modelBuilder.Entity("My_Smart_Factory.Models.WorkOrderModel", b =>
                {
                    b.Navigation("FullInspection");
                });
#pragma warning restore 612, 618
        }
    }
}