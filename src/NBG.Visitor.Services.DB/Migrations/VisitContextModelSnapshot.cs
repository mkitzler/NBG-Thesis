﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBG.Visitor.Services.DB;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NBG.Visitor.Services.DB.Migrations
{
    [DbContext(typeof(VisitContext))]
    partial class VisitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("NBG.Visitor.Services.DB.Models.Company", b =>
                {
                    b.Property<string>("CompanyLabel")
                        .HasColumnType("text");

                    b.HasKey("CompanyLabel");

                    b.HasIndex("CompanyLabel")
                        .IsUnique();

                    b.ToTable("Company");
                });

            modelBuilder.Entity("NBG.Visitor.Services.DB.Models.ContactPerson", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ContactPerson");
                });

            modelBuilder.Entity("NBG.Visitor.Services.DB.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CompanyLabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactPersonName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("VisitEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("VisitStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("VisitorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyLabel");

                    b.HasIndex("ContactPersonName");

                    b.HasIndex("VisitorId");

                    b.ToTable("Visit");
                });

            modelBuilder.Entity("NBG.Visitor.Services.DB.Models.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Visitor");
                });

            modelBuilder.Entity("NBG.Visitor.Services.DB.Models.Visit", b =>
                {
                    b.HasOne("NBG.Visitor.Services.DB.Models.Company", "Company")
                        .WithMany("Visits")
                        .HasForeignKey("CompanyLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NBG.Visitor.Services.DB.Models.ContactPerson", "ContactPerson")
                        .WithMany("Visits")
                        .HasForeignKey("ContactPersonName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NBG.Visitor.Services.DB.Models.Visitor", "Visitor")
                        .WithMany("Visits")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("ContactPerson");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("NBG.Visitor.Services.DB.Models.Company", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("NBG.Visitor.Services.DB.Models.ContactPerson", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("NBG.Visitor.Services.DB.Models.Visitor", b =>
                {
                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}
