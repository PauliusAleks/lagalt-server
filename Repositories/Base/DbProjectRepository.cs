using lagalt_back_end.Data;
using lagalt_back_end.Models;

namespace lagalt_back_end.Repositories.Base
{
    public class DbProjectRepository : DbRepositoryBase<Project>, IProjectRepository    {
        public DbProjectRepository(LagaltDbContext context) : base(context)
        {

        }
    }
}



 