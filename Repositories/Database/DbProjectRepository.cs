using lagalt_web_api.Data;
using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectCreateDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;
using lagalt_web_api.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using AutoMapper;

namespace lagalt_web_api.Repositories.Database
{
    public class DbProjectRepository : DbRepository<Project>, IProjectRepository
    {

        private LagaltDbContext dbRepositoryContext { get; set; }
        private readonly IMapper _mapper;

        public DbProjectRepository(IConfiguration config, IMapper mapper) : base(config)
        {
            dbRepositoryContext = new LagaltDbContext(config);
            _mapper = mapper;
        }

        public async Task PutProjectSettings(int id, ProjectEditDTO projectEditDTO)
        {
            var project = await dbRepositoryContext.Projects
               .Include(pr => pr.ImageURLs)
               .Include(pr => pr.NeededSkills)
               .Where(pr => pr.Id == id)
               .FirstOrDefaultAsync();
            List<ImageUrl> newImageUrls = new List<ImageUrl>();
            List<Skill> newNeededSkills = new List<Skill>();

            foreach (var url in projectEditDTO.ImageUrls.ToList())
            {
                ImageUrl imgUrl = await dbRepositoryContext.ImageUrls.FindAsync(url);
                newImageUrls.Add(imgUrl);

            }
            foreach (var skill in projectEditDTO.NeededSkillsName.ToList())
            {
                Skill nddSkill = await dbRepositoryContext.Skills.FindAsync(skill);
                newNeededSkills.Add(nddSkill);
            }

            project.Name = projectEditDTO.Name;
            project.Description = projectEditDTO.Description;
            project.Progress = projectEditDTO.Progress;
            project.Category = projectEditDTO.Category;
            project.ImageURLs = newImageUrls;
            project.NeededSkills = newNeededSkills;
            await dbRepositoryContext.SaveChangesAsync();
        }

        public async Task PutProjectContributor(int id, int memberId)
        {
            var project = await dbRepositoryContext.Projects
               .Include(pr => pr.Contributors)
               .Where(pr => pr.Id == id)
               .FirstOrDefaultAsync();
            List<User> projectContributors = project.Contributors.ToList();
            User contributorToAdd = await dbRepositoryContext.Users.FindAsync(memberId);
            if (!projectContributors.Contains(contributorToAdd))
            {
                projectContributors.Add(contributorToAdd);
            }
            project.Contributors = projectContributors;
            await dbRepositoryContext.SaveChangesAsync();
        }

        public async Task PutProjectAdmin(int id, int adminId)
        {
            var project = await dbRepositoryContext.Projects
               .Include(pr => pr.Admins)
               .Where(pr => pr.Id == id)
               .FirstOrDefaultAsync();
            List<User> ProjectAdmins = project.Admins.ToList();
            User userToAdd = await dbRepositoryContext.Users.FindAsync(adminId);
            if (!ProjectAdmins.Contains(userToAdd))
            {
                ProjectAdmins.Add(userToAdd);
            }
            project.Admins = ProjectAdmins;
            await dbRepositoryContext.SaveChangesAsync();
        }

        public async Task PutProjectImageUrl(int id, string imageUrl)
        {
            var project = await dbRepositoryContext.Projects
               .Include(pr => pr.ImageURLs)
               .Where(pr => pr.Id == id)
               .FirstOrDefaultAsync();

            List<ImageUrl> projectImageUrls = project.ImageURLs.ToList();

            ImageUrl imageUrlToCreate = new ImageUrl { Url = imageUrl };

            await dbRepositoryContext.ImageUrls.AddAsync(imageUrlToCreate);
            await dbRepositoryContext.SaveChangesAsync();

            ImageUrl imageUrlToAdd = await dbRepositoryContext.ImageUrls.FindAsync(imageUrlToCreate.Id);

            if (!projectImageUrls.Contains(imageUrlToAdd))
            {
                projectImageUrls.Add(imageUrlToAdd);
            }
            project.ImageURLs = projectImageUrls;
            await dbRepositoryContext.SaveChangesAsync();
        }

        public async Task PostProject(ProjectCreateDTO projectCreateDTO)
        {
            List<Skill> skillsToCreate = new List<Skill>();
            projectCreateDTO.NeededSkills.ForEach(skill => skillsToCreate.Add(new Skill { Name = skill }));

            List<ImageUrl> imageUrlsToCreate = new List<ImageUrl>();
            projectCreateDTO.ImageUrls.ForEach(url => imageUrlsToCreate.Add(new ImageUrl { Url = url }));
 
            Project projectTestee = _mapper.Map<Project>(projectCreateDTO);
            projectTestee.NeededSkills.ToList().ForEach(skill => { 
                Debug.WriteLine(skill.Id + ": " + skill.Name);
            });
 
            skillsToCreate.ForEach(async skill =>
            {
                Debug.WriteLine(skill.Id);
                if (dbRepositoryContext.Skills.FirstOrDefaultAsync(sk => sk.Name == skill.Name) == null)
                //if (!dbRepositoryContext.Skills.Contains(skill))
                {

                    await dbRepositoryContext.Skills.AddAsync(skill);
                }
            });

            imageUrlsToCreate.ForEach(async url =>
            {
                if (dbRepositoryContext.ImageUrls.FirstOrDefaultAsync(ur => ur.Url == url.Url) == null)
                //if (!dbRepositoryContext.ImageUrls.Contains(url))
                {
                    await dbRepositoryContext.ImageUrls.AddAsync(url);
                }
            });

            await dbRepositoryContext.SaveChangesAsync();

            List<Skill> skillsToAdd = new List<Skill>();
            List<ImageUrl> imageUrlsToAdd = new List<ImageUrl>();

            skillsToCreate.ForEach(async skill => skillsToAdd.Add(await dbRepositoryContext.Skills.FirstOrDefaultAsync(sk => sk.Name == skill.Name)));
            imageUrlsToCreate.ForEach(async url => imageUrlsToAdd.Add(await dbRepositoryContext.ImageUrls.FirstOrDefaultAsync(ur => ur.Url == url.Url)));

            Project project = new Project
            {
                Name = projectCreateDTO.Name,
                Category = projectCreateDTO.Category,
                Progress = projectCreateDTO.Progress,
                Description = projectCreateDTO.Description,
                GitURL = projectCreateDTO.GitURL,
                ImageURLs = imageUrlsToAdd,
                NeededSkills = skillsToAdd
            };

            dbRepositoryContext.Projects.Add(project);
            await dbRepositoryContext.SaveChangesAsync();
        }

    }

}




