using lagalt_web_api.Models;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore;
using lagalt_web_api.Models.LinkerModels;

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
        public DbSet<UserSkill> UserSkills { get; set; }  
        public DbSet<ProjectSkill> ProjectSkills { get; set; }  
        public DbSet<ProjectImageUrl> ProjectImageURLs { get; set; }  
        //public DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(
                optionsBuilder
                
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("LAGALT_DB"))
                .EnableSensitiveDataLogging());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageUrl>().HasData(SeedData.ImageURLs);
            modelBuilder.Entity<Skill>().HasData(SeedData.Skills);           
            modelBuilder.Entity<User>().HasData(SeedData.Users);
            modelBuilder.Entity<Project>().HasData(SeedData.Projects);
            modelBuilder.Entity<Admin>().HasData(SeedData.Admins);
            modelBuilder.Entity<Contributor>().HasData(SeedData.Contributors);
            modelBuilder.Entity<UserSkill>().HasData(SeedData.UserSkills);
            modelBuilder.Entity<ProjectSkill>().HasData(SeedData.ProjectSkills);
            modelBuilder.Entity<ProjectImageUrl>().HasData(SeedData.ProjectImageURLs);
            modelBuilder.Entity<Application>().HasData(SeedData.Applications);

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
