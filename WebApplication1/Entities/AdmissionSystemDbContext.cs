using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Entities
{
    public class AdmissionSystemDbContext : DbContext
    {
        public AdmissionSystemDbContext(DbContextOptions<AdmissionSystemDbContext> options) : base(options)
        {
            Database.Migrate();

        }
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<ParentInfo> ParentInfo { get; set; }
        public DbSet<EmergencyContact> EmergencyContact { get; set; }
        public DbSet<AdmissionDetails> AdmissionDetails { get; set; }
        public DbSet<TransferredStudent> TransferredStudents { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<MedicalHistory> MedicalHistory { get; set; }
        public DbSet<Sibling> Sibling { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Fawry> Fawry { get; set; }
        public DbSet<MasterCard> MasterCard { get; set; }
        public DbSet<BankElahly> BankElahly { get; set; }



    }
}
