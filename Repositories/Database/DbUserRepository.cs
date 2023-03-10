using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.Database
{
    public class DbUserRepository : DbRepository<User>, IUserRepository    {
        public DbUserRepository(IConfiguration config) : base(config)
        {

        }
    }
}



 