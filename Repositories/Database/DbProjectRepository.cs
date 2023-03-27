using lagalt_web_api.Data;
using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectCreateDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;
using lagalt_web_api.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using AutoMapper;
using lagalt_web_api.Models.DTO.UserDTO;

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

            foreach (var skill in projectEditDTO.NeededSkills.ToList())
            {
                if (await dbRepositoryContext.Skills.Where(sk => sk.Name == skill).FirstOrDefaultAsync() == null)
                {
                    dbRepositoryContext.Add(new Skill { Name = skill });
                }
            }

            foreach (var url in projectEditDTO.ImageUrls.ToList())
            {
                if (await dbRepositoryContext.ImageUrls.Where(ur => ur.Url == url).FirstOrDefaultAsync() == null)
                {
                    dbRepositoryContext.Add(new ImageUrl { Url = url });
                }
            }

            await dbRepositoryContext.SaveChangesAsync();

            List<Skill> newSkills = new List<Skill>();
            List<ImageUrl> newImageUrls = new List<ImageUrl>();

            foreach (var skillToAdd in projectEditDTO.NeededSkills.ToList())
            {
                Skill skill = await dbRepositoryContext.Skills.Where(sk => sk.Name == skillToAdd).FirstOrDefaultAsync();
                newSkills.Add(skill);

            }

            foreach (var imageUrlToAdd in projectEditDTO.ImageUrls.ToList())
            {
                ImageUrl url = await dbRepositoryContext.ImageUrls.Where(img => img.Url == imageUrlToAdd).FirstOrDefaultAsync();
                newImageUrls.Add(url);
            }
            if (projectEditDTO.Progress == "Oppstart")
            {
                project.Progress = ProgressState.Oppstart;
            }
            else if (projectEditDTO.Progress == "UnderUtvikling")
            {
                project.Progress = ProgressState.UnderUtvikling;

            }
            else if (projectEditDTO.Progress == "Utsatt")
            {
                project.Progress = ProgressState.Utsatt;

            }
            else if (projectEditDTO.Progress == "Ferdig")
            {
                project.Progress = ProgressState.Ferdig;

            }
            if (projectEditDTO.Category == "Musikk")
            {
                project.Category = CategoryState.Musikk;
            }
            else if (projectEditDTO.Category == "Film")
            {
                project.Category = CategoryState.Film;
            }
            else if (projectEditDTO.Category == "SpillUtvikling")
            {
                project.Category = CategoryState.SpillUtvikling;
            }
            else if (projectEditDTO.Category == "NettUtvikling")
            {
                project.Category = CategoryState.NettUtvikling;
            }


            project.Name = projectEditDTO.Name;
            project.Description = projectEditDTO.Description;
            project.ImageURLs = newImageUrls;
            project.NeededSkills = newSkills;
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

            foreach (var skill in projectCreateDTO.NeededSkills.ToList())
            {
                if (await dbRepositoryContext.Skills.Where(sk => sk.Name == skill).FirstOrDefaultAsync() == null)
                {
                    dbRepositoryContext.Add(new Skill { Name = skill });
                }
            }

            foreach (var url in projectCreateDTO.ImageUrls.ToList())
            {
                if (await dbRepositoryContext.ImageUrls.Where(ur => ur.Url == url).FirstOrDefaultAsync() == null)
                {
                    dbRepositoryContext.Add(new ImageUrl { Url = url });
                }
            }

            await dbRepositoryContext.SaveChangesAsync();

            List<Skill> skillsToAdd = new List<Skill>();
            List<ImageUrl> imageUrlsToAdd = new List<ImageUrl>();

            foreach (var skillToAdd in projectCreateDTO.NeededSkills.ToList())
            {
                Skill skill = await dbRepositoryContext.Skills.Where(sk => sk.Name == skillToAdd).FirstOrDefaultAsync();
                skillsToAdd.Add(skill);

            }

            foreach (var imageUrlToAdd in projectCreateDTO.ImageUrls.ToList())
            {
                ImageUrl url = await dbRepositoryContext.ImageUrls.Where(img => img.Url == imageUrlToAdd).FirstOrDefaultAsync();
                imageUrlsToAdd.Add(url);
            }

            User admin = await dbRepositoryContext.Users.FindAsync(projectCreateDTO.adminId);
            Project project = new Project
            {
                Name = projectCreateDTO.Name,
                Category = projectCreateDTO.Category,
                Progress = projectCreateDTO.Progress,
                Description = projectCreateDTO.Description,
                GitURL = projectCreateDTO.GitURL,
                ImageURLs = imageUrlsToAdd,
                NeededSkills = skillsToAdd,
                Admins = new List<User> { admin },
                Contributors = new List<User> { admin }


            };

            dbRepositoryContext.Projects.Add(project);
            await dbRepositoryContext.SaveChangesAsync();
        }



    }

}




