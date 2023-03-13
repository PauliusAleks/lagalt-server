using lagalt_web_api.Data;
using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace lagalt_web_api.Repositories.Database
{
    public class DbProjectRepository : DbRepository<Project>, IProjectRepository    {

        private LagaltDbContext dbRepositoryContext { get; set; }

        public DbProjectRepository(IConfiguration config) : base(config)
        {
            dbRepositoryContext = new LagaltDbContext(config);
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await dbRepositoryContext.Projects
                .Include(s => s.NeededSkills)
                .Include(i => i.ImageURLs)
                .ToListAsync();
        }
    }
}



 