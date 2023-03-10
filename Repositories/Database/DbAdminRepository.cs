using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Database;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.Database
{
    public class DbAdminRepository : DbRepository<Admin>, IAdminRepository
    {
        public DbAdminRepository(IConfiguration config) : base(config)
        {
        }
    }
}



 