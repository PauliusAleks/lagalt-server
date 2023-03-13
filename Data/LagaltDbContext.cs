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
            modelBuilder.Entity<Application>().HasData(SeedData.Applications);
            //modelBuilder.Entity<HistoricEvent>().HasData(SeedData.GetHistoricEventSeedData()); 


            // Seeding NeededSkills to Project
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

            // Seeding Skills to User

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

            //Seeding ImgURLs to Projects

            modelBuilder.Entity<ImageUrl>()
           .HasMany(img => img.Projects)
           .WithMany(p => p.ImageURLs)
           .UsingEntity<Dictionary<string, object>>(
               "ImageUrlProject",
               r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
               l => l.HasOne<ImageUrl>().WithMany().HasForeignKey("ImageUrlsId"),
               je =>
               {
                   je.HasKey("ImageUrlsId", "ProjectId");
                   je.HasData(
                       new { ImageUrlsId = 5, ProjectId = 1 },
                       new { ImageUrlsId = 1, ProjectId = 2 },
                       new { ImageUrlsId = 1, ProjectId = 5 },
                       new { ImageUrlsId = 2, ProjectId = 2 },
                       new { ImageUrlsId = 3, ProjectId = 3 },
                       new { ImageUrlsId = 4, ProjectId = 3 }
                   );
               });

            modelBuilder.Entity<Admin>()
           .HasMany(ad => ad.Projects)
           .WithMany(pr => pr.Admins)
           .UsingEntity<Dictionary<string, object>>(
               "AdminProject",
               r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
               l => l.HasOne<Admin>().WithMany().HasForeignKey("AdminId"),
               je =>
               {
                   je.HasKey("AdminId", "ProjectId");
                   je.HasData(
                       new { AdminId = 1, ProjectId = 1 },
                       new { AdminId = 2, ProjectId = 2 },
                       new { AdminId = 3, ProjectId = 3 },
                       new { AdminId = 4, ProjectId = 4 },
                       new { AdminId = 5, ProjectId = 4 },
                       new { AdminId = 5, ProjectId = 5 }
                   );
               });

            // Seeding data for Contributors
            modelBuilder.Entity<Contributor>()
           .HasMany(co => co.Projects)
           .WithMany(pr => pr.Contributors)
           .UsingEntity<Dictionary<string, object>>(
               "ContributorProject",
               r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
               l => l.HasOne<Contributor>().WithMany().HasForeignKey("ContributorId"),
               je =>
               {
                   je.HasKey("ContributorId", "ProjectId");
                   je.HasData(
                       new { ContributorId = 5, ProjectId = 1 },
                       new { ContributorId = 2, ProjectId = 1 },
                       new { ContributorId = 1, ProjectId = 2 },
                       new { ContributorId = 2, ProjectId = 3 },
                       new { ContributorId = 3, ProjectId = 4 },
                       new { ContributorId = 4, ProjectId = 5 }
                   );
               });


        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
