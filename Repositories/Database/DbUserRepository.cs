using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;
using lagalt_web_api.Models.DTO.UserDTO;
using lagalt_web_api.Data;
using Microsoft.EntityFrameworkCore;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;

namespace lagalt_web_api.Repositories.Database
{
    /// <summary>
    /// A repository class for accessing and modifying User data in the database.
    /// </summary>
    public class DbUserRepository : DbRepository<User>, IUserRepository
    {
        private LagaltDbContext dbRepositoryContext { get; set; }

        public DbUserRepository(IConfiguration config) : base(config)
        {
            // Initializes a new instance of the LagaltDbContext class with the specified IConfiguration object
            dbRepositoryContext = new LagaltDbContext(config);
        }

        /// <summary>
        /// Updates a user's settings based on the provided id.
        /// </summary>
        /// <param name="id">The id of the user whose settings will be updated.</param>
        /// <param name="userEditDTO">A UserEditDTO object containing the updated user settings.</param>
        public async Task PutUserSettingsId(int id, UserEditDTO userEditDTO)
        {
            // Retrieves user data from the LagaltDbContext context, including skills information
            var user = await dbRepositoryContext.Users
                .Include(s => s.Skills)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            // Creates a new list to store user's skills
            List<Skill> newUserSkills = new List<Skill>();

            // Updates user's skills with the ones provided in the userEditDTO object
            foreach (var skill in userEditDTO.Skills.ToList())
            {
                Skill userSkill = await dbRepositoryContext.Skills.FindAsync(skill);
                newUserSkills.Add(userSkill);
            }

            // Updates user's portfolio and isHidden properties with the ones provided in the userEditDTO object
            user.Portfolio = userEditDTO.Portfolio;
            user.Skills = newUserSkills;
            user.IsHidden = userEditDTO.IsHidden;

            // Saves changes made to the LagaltDbContext context
            await dbRepositoryContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a user's settings based on the provided username.
        /// </summary>
        /// <param name="username">The username of the user whose settings will be updated.</param>
        /// <param name="userEditDTO">A UserEditDTO object containing the updated user settings.</param>
        public async Task PutUserSettingsUsername(string username, UserEditDTO userEditDTO)
        {
            // Retrieves user data from the LagaltDbContext context, including skills information
            var user = await dbRepositoryContext.Users
                .Include(s => s.Skills)
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();

            // Adds new skills to the LagaltDbContext context if they don't exist
            foreach (var skill in userEditDTO.Skills.ToList())
            {
                if (await dbRepositoryContext.Skills.Where(sk => sk.Name == skill).FirstOrDefaultAsync() == null)
                {
                    dbRepositoryContext.Add(new Skill { Name = skill });
                }
            }

            // Saves changes made to the LagaltDbContext context
            await dbRepositoryContext.SaveChangesAsync();

            // Creates a new list to store user's skills
            List<Skill> newUserSkills = new List<Skill>();

            // Updates user's skills with the ones provided in the userEditDTO object
            foreach (var skill in userEditDTO.Skills.ToList())
            {
                Skill userSkill = await dbRepositoryContext.Skills.Where(sk => sk.Name == skill).FirstOrDefaultAsync();
                newUserSkills.Add(userSkill);
            }

            // Updates user's portfolio and isHidden properties with the ones provided in the userEditDTO object
            user.Portfolio = userEditDTO.Portfolio;
            user.Skills = newUserSkills;
            user.IsHidden = userEditDTO.IsHidden;

            // Saves changes made to the LagaltDbContext context
            await dbRepositoryContext.SaveChangesAsync();
        }
    }
}
