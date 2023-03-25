using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;
namespace lagalt_web_api.Repositories.Database
{
    public class DbUserMessageRepository : DbRepository<UserMessage>, IUserMessageRepository
    {
        public DbUserMessageRepository(IConfiguration config) : base(config)
        {

        }
    }
}




