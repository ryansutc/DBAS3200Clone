using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSCCModelDB
{
    public class NSCCDBContext: DbContext
    {
        public NSCCDBContext() : base("NSCCDb") // name= means this is a conn string. not working
        {
            try
            {
                //recreate database if model changes (before real data exists in database)
                //Database.SetInitializer(new DropCreateDatabaseAlways<NSCCDBContext>());
                //Database.SetInitializer(new NSCCDatabaseInitializer());
                //Database.SetInitializer(new CreateDatabaseIfNotExists<NSCCDBContext>());
            }
            catch(Exception e)
            {
                return;
            }
            
        }
        public DbSet<Application> Applications { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<Campus> Campuses { get; set; }

        public DbSet<ProgramChoice> ProgramChoices { get; set; }

        public DbSet<AcademicYear> AcademicYears { get; set; }

        
        public DbSet<Country> Countries { get; set; }

        public DbSet<ProvinceState> ProvinceStates { get; set; }

        public DbSet<Citizenship> Citizenships { get; set; }

        public DbSet<Applicant> Applicants { get; set; }

        //public DbSet<CampusProgram> CampusProgram { get; set; }
        /// <summary>
        /// Update properties on creation of model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Define custom pivot tables
            modelBuilder.Entity<Campus>()
                        .HasMany<Program>(s => s.Programs)
                        .WithMany(c => c.Campuses)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("CampusId");
                            cs.MapRightKey("ProgramId");
                            cs.ToTable("CampusProgram");
                        });

            modelBuilder.Entity<Application>()
                       .HasMany<AcademicYear>(s => s.AcademicYears)
                       .WithMany(c => c.Applications)
                       .Map(cs =>
                       {
                           cs.MapLeftKey("ApplicationId");
                           cs.MapRightKey("AcademicYearId");
                           cs.ToTable("ApplicationAcademicYear");
                       });

        }

    }
}
