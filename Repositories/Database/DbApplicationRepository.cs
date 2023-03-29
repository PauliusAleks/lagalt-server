using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Database;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.Database
{
    //Application repositoru is only using basic CRUD methods
    public class DbApplicationRepository : DbRepository<Application>, IApplicationRepository
    {
        public DbApplicationRepository( IConfiguration config) : base(config)
        {

        }
    }
}



