using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;
using lagalt_web_api.Models.DTO.UserDTO;
using lagalt_web_api.Data;
using Microsoft.EntityFrameworkCore;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;

namespace lagalt_web_api.Repositories.Database
{
    public class DbUserRepository : DbRepository<User>, IUserRepository
    {
        private LagaltDbContext dbRepositoryContext { get; set; }

        public DbUserRepository(IConfiguration config) : base(config)
        {
            dbRepositoryContext = new LagaltDbContext(config);
        }
        public async Task PutUserSettingsId(int id, UserEditDTO userEditDTO)
        {
            var user = await dbRepositoryContext.Users
                .Include(s => s.Skills)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            List<Skill> newUserSkills = new List<Skill>();

            foreach (var skill in userEditDTO.Skills.ToList())
            {
                Skill userSkill = await dbRepositoryContext.Skills.FindAsync(skill);
                newUserSkills.Add(userSkill);
            }

            user.Portfolio = userEditDTO.Portfolio;
            user.Skills = newUserSkills;
            user.IsHidden = userEditDTO.IsHidden;
            await dbRepositoryContext.SaveChangesAsync();
        }
        public async Task PutUserSettingsUsername(string username, UserEditDTO userEditDTO)
        {
            var user = await dbRepositoryContext.Users
                .Include(s => s.Skills)
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();
            List<Skill> newUserSkills = new List<Skill>();

            foreach (var skill in userEditDTO.Skills.ToList())
            {
                Skill userSkill = await dbRepositoryContext.Skills.FindAsync(skill);
                newUserSkills.Add(userSkill);
            }

            user.Portfolio = userEditDTO.Portfolio;
            user.Skills = newUserSkills;
            user.IsHidden = userEditDTO.IsHidden;
            await dbRepositoryContext.SaveChangesAsync();
        }
    }
}




