using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AttendanceApi.Models;

namespace AttendanceApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<OrganisationUser> OrganisationUsers { get; set; }
        public DbSet<OrganisationGroup> OrganisationGroups { get; set; }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidatePhoto> CandidatePhotos{ get; set; }
        public DbSet<Attendance>  Attendances{ get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Organisation>().HasOne(a => a.User);
            builder.Entity<OrganisationGroup>().HasOne(a => a.Organisation);
            builder.Entity<OrganisationUser>().HasOne(a => a.User);
            builder.Entity<OrganisationUser>().HasOne(a => a.Organisation);
            builder.Entity<Candidate>().HasOne(a => a.OrganisationGroup);
            builder.Entity<CandidatePhoto>().HasOne(a => a.Candidate)
                .WithMany(a => a.CandidatePhotos).HasForeignKey(a=>a.CandidateId);
            builder.Entity<Attendance>().HasOne(a => a.Candidate);

        }
    }
}
