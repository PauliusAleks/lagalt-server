using lagalt_back_end.Models;
using lagalt_back_end.Repositories;
using lagalt_back_end.Models;
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
	    public DbSet<History> HistoryModels { get; set; }
        public DbSet<User> UserModels { get; set; }
        public DbSet<Project> Projects { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(SeedData.GetProjectSeedData()); 
        }
    }
}
