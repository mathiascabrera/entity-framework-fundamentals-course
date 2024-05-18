﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project_ef;

#nullable disable

namespace project_EF.Migrations
{
    [DbContext(typeof(TasksContext))]
    [Migration("20240518142124_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("project_ef.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EffortLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("d8d1e903-0c79-4e92-9fc1-df471bd2882d"),
                            EffortLevel = 20,
                            Name = "Pending activities"
                        },
                        new
                        {
                            CategoryId = new Guid("a803e17f-b1e9-4e69-a426-0ae1a5ba0dc3"),
                            EffortLevel = 50,
                            Name = "Personal activities"
                        });
                });

            modelBuilder.Entity("project_ef.Models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriorityTask")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeLimit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("04799f58-7631-4371-aa78-41f7e06f758f"),
                            CategoryId = new Guid("d8d1e903-0c79-4e92-9fc1-df471bd2882d"),
                            CreationDate = new DateTime(2024, 5, 18, 11, 21, 24, 421, DateTimeKind.Local).AddTicks(6795),
                            PriorityTask = 1,
                            TimeLimit = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Payment of public services"
                        },
                        new
                        {
                            TaskId = new Guid("986cf55a-4c1d-477f-8719-3acf5695f8ce"),
                            CategoryId = new Guid("a803e17f-b1e9-4e69-a426-0ae1a5ba0dc3"),
                            CreationDate = new DateTime(2024, 5, 18, 11, 21, 24, 421, DateTimeKind.Local).AddTicks(6812),
                            PriorityTask = 0,
                            TimeLimit = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Finish watching the movie on netflix"
                        });
                });

            modelBuilder.Entity("project_ef.Models.Task", b =>
                {
                    b.HasOne("project_ef.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("project_ef.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
