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
        /// <param name="config">The configuration.</param>
        public LagaltDbContext(IConfiguration config) : base()
        {
            Configuration = config;
        }
        /// <summary>
        /// The configuration.
        /// </summary>
        protected IConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Gets or sets the applications.
        /// </summary>
        public DbSet<Application> Applications { get; set; }

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        public DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// Gets or sets the image URLs.
        /// </summary>
        public DbSet<ImageUrl> ImageUrls { get; set; }

        /// <summary>
        /// Gets or sets the user messages.
        /// </summary>
        public DbSet<UserMessage> UserMessages { get; set; }

        /// <summary>
        /// Configures the context options.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LAGALT_DB")).EnableSensitiveDataLogging());
        }

        /// <summary>
        /// Configures the models for the context.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Appointing seeds to entities.
            modelBuilder.Entity<ImageUrl>().HasData(SeedData.ImageURLs);
            modelBuilder.Entity<Project>().HasData(SeedData.Projects);
            modelBuilder.Entity<User>().HasData(SeedData.Users);
            modelBuilder.Entity<Skill>().HasData(SeedData.Skills);
            modelBuilder.Entity<Application>().HasData(SeedData.Applications); 


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

 
            // Seeding ImgURLs to Projects
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

            // Seeding userdata
            modelBuilder.Entity<User>()
           .HasMany(ad => ad.AdminProjects)
           .WithMany(pr => pr.Admins)
           .UsingEntity<Dictionary<string, object>>(
               "AdminProject",
               r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
               l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
               je =>
               {
                   je.HasKey("UserId", "ProjectId");
                   je.HasData(
                       new { UserId = 1, ProjectId = 1 },
                       new { UserId = 2, ProjectId = 2 },
                       new { UserId = 3, ProjectId = 3 },
                       new { UserId = 4, ProjectId = 4 },
                       new { UserId = 5, ProjectId = 4 },
                       new { UserId = 5, ProjectId = 5 }
                   );
               });

            // Seeding data for Contributors
            modelBuilder.Entity<User>()
           .HasMany(co => co.ContributorProjects)
           .WithMany(pr => pr.Contributors)
           .UsingEntity<Dictionary<string, object>>(
               "ContributorProject",
               r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
               l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
               je =>
               {
                   je.HasKey("UserId", "ProjectId");
                   je.HasData(
                       new { UserId = 5, ProjectId = 1 },
                       new { UserId = 2, ProjectId = 1 },
                       new { UserId = 1, ProjectId = 2 },
                       new { UserId = 2, ProjectId = 3 },
                       new { UserId = 3, ProjectId = 4 },
                       new { UserId = 4, ProjectId = 5 }
                   );
               });


        }
        /// <summary>
        /// Configures conventions for the database model.
        /// </summary>
        /// <param name="configurationBuilder">The model configuration builder.</param>
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
