using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.Database
{
    public class DbUserRepository : DbRepository<User>, IUserRepository    {
        public DbUserRepository(IConfiguration config) : base(config)
        {
            //public async Task<IEnumerable<User>> GetAllUserAsync()
            //{
            //    return await dbRepositoryContext.Projects
            //        .Include(s => s.NeededSkills)
            //        .Include(i => i.ImageURLs)
            //        .ToListAsync();
            //}

            //public async Task<Project> GetSpecificProjectAsync(int id)
            //{
            //    return await dbRepositoryContext.Projects
            //        .Include(s => s.NeededSkills)
            //        .Include(i => i.ImageURLs)
            //        .ToListAsync()
            //        .FindAsync(id);  //( -_-) :'(
            //}
        }
    }
}



 