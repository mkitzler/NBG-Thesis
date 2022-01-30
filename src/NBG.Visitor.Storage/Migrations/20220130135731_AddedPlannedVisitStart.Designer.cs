﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBG.Visitor.Services.DB;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NBG.Visitor.Storage.Migrations
{
    [DbContext(typeof(VisitContext))]
    [Migration("20220130135731_AddedPlannedVisitStart")]
    partial class AddedPlannedVisitStart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("NBG.Visitor.Storage.Models.Visit", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CompanyLabel")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("company_label");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contact_person");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("PlannedVisitStart")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("planned_visit_start");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<DateTime?>("VisitEnd")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("visit_end");

                    b.Property<DateTime?>("VisitStart")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("visit_start");

                    b.Property<int>("visitor_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("visitor_id");

                    b.ToTable("visit");
                });

            modelBuilder.Entity("NBG.Visitor.Storage.Models.Visitor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.ToTable("visitor");
                });

            modelBuilder.Entity("NBG.Visitor.Storage.Models.Visit", b =>
                {
                    b.HasOne("NBG.Visitor.Storage.Models.Visitor", "Visitor")
                        .WithMany("Visits")
                        .HasForeignKey("visitor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("NBG.Visitor.Storage.Models.Visitor", b =>
                {
                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}
