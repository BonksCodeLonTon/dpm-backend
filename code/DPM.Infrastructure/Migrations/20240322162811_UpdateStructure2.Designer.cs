﻿// <auto-generated />
using System;
using DPM.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DPM.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240322162811_UpdateStructure2")]
    partial class UpdateStructure2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DPM.Domain.Entities.Crew", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasDefaultValueSql("generate_id()");

                    b.Property<string>("Countries")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("countries");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<string>("Fullname")
                        .HasColumnType("text")
                        .HasColumnName("fullname");

                    b.Property<string>("NationalId")
                        .HasColumnType("text")
                        .HasColumnName("national_id");

                    b.Property<string>("RegisterToArrivalArrivalId")
                        .HasColumnType("varchar(128)")
                        .HasColumnName("register_to_arrival_arrival_id");

                    b.Property<string>("RegisterToDepartureDepartureId")
                        .HasColumnType("varchar(128)")
                        .HasColumnName("register_to_departure_departure_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("YearExperience")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("year_experience");

                    b.HasKey("Id")
                        .HasName("pk_crew");

                    b.HasIndex("CreatedBy")
                        .HasDatabaseName("ix_crew_created_by");

                    b.HasIndex("RegisterToArrivalArrivalId")
                        .HasDatabaseName("ix_crew_register_to_arrival_arrival_id");

                    b.HasIndex("RegisterToDepartureDepartureId")
                        .HasDatabaseName("ix_crew_register_to_departure_departure_id");

                    b.HasIndex("UpdatedBy")
                        .HasDatabaseName("ix_crew_updated_by");

                    b.ToTable("crew", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.CrewTrip", b =>
                {
                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long>("CrewId")
                        .HasColumnType("bigint")
                        .HasColumnName("crew_id");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("TripId")
                        .HasColumnType("varchar(128)")
                        .HasColumnName("trip_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasIndex("CrewId")
                        .HasDatabaseName("ix_crew_trip_crew_id");

                    b.HasIndex("TripId")
                        .IsUnique()
                        .HasDatabaseName("ix_crew_trip_trip_id");

                    b.ToTable("crew_trip", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.Port", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasDefaultValueSql("generate_id()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_port");

                    b.HasIndex("CreatedBy")
                        .HasDatabaseName("ix_port_created_by");

                    b.HasIndex("UpdatedBy")
                        .HasDatabaseName("ix_port_updated_by");

                    b.ToTable("port", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.RegisterToArrival", b =>
                {
                    b.Property<string>("ArrivalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("arrival_id")
                        .HasDefaultValueSql("generate_arrival_id()");

                    b.Property<DateTime>("ActualArrivalTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("actual_arrival_time");

                    b.Property<int>("ApproveStatus")
                        .HasColumnType("integer")
                        .HasColumnName("approve_status");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("arrival_time");

                    b.Property<string>("Attachment")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("attachment");

                    b.Property<long>("CaptainId")
                        .HasColumnType("bigint")
                        .HasColumnName("captain_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<bool>("IsStart")
                        .HasColumnType("boolean")
                        .HasColumnName("is_start");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("note");

                    b.Property<long>("PortId")
                        .HasColumnType("bigint")
                        .HasColumnName("port_id");

                    b.Property<long>("ShipId")
                        .HasColumnType("bigint")
                        .HasColumnName("ship_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("ArrivalId")
                        .HasName("pk_register_to_arrival");

                    b.HasIndex("CaptainId")
                        .HasDatabaseName("ix_register_to_arrival_captain_id");

                    b.HasIndex("CreatedBy")
                        .HasDatabaseName("ix_register_to_arrival_created_by");

                    b.HasIndex("PortId")
                        .HasDatabaseName("ix_register_to_arrival_port_id");

                    b.HasIndex("ShipId")
                        .HasDatabaseName("ix_register_to_arrival_ship_id");

                    b.HasIndex("UpdatedBy")
                        .HasDatabaseName("ix_register_to_arrival_updated_by");

                    b.ToTable("register_to_arrival", (string)null);
                });

            modelBuilder.Entity("DPM.Domain.Entities.RegisterToDeparture", b =>
                {
                    b.Property<string>("DepartureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("departure_id")
                        .HasDefaultValueSql("generate_departure_id()");

                    b.Property<DateTime>("ActualDepartureTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("actual_departure_time");

                    b.Property<int>("ApproveStatus")
                        .HasColumnType("integer")
                        .HasColumnName("approve_status");

                    b.Property<string>("Attachment")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("attachment");

                    b.Property<long>("CaptainId")
                        .HasColumnType("bigint")
                        .HasColumnName("captain_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<long[]>("CrewId")
                        .HasColumnType("bigint[]")
                        .HasColumnName("crew_id");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("departure_time");

                    b.Property<DateTime>("GuessTimeArrival")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("guess_time_arrival");

                    b.Property<bool>("IsStart")
                        .HasColumnType("boolean")
                        .HasColumnName("is_start");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("note");

                    b.Property<long>("PortId")
                        .HasColumnType("bigint")
                        .HasColumnName("port_id");

                    b.Property<long>("ShipId")
                        .HasColumnType("bigint")
                        .HasColumnName("ship_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.HasKey("DepartureId")
                        .HasName("pk_register_to_departure");

                    b.HasIndex("CaptainId")
                        .HasDatabaseName("ix_register_to_departure_captain_id");

                    b.HasIndex("CreatedBy")
                        .HasDatabaseName("ix_register_to_departure_created_by");

                    b.HasIndex("PortId")
                        .HasDatabaseName("ix_register_to_departure_port_id");

                    b.HasIndex("ShipId")
                        .HasDatabaseName("ix_register_to_departure_ship_id");

                    b.HasIndex("UpdatedBy")
                        .HasDatabaseName("ix_register_to_departure_updated_by");

                    b.ToTable("register_to_departure", (string)null);
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

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("length");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("name");

                    b.Property<long?>("OwnerId")
                        .HasColumnType("bigint")
                        .HasColumnName("owner_id");

                    b.Property<long[]>("Position")
                        .HasColumnType("bigint[]")
                        .HasColumnName("array");

                    b.Property<string>("RegisterNumber")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("register_number");

                    b.Property<string>("ShipStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(16)")
                        .HasDefaultValue("Docked")
                        .HasColumnName("ship_status");

                    b.Property<string>("ShipType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(16)")
                        .HasDefaultValue("Other")
                        .HasColumnName("ship_type");

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

            modelBuilder.Entity("DPM.Domain.Entities.ShipCertificate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasDefaultValueSql("generate_id()");

                    b.Property<string>("CertificateName")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("certificate_name");

                    b.Property<string>("CertificateNo")
                        .IsRequired()
                        .HasColumnType("text")
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

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint")
                        .HasColumnName("creator_id");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiry_date");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("issue_date");

                    b.Property<long?>("ShipId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("ship_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<long?>("UpdaterId")
                        .HasColumnType("bigint")
                        .HasColumnName("updater_id");

                    b.HasKey("Id")
                        .HasName("pk_ship_certificate");

                    b.HasIndex("CertificateName")
                        .IsUnique()
                        .HasDatabaseName("ix_ship_certificate_certificate_name");

                    b.HasIndex("CertificateNo")
                        .IsUnique()
                        .HasDatabaseName("ix_ship_certificate_certificate_no");

                    b.HasIndex("CreatorId")
                        .HasDatabaseName("ix_ship_certificate_creator_id");

                    b.HasIndex("ShipId")
                        .IsUnique()
                        .HasDatabaseName("ix_ship_certificate_ship_id");

                    b.HasIndex("UpdaterId")
                        .HasDatabaseName("ix_ship_certificate_updater_id");

                    b.ToTable("ship_certificate", (string)null);
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

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(16)")
                        .HasDefaultValue("None")
                        .HasColumnName("role");

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

            modelBuilder.Entity("DPM.Domain.Entities.Crew", b =>
                {
                    b.HasOne("DPM.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_crew_users_creator_id");

                    b.HasOne("DPM.Domain.Entities.RegisterToArrival", null)
                        .WithMany("Crews")
                        .HasForeignKey("RegisterToArrivalArrivalId")
                        .HasConstraintName("fk_crew_register_to_arrival_register_to_arrival_temp_id1");

                    b.HasOne("DPM.Domain.Entities.RegisterToDeparture", null)
                        .WithMany("Crews")
                        .HasForeignKey("RegisterToDepartureDepartureId")
                        .HasConstraintName("fk_crew_register_to_departure_register_to_departure_temp_id1");

                    b.HasOne("DPM.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_crew_users_updater_id");

                    b.Navigation("Creator");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("DPM.Domain.Entities.CrewTrip", b =>
                {
                    b.HasOne("DPM.Domain.Entities.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_crew_trip_crew_crew_id");

                    b.HasOne("DPM.Domain.Entities.RegisterToArrival", "RegisterToArrival")
                        .WithOne()
                        .HasForeignKey("DPM.Domain.Entities.CrewTrip", "TripId")
                        .HasConstraintName("fk_crew_trip_register_to_arrival_register_to_arrival_id");

                    b.HasOne("DPM.Domain.Entities.RegisterToDeparture", "RegisterToDeparture")
                        .WithOne()
                        .HasForeignKey("DPM.Domain.Entities.CrewTrip", "TripId")
                        .HasConstraintName("fk_crew_trip_register_to_departure_register_to_departure_id");

                    b.Navigation("Crew");

                    b.Navigation("RegisterToArrival");

                    b.Navigation("RegisterToDeparture");
                });

            modelBuilder.Entity("DPM.Domain.Entities.Port", b =>
                {
                    b.HasOne("DPM.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_port_users_creator_id");

                    b.HasOne("DPM.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_port_users_updater_id");

                    b.Navigation("Creator");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("DPM.Domain.Entities.RegisterToArrival", b =>
                {
                    b.HasOne("DPM.Domain.Entities.User", "Captain")
                        .WithMany()
                        .HasForeignKey("CaptainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_register_to_arrival_users_captain_id");

                    b.HasOne("DPM.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired()
                        .HasConstraintName("fk_register_to_arrival_users_creator_id");

                    b.HasOne("DPM.Domain.Entities.Port", "Port")
                        .WithMany()
                        .HasForeignKey("PortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_register_to_arrival_port_port_id");

                    b.HasOne("DPM.Domain.Entities.Ship", "Ship")
                        .WithMany()
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_register_to_arrival_ships_ship_id");

                    b.HasOne("DPM.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_register_to_arrival_users_updater_id");

                    b.Navigation("Captain");

                    b.Navigation("Creator");

                    b.Navigation("Port");

                    b.Navigation("Ship");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("DPM.Domain.Entities.RegisterToDeparture", b =>
                {
                    b.HasOne("DPM.Domain.Entities.User", "Captain")
                        .WithMany()
                        .HasForeignKey("CaptainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_register_to_departure_users_captain_id");

                    b.HasOne("DPM.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired()
                        .HasConstraintName("fk_register_to_departure_users_creator_id");

                    b.HasOne("DPM.Domain.Entities.Port", "Port")
                        .WithMany()
                        .HasForeignKey("PortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_register_to_departure_port_port_id");

                    b.HasOne("DPM.Domain.Entities.Ship", "Ship")
                        .WithMany()
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_register_to_departure_ships_ship_id");

                    b.HasOne("DPM.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_register_to_departure_users_updater_id");

                    b.Navigation("Captain");

                    b.Navigation("Creator");

                    b.Navigation("Port");

                    b.Navigation("Ship");

                    b.Navigation("Updater");
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

            modelBuilder.Entity("DPM.Domain.Entities.ShipCertificate", b =>
                {
                    b.HasOne("DPM.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .HasConstraintName("fk_ship_certificate_users_creator_id");

                    b.HasOne("DPM.Domain.Entities.Ship", "Ship")
                        .WithOne()
                        .HasForeignKey("DPM.Domain.Entities.ShipCertificate", "ShipId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_ship_certificate_ships_ship_id");

                    b.HasOne("DPM.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdaterId")
                        .HasConstraintName("fk_ship_certificate_users_updater_id");

                    b.Navigation("Creator");

                    b.Navigation("Ship");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("DPM.Domain.Entities.User", b =>
                {
                    b.HasOne("DPM.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_users_users_creator_id");

                    b.HasOne("DPM.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_users_users_updater_id");

                    b.Navigation("Creator");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("DPM.Domain.Entities.RegisterToArrival", b =>
                {
                    b.Navigation("Crews");
                });

            modelBuilder.Entity("DPM.Domain.Entities.RegisterToDeparture", b =>
                {
                    b.Navigation("Crews");
                });
#pragma warning restore 612, 618
        }
    }
}
