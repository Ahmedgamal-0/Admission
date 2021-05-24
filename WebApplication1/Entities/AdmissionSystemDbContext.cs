using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Entities
{
    public class AdmissionSystemDbContext:DbContext
    {
        public AdmissionSystemDbContext (DbContextOptions<AdmissionSystemDbContext>options):base(options)
        {
            Database.Migrate();

        }
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<ParentInfo> ParentInfo { get; set; }
        public DbSet<EmergencyContact> EmergencyContact { get; set; }
    }
}
