using lagalt_web_api.Data;
using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;
using lagalt_web_api.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lagalt_web_api.Repositories.Database
{
    public class DbProjectRepository : DbRepository<Project>, IProjectRepository
    {

        private LagaltDbContext dbRepositoryContext { get; set; }

        public DbProjectRepository(IConfiguration config) : base(config)
        {
            dbRepositoryContext = new LagaltDbContext(config);
        }

        public async Task PutProjectSettings(int id, List<string> neededSkills, List<string> imageUrls)
        {
            var project = await dbRepositoryContext.Projects
               .Include(pr => pr.ImageURLs)
               .Include(pr => pr.NeededSkills)
               .Where(pr => pr.Id == id)
               .FirstOrDefaultAsync();
            List<ImageUrl> newImageUrls = new List<ImageUrl>();
            List<Skill> newNeededSkills = new List<Skill>();

            foreach (var url in imageUrls)
            {
                ImageUrl imgUrl = await dbRepositoryContext.ImageUrls.FindAsync(url);
                newImageUrls.Add(imgUrl);

            }
            foreach (var skill in neededSkills)
            {
                Skill nddSkill = await dbRepositoryContext.Skills.FindAsync(skill);
                newNeededSkills.Add(nddSkill);
            }
            project.ImageURLs = newImageUrls;
            project.NeededSkills = newNeededSkills;
            await dbRepositoryContext.SaveChangesAsync();

        }
    }
}



