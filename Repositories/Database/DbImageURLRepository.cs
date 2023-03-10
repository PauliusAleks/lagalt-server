using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.Database
{
    public class DbImageURLRepository : DbRepository<ImageUrl>, IImageURLRepository
    {
        public DbImageURLRepository(IConfiguration config) : base(config)
        {

        }
    }
}



