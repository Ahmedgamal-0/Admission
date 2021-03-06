// <auto-generated />
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
    [Migration("20210525180244_EditInSiblingTable")]
    partial class EditInSiblingTable
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

            modelBuilder.Entity("AdmissionSystem.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicantId");

                    b.Property<string>("Copy");

                    b.Property<string>("DocumentName");

                    b.Property<string>("DocumentType");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Documents");
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

            modelBuilder.Entity("AdmissionSystem.Entities.MedicalHistory", b =>
                {
                    b.Property<Guid>("MedicalHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicantId");

                    b.Property<bool>("Glass");

                    b.Property<bool>("Hearing");

                    b.Property<string>("MedicalConditions");

                    b.Property<string>("PhysiologicalConditions");

                    b.Property<bool>("PhysiologicalNeed");

                    b.HasKey("MedicalHistoryId");

                    b.HasIndex("ApplicantId");

                    b.ToTable("MedicalHistory");
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

            modelBuilder.Entity("AdmissionSystem.Entities.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Amount");

                    b.Property<int>("ApplicantId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("PaymentMethod");

                    b.Property<int>("SchoolId");

                    b.HasKey("PaymentId");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Payment");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Payment");
                });

            modelBuilder.Entity("AdmissionSystem.Entities.Sibling", b =>
                {
                    b.Property<Guid>("SibilingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("ApplicantId");

                    b.Property<string>("Relationship");

                    b.Property<string>("SchoolName");

                    b.Property<string>("SiblingName");

                    b.HasKey("SibilingId");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Siblings");
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

            modelBuilder.Entity("AdmissionSystem.Entities.BankElahly", b =>
                {
                    b.HasBaseType("AdmissionSystem.Entities.Payment");

                    b.Property<string>("BankCode");

                    b.ToTable("BankElahly");

                    b.HasDiscriminator().HasValue("BankElahly");
                });

            modelBuilder.Entity("AdmissionSystem.Entities.Fawry", b =>
                {
                    b.HasBaseType("AdmissionSystem.Entities.Payment");

                    b.Property<string>("FawryCode");

                    b.ToTable("Fawry");

                    b.HasDiscriminator().HasValue("Fawry");
                });

            modelBuilder.Entity("AdmissionSystem.Entities.MasterCard", b =>
                {
                    b.HasBaseType("AdmissionSystem.Entities.Payment");

                    b.Property<int>("CardNumber");

                    b.Property<string>("Cvv")
                        .IsRequired();

                    b.Property<DateTime>("ExpirationDate");

                    b.ToTable("MasterCard");

                    b.HasDiscriminator().HasValue("MasterCard");
                });

            modelBuilder.Entity("AdmissionSystem.Entities.AdmissionDetails", b =>
                {
                    b.HasOne("AdmissionSystem.Entities.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdmissionSystem.Entities.Document", b =>
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

            modelBuilder.Entity("AdmissionSystem.Entities.MedicalHistory", b =>
                {
                    b.HasOne("AdmissionSystem.Entities.Applicant", "Applicant")
                        .WithMany("MedicalHistory")
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

            modelBuilder.Entity("AdmissionSystem.Entities.Payment", b =>
                {
                    b.HasOne("AdmissionSystem.Entities.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdmissionSystem.Entities.Sibling", b =>
                {
                    b.HasOne("AdmissionSystem.Entities.Applicant", "Applicant")
                        .WithMany("Sibling")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
