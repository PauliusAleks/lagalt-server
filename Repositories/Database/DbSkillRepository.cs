using lagalt_web_api.Data;
using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.Database
{
    public class DbSkillRepository : DbRepository<Skill>, ISkillRepository
    {
        public DbSkillRepository(IConfiguration config) : base(config)
        {

        }
    }
}



