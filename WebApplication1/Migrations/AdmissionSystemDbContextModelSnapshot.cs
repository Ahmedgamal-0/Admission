﻿// <auto-generated />
using AdmissionSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdmissionSystem.Migrations
{
    [DbContext(typeof(AdmissionSystemDbContext))]
    partial class AdmissionSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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