using lagalt_back_end.Models;
using lagalt_back_end.Repositories; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace lagalt_back_end.Data
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
        public LagaltDbContext(IConfiguration config) : base( )
        { 
            Configuration= config;
        }
        public DbSet<HistoricEvent> HistoricEvents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ImageUrl> ImageUrls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LAGALT_DB")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(SeedData.ProjectSeed); 
            //modelBuilder.Entity<HistoricEvent>().HasData(SeedData.GetHistoricEventSeedData()); 
            //modelBuilder.Entity<User>().HasData(SeedData.GetUserSeedData()); 
            //modelBuilder.Entity<Application>().HasData(SeedData.GetApplicationSeedData()); 
            //modelBuilder.Entity<Skill>().HasData(SeedData.GetSkillSeedData()); 
            //modelBuilder.Entity<ImageUrl>().HasData(SeedData.GetImageUrlSeedData()); 
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
