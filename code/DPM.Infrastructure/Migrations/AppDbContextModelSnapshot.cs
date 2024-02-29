﻿// <auto-generated />
using System;
using System.Collections.Generic;
using DPM.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DPM.Domain.Entities.AppRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasDefaultValueSql("generate_id()");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("role_name");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.CertificateShip", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasDefaultValueSql("generate_id()");

                    b.Property<string>("CertificateName")
                        .HasColumnType("text")
                        .HasColumnName("certificate_name");

                    b.Property<Guid>("CertificateNo")
                        .HasColumnType("uuid")
                        .HasColumnName("certificate_no");

                    b.Property<string>("CertificateStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(64)")
                        .HasDefaultValue("None")
                        .HasColumnName("certificate_status");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiry_date");

                    b.Property<long>("FishingTripId")
                        .HasColumnType("bigint")
                        .HasColumnName("fishing_trip_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsMilitaryAuthority")
                        .HasColumnType("boolean")
                        .HasColumnName("is_military_authority");

                    b.Property<bool>("IsPortAuthority")
                        .HasColumnType("boolean")
                        .HasColumnName("is_port_authority");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("issue_date");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_certificate_ships");

                    b.HasIndex("FishingTripId")
                        .HasDatabaseName("ix_certificate_ships_fishing_trip_id");

                    b.ToTable("certificate_ships", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.CertificateShipHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CertificateShipId")
                        .HasColumnType("bigint")
                        .HasColumnName("certificate_ship_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_certificate_ship_histories");

                    b.HasIndex("CertificateShipId")
                        .HasDatabaseName("ix_certificate_ship_histories_certificate_ship_id");

                    b.HasIndex("CreatedBy")
                        .HasDatabaseName("ix_certificate_ship_histories_created_by");

                    b.HasIndex("UpdatedBy")
                        .HasDatabaseName("ix_certificate_ship_histories_updated_by");

                    b.ToTable("certificate_ship_histories", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.Fishermen", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasDefaultValueSql("generate_id()");

                    b.Property<long?>("FishingTripId")
                        .HasColumnType("bigint")
                        .HasColumnName("fishing_trip_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<long>("YearExperience")
                        .HasColumnType("bigint")
                        .HasColumnName("year_experience");

                    b.HasKey("Id")
                        .HasName("pk_fishermens");

                    b.HasIndex("FishingTripId")
                        .HasDatabaseName("ix_fishermens_fishing_trip_id");

                    b.ToTable("fishermens", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.FishingTrip", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<long>("ShipId")
                        .HasColumnType("bigint")
                        .HasColumnName("ship_id");

                    b.Property<string>("ShipStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(16)")
                        .HasDefaultValue("Idle")
                        .HasColumnName("ship_status");

                    b.Property<string>("TripStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(16)")
                        .HasDefaultValue("Undefined")
                        .HasColumnName("trip_status");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_fishing_trip");

                    b.HasIndex("CreatedBy")
                        .HasDatabaseName("ix_fishing_trip_created_by");

                    b.HasIndex("ShipId")
                        .HasDatabaseName("ix_fishing_trip_ship_id");

                    b.HasIndex("UpdatedBy")
                        .HasDatabaseName("ix_fishing_trip_updated_by");

                    b.ToTable("fishing_trip", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.FishingTripHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasDefaultValueSql("generate_id()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long>("FishermenId")
                        .HasColumnType("bigint")
                        .HasColumnName("fishermen_id");

                    b.Property<long>("FishingTripId")
                        .HasColumnType("bigint")
                        .HasColumnName("fishing_trip_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_fishing_trip_history");

                    b.HasIndex("FishermenId")
                        .HasDatabaseName("ix_fishing_trip_history_fishermen_id");

                    b.HasIndex("FishingTripId")
                        .IsUnique()
                        .HasDatabaseName("ix_fishing_trip_history_fishing_trip_id");

                    b.ToTable("fishing_trip_history", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.Map", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasDefaultValueSql("generate_id()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<List<long>>("Position")
                        .HasColumnType("bigint[]")
                        .HasColumnName("position");

                    b.Property<long>("ShipId")
                        .HasColumnType("bigint")
                        .HasColumnName("ship_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_map");

                    b.HasIndex("ShipId")
                        .IsUnique()
                        .HasDatabaseName("ix_map_ship_id");

                    b.ToTable("map", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.Ship", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasDefaultValueSql("generate_id()");

                    b.Property<string>("ClassNumber")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("class_number");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<string>("GrossTonnage")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("gross_tonnage");

                    b.Property<string>("IMONumber")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("imo_number");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean")
                        .HasColumnName("is_disabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("name");

                    b.Property<long?>("OwnerId")
                        .HasColumnType("bigint")
                        .HasColumnName("owner_id");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(16)")
                        .HasDefaultValue("None")
                        .HasColumnName("purpose");

                    b.Property<string>("RegisterNumber")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("register_number");

                    b.Property<string>("TotalPower")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("total_power");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_ships");

                    b.HasIndex("CreatedBy")
                        .HasDatabaseName("ix_ships_created_by");

                    b.HasIndex("IMONumber")
                        .IsUnique()
                        .HasDatabaseName("ix_ships_imo_number");

                    b.HasIndex("OwnerId")
                        .IsUnique()
                        .HasDatabaseName("ix_ships_owner_id");

                    b.HasIndex("UpdatedBy")
                        .HasDatabaseName("ix_ships_updated_by");

                    b.ToTable("ships", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasDefaultValueSql("generate_id()");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("address");

                    b.Property<string>("Avatar")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("avatar");

                    b.Property<string>("CognitoSub")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cognito_sub");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("full_name");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(8)")
                        .HasColumnName("gender");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsDisabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_disabled");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(16)")
                        .HasColumnName("phone_number");

                    b.Property<string>("RoleType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(16)")
                        .HasDefaultValue("User")
                        .HasColumnName("role_type");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("CognitoSub")
                        .IsUnique()
                        .HasDatabaseName("ix_users_cognito_sub");

                    b.HasIndex("CreatedBy")
                        .HasDatabaseName("ix_users_created_by");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("UpdatedBy")
                        .HasDatabaseName("ix_users_updated_by");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasDatabaseName("ix_users_username");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_userroles");

                    b.ToTable("userroles", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.CertificateShip", b =>
                {
                    b.HasOne("DPM.Domain.Entities.FishingTrip", "FishingTrip")
                        .WithMany()
                        .HasForeignKey("FishingTripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_certificate_ships_fishing_trip_fishing_trip_id");

                    b.Navigation("FishingTrip");
                });

            modelBuilder.Entity("DPM.Domain.Entities.CertificateShipHistory", b =>
                {
                    b.HasOne("DPM.Domain.Entities.CertificateShip", "CertificateShip")
                        .WithMany()
                        .HasForeignKey("CertificateShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_certificate_ship_histories_certificate_ships_certificate_sh");

                    b.HasOne("DPM.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_certificate_ship_histories_user_creator_id");

                    b.HasOne("DPM.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_certificate_ship_histories_user_updater_id");

                    b.Navigation("CertificateShip");

                    b.Navigation("Creator");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("DPM.Domain.Entities.Fishermen", b =>
                {
                    b.HasOne("DPM.Domain.Entities.FishingTrip", null)
                        .WithMany("Crews")
                        .HasForeignKey("FishingTripId")
                        .HasConstraintName("fk_fishermens_fishing_trip_fishing_trip_id");
                });

            modelBuilder.Entity("DPM.Domain.Entities.FishingTrip", b =>
                {
                    b.HasOne("DPM.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_fishing_trip_user_creator_id");

                    b.HasOne("DPM.Domain.Entities.FishingTripHistory", null)
                        .WithOne("FishingTrip")
                        .HasForeignKey("DPM.Domain.Entities.FishingTrip", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_fishing_trip_fishing_trip_history_id");

                    b.HasOne("DPM.Domain.Entities.Ship", "Ship")
                        .WithMany()
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_fishing_trip_ship_ship_id");

                    b.HasOne("DPM.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_fishing_trip_user_updater_id");

                    b.Navigation("Creator");

                    b.Navigation("Ship");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("DPM.Domain.Entities.FishingTripHistory", b =>
                {
                    b.HasOne("DPM.Domain.Entities.Fishermen", "Fishermen")
                        .WithMany()
                        .HasForeignKey("FishermenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_fishing_trip_history_fishermens_fishermen_id");

                    b.Navigation("Fishermen");
                });

            modelBuilder.Entity("DPM.Domain.Entities.Map", b =>
                {
                    b.HasOne("DPM.Domain.Entities.Ship", "Ship")
                        .WithOne()
                        .HasForeignKey("DPM.Domain.Entities.Map", "ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_map_ships_ship_id");

                    b.Navigation("Ship");
                });

            modelBuilder.Entity("DPM.Domain.Entities.Ship", b =>
                {
                    b.HasOne("DPM.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_ships_users_creator_id");

                    b.HasOne("DPM.Domain.Entities.User", "Owner")
                        .WithOne()
                        .HasForeignKey("DPM.Domain.Entities.Ship", "OwnerId")
                        .HasConstraintName("fk_ships_users_owner_id");

                    b.HasOne("DPM.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_ships_users_updater_id");

                    b.Navigation("Creator");

                    b.Navigation("Owner");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("DPM.Domain.Entities.User", b =>
                {
                    b.HasOne("DPM.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_users_users_creator_id");

                    b.HasOne("DPM.Domain.Entities.Fishermen", null)
                        .WithOne("User")
                        .HasForeignKey("DPM.Domain.Entities.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_fishermens_id");

                    b.HasOne("DPM.Domain.Entities.UserRole", null)
                        .WithOne("User")
                        .HasForeignKey("DPM.Domain.Entities.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_userroles_id");

                    b.HasOne("DPM.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_users_users_updater_id");

                    b.Navigation("Creator");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("DPM.Domain.Entities.Fishermen", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("DPM.Domain.Entities.FishingTrip", b =>
                {
                    b.Navigation("Crews");
                });

            modelBuilder.Entity("DPM.Domain.Entities.FishingTripHistory", b =>
                {
                    b.Navigation("FishingTrip");
                });

            modelBuilder.Entity("DPM.Domain.Entities.UserRole", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
