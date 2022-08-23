﻿// <auto-generated />
using System;
using AuditSeverityModule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuditSeverityModule.Migrations
{
    [DbContext(typeof(AuditSeverityContext))]
    partial class AuditSeverityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuditSeverityModule.Models.AuditBenchmark", b =>
                {
                    b.Property<int>("AuditBenchmarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("auditType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("benchmarkNoAnswers")
                        .HasColumnType("int");

                    b.HasKey("AuditBenchmarkId");

                    b.ToTable("AuditBenchmarks");
                });

            modelBuilder.Entity("AuditSeverityModule.Models.AuditDetail", b =>
                {
                    b.Property<int>("AuditDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditDetailId");

                    b.ToTable("AuditDetails");
                });

            modelBuilder.Entity("AuditSeverityModule.Models.AuditRequest", b =>
                {
                    b.Property<int>("AuditRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationOwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuditdetailsAuditDetailId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditRequestId");

                    b.HasIndex("AuditdetailsAuditDetailId");

                    b.ToTable("AuditRequests");
                });

            modelBuilder.Entity("AuditSeverityModule.Models.AuditResponse", b =>
                {
                    b.Property<int>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectExecutionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RemedialActionDuration")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditId");

                    b.ToTable("AuditResponses");
                });

            modelBuilder.Entity("AuditSeverityModule.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuditDetailId")
                        .HasColumnType("int");

                    b.Property<bool>("Question")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuditDetailId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("AuditSeverityModule.Models.AuditRequest", b =>
                {
                    b.HasOne("AuditSeverityModule.Models.AuditDetail", "Auditdetails")
                        .WithMany()
                        .HasForeignKey("AuditdetailsAuditDetailId");
                });

            modelBuilder.Entity("AuditSeverityModule.Models.Questions", b =>
                {
                    b.HasOne("AuditSeverityModule.Models.AuditDetail", null)
                        .WithMany("questions")
                        .HasForeignKey("AuditDetailId");
                });
#pragma warning restore 612, 618
        }
    }
}
