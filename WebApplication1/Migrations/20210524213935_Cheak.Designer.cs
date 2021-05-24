﻿// <auto-generated />
using System;
using AdmissionSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdmissionSystem.Migrations
{
    [DbContext(typeof(AdmissionSystemDbContext))]
    [Migration("20210524213935_Cheak")]
    partial class Cheak
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdmissionSystem.Entities.AdmissionDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcademicYear");

                    b.Property<int>("ApplicantId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Grade");

                    b.Property<string>("Section");

                    b.Property<string>("Stage");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("AdmissionDetails");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AdmissionDetails");
                });

            modelBuilder.Entity("AdmissionSystem.Entities.Applicant", b =>
                {
                    b.Property<int>("ApplicantId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("FamilyStatus");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("Mobile");

                    b.Property<string>("Nationality");

                    b.Property<string>("Payment");

                    b.Property<string>("PlaceOfBirth");

                    b.Property<string>("Relegion");

                    b.Property<string>("SecondName");

                    b.Property<string>("SpokenLanguage");

                    b.Property<string>("Status");

                    b.HasKey("ApplicantId");

                    b.ToTable("Applicant");
                });

            modelBuilder.Entity("AdmissionSystem.Entities.EmergencyContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicantId");

                    b.Property<string>("FullName");

                    b.Property<string>("HomeNumber");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Relationship");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("EmergencyContact");
                });

            modelBuilder.Entity("AdmissionSystem.Entities.ParentInfo", b =>
                {
                    b.Property<string>("FirstName")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicantId");

                    b.Property<string>("CompanyName");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<string>("IdentificationNumber");

                    b.Property<string>("IdentificationType");

                    b.Property<string>("LastName");

                    b.Property<string>("Mobile");

                    b.Property<string>("Nationality");

                    b.Property<string>("Occupation");

                    b.Property<string>("PlaceOfBirth");

                    b.Property<string>("Relegion");

                    b.Property<string>("SecondName");

                    b.HasKey("FirstName");

                    b.HasIndex("ApplicantId");

                    b.ToTable("ParentInfo");
                });

            modelBuilder.Entity("AdmissionSystem.Entities.TransferredStudent", b =>
                {
                    b.HasBaseType("AdmissionSystem.Entities.AdmissionDetails");

                    b.Property<string>("Curriculum");

                    b.Property<string>("LastYearScore");

                    b.Property<string>("SchoolName")
                        .ValueGeneratedOnAdd();

                    b.ToTable("TransferredStudent");

                    b.HasDiscriminator().HasValue("TransferredStudent");
                });

            modelBuilder.Entity("AdmissionSystem.Entities.AdmissionDetails", b =>
                {
                    b.HasOne("AdmissionSystem.Entities.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdmissionSystem.Entities.EmergencyContact", b =>
                {
                    b.HasOne("AdmissionSystem.Entities.Applicant", "Applicant")
                        .WithMany("EmergencyContact")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdmissionSystem.Entities.ParentInfo", b =>
                {
                    b.HasOne("AdmissionSystem.Entities.Applicant", "Applicant")
                        .WithMany("ParentInfo")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
