using lagalt_back_end.Data;
using lagalt_back_end.Models;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_back_end.Repositories.Base
{
    public class DbSkillRepository : DbRepository<Skill>, ISkillRepository
    {
        public DbSkillRepository(IConfiguration config) : base(config)
        {

        }
    }
}



