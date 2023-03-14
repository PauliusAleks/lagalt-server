using lagalt_web_api.Data;
using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace lagalt_web_api.Repositories.Database
{
    public class DbProjectRepository : DbRepository<Project>, IProjectRepository
    {

        private LagaltDbContext dbRepositoryContext { get; set; }

        public DbProjectRepository(IConfiguration config) : base(config)
        {
            dbRepositoryContext = new LagaltDbContext(config);
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await dbRepositoryContext.Projects
                .Include(pr => pr.NeededSkills)
                .Include(pr => pr.ImageURLs)
                .Include(pr => pr.Admins) //.Where(i => i.Id == Id)
                .Include(pr => pr.Contributors)
                .ToListAsync();
        }

        public async Task<Project> GetSpecificProjectAsync(int id)
        {
            return await dbRepositoryContext.Projects
                .Include(pr => pr.NeededSkills)
                .Include(pr => pr.ImageURLs)
                .Include(pr => pr.Admins)
                .Include(pr => pr.Contributors)
                .Where(pr => pr.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}



