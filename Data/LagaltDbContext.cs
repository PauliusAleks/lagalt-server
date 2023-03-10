using lagalt_web_api.Models;
using lagalt_web_api.Data;
using lagalt_web_api.Models.History;
using Microsoft.EntityFrameworkCore;  

namespace lagalt_web_api.Data
{
    /// <summary>
    /// The database context on which we operate on.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For more information please see
    /// <see cref="DbContext"/>
    /// </para>
    /// </remarks> 
    public class LagaltDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LagaltDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        //public LagaltDbContext(DbContextOptions<LagaltDbContext> options) : base(options)
        //{
        //}
        protected IConfiguration Configuration { get; set; }
        public LagaltDbContext(IConfiguration config) : base()
        {
            Configuration = config;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ImageUrl> ImageUrls { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        //public DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LAGALT_DB")).EnableSensitiveDataLogging());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageUrl>().HasData(SeedData.ImageURLs);
            modelBuilder.Entity<Project>().HasData(SeedData.Projects);
            modelBuilder.Entity<User>().HasData(SeedData.Users);
            modelBuilder.Entity<Skill>().HasData(SeedData.Skills);
            //modelBuilder.Entity<HistoricEvent>().HasData(SeedData.GetHistoricEventSeedData()); 
            //modelBuilder.Entity<Application>().HasData(SeedData.GetApplicationSeedData()); 
            //modelBuilder.Entity<Skill>().HasData(SeedData.GetSkillSeedData()); 

            modelBuilder.Entity<Skill>()
           .HasMany(sk => sk.Projects)
           .WithMany(p => p.NeededSkills)
           .UsingEntity<Dictionary<string, object>>(
               "ProjectSkill",
               r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
               l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
               je =>
               {
                   je.HasKey("SkillId", "ProjectId");
                   je.HasData(
                       new { SkillId = 5, ProjectId = 1 },
                       new { SkillId = 1, ProjectId = 2 },
                       new { SkillId = 1, ProjectId = 5 },
                       new { SkillId = 2, ProjectId = 2 },
                       new { SkillId = 3, ProjectId = 3 },
                       new { SkillId = 4, ProjectId = 3 }
                   );
               });
            
            modelBuilder.Entity<Skill>()
            .HasMany(sk => sk.Users)
            .WithMany(u => u.Skills)
            .UsingEntity<Dictionary<string, object>>(
               "UserSkill",
               r => r.HasOne<User>().WithMany().HasForeignKey("UserId"),
               l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
               je =>
               {
                   je.HasKey("SkillId", "UserId");
                   je.HasData(
                       new { SkillId = 5, UserId = 1 },
                       new { SkillId = 1, UserId = 2 },
                       new { SkillId = 1, UserId = 4 },
                       new { SkillId = 2, UserId = 2 },
                       new { SkillId = 3, UserId = 3 },
                       new { SkillId = 4, UserId = 3 }
                   );
               });
            
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
