using lagalt_web_api.Data;
using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.Database
{
    public class DbProjectRepository : DbRepository<Project>, IProjectRepository    {
        public DbProjectRepository(IConfiguration config) : base(config)
        {

        }
    }
}



 