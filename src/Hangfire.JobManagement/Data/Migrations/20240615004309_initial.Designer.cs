﻿// <auto-generated />
using System;
using Hangfire.JobManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hangfire.JobManagement.Data.Migrations
{
    [DbContext(typeof(JobManagementDbContext))]
    [Migration("20240615004309_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hangfire.JobManagement.Data.Entities.Batch", b =>
                {
                    b.Property<long>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BatchId"));

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("BatchId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("Hangfire.JobManagement.Data.Entities.BatchOperation", b =>
                {
                    b.Property<long>("BatchOperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BatchOperationId"));

                    b.Property<long?>("BatchId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("BatchOperationId");

                    b.HasIndex("BatchId");

                    b.ToTable("BatchOperation");
                });

            modelBuilder.Entity("Hangfire.JobManagement.Data.Entities.GlobalSettings", b =>
                {
                    b.Property<long>("GlobalSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GlobalSettingId"));

                    b.Property<string>("DefaultQueue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultTimeZoneId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GlobalSettingId");

                    b.ToTable("GlobalSettings");
                });

            modelBuilder.Entity("Hangfire.JobManagement.Data.Entities.JobHistory", b =>
                {
                    b.Property<long>("JobHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("JobHistoryId"));

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("JobHistoryId");

                    b.ToTable("JobHistory");
                });

            modelBuilder.Entity("Hangfire.JobManagement.Data.Entities.Notification", b =>
                {
                    b.Property<long>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("NotificationId"));

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Hangfire.JobManagement.Data.Entities.NotificationGroup", b =>
                {
                    b.Property<long>("NotificationGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("NotificationGroupId"));

                    b.HasKey("NotificationGroupId");

                    b.ToTable("NotificationGroups");
                });

            modelBuilder.Entity("Hangfire.JobManagement.Data.Entities.NotificationTypes", b =>
                {
                    b.Property<long?>("NotificationTypesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("NotificationTypesId"));

                    b.HasKey("NotificationTypesId");

                    b.ToTable("NotificationTypes");
                });

            modelBuilder.Entity("Hangfire.JobManagement.Data.Entities.Setting", b =>
                {
                    b.Property<long>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SettingId"));

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SettingId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Hangfire.JobManagement.Data.Entities.BatchOperation", b =>
                {
                    b.HasOne("Hangfire.JobManagement.Data.Entities.Batch", null)
                        .WithMany("BatchOperations")
                        .HasForeignKey("BatchId");
                });

            modelBuilder.Entity("Hangfire.JobManagement.Data.Entities.Batch", b =>
                {
                    b.Navigation("BatchOperations");
                });
#pragma warning restore 612, 618
        }
    }
}
