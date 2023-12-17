﻿// <auto-generated />
using System;
using Case_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Case_Management_System.Migrations
{
    [DbContext(typeof(CmsContext))]
    [Migration("20230711194518_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Case_Management_System.Models.CaseHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LawyerId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LawyerId");

                    b.HasIndex("UserId");

                    b.ToTable("CaseHistories");
                });

            modelBuilder.Entity("Case_Management_System.Models.Lawyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LawyerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LawyerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LawyerPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Rate")
                        .HasColumnType("float");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Lawyers");
                });

            modelBuilder.Entity("Case_Management_System.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LawyerId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating1")
                        .HasColumnType("int");

                    b.Property<string>("RatingText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LawyerId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Case_Management_System.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Case_Management_System.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Case_Management_System.Models.CaseHistory", b =>
                {
                    b.HasOne("Case_Management_System.Models.Lawyer", "Lawyer")
                        .WithMany("CaseHistories")
                        .HasForeignKey("LawyerId");

                    b.HasOne("Case_Management_System.Models.User", "User")
                        .WithMany("CaseHistories")
                        .HasForeignKey("UserId");

                    b.Navigation("Lawyer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Case_Management_System.Models.Lawyer", b =>
                {
                    b.HasOne("Case_Management_System.Models.Service", "Service")
                        .WithMany("Lawyers")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Case_Management_System.Models.Rating", b =>
                {
                    b.HasOne("Case_Management_System.Models.Lawyer", "Lawyer")
                        .WithMany("Ratings")
                        .HasForeignKey("LawyerId");

                    b.HasOne("Case_Management_System.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Lawyer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Case_Management_System.Models.Lawyer", b =>
                {
                    b.Navigation("CaseHistories");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Case_Management_System.Models.Service", b =>
                {
                    b.Navigation("Lawyers");
                });

            modelBuilder.Entity("Case_Management_System.Models.User", b =>
                {
                    b.Navigation("CaseHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
