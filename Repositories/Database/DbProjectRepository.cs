using lagalt_back_end.Data;
using lagalt_back_end.Models;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_back_end.Repositories.Base
{
    public class DbProjectRepository : DbRepository<Project>, IProjectRepository    {
        public DbProjectRepository(IConfiguration config) : base(config)
        {

        }
    }
}



 