using lagalt_back_end.Models;
using lagalt_back_end.Repositories;
using Microsoft.EntityFrameworkCore;

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
        public LagaltDbContext(DbContextOptions<LagaltDbContext> options) : base(options)
        {
        }
        public DbSet<History> History { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Url> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Project>().HasData(SeedData.GetProjectSeedData()); 
        }
    }
}
