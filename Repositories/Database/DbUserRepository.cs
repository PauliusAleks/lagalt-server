using lagalt_back_end.Data;
using lagalt_back_end.Models;
using lagalt_web_api.Repositories.Interface;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lagalt_back_end.Repositories.Base
{
    public class DbUserRepository : DbRepository<User>, IUserRepository    {
        public DbUserRepository(IConfiguration config) : base(config)
        {

        }
    }
}



 