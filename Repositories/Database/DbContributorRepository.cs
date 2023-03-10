using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.Database
{
    public class DbContributorRepository : DbRepository<Contributor>, IContributorRepository
    {
        public DbContributorRepository(IConfiguration config) : base(config)
        {

        }
    }
}



