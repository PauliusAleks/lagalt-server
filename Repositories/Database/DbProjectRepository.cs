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

        //Method to update  aProject
        public async Task PutProjectSettings(int id, ProjectEditDTO projectEditDTO)
        {
            //Find the right project and include needed navigation properties
            var project = await dbRepositoryContext.Projects
               .Include(pr => pr.ImageURLs)
               .Include(pr => pr.NeededSkills)
               .Where(pr => pr.Id == id)
               .FirstOrDefaultAsync();

            //Add new given skill if not exists
            foreach (var skill in projectEditDTO.NeededSkills.ToList())
            {
                if (await dbRepositoryContext.Skills.Where(sk => sk.Name == skill).FirstOrDefaultAsync() == null)
                {
                    dbRepositoryContext.Add(new Skill { Name = skill });
                }
            }

            //Add new image url if not exists
            foreach (var url in projectEditDTO.ImageUrls.ToList())
            {
                if (await dbRepositoryContext.ImageUrls.Where(ur => ur.Url == url).FirstOrDefaultAsync() == null)
                {
                    dbRepositoryContext.Add(new ImageUrl { Url = url });
                }
            }

            //Update the database
            await dbRepositoryContext.SaveChangesAsync();

            List<Skill> newSkills = new List<Skill>();
            List<ImageUrl> newImageUrls = new List<ImageUrl>();

            //Find the skill in the database and add it to the list that will the old project skills.
            foreach (var skillToAdd in projectEditDTO.NeededSkills.ToList())
            {
                Skill skill = await dbRepositoryContext.Skills.Where(sk => sk.Name == skillToAdd).FirstOrDefaultAsync();
                newSkills.Add(skill);

            }
            //Find the imageUrl in the database and add it to the list that will the old project image urls.
            foreach (var imageUrlToAdd in projectEditDTO.ImageUrls.ToList())
            {
                ImageUrl url = await dbRepositoryContext.ImageUrls.Where(img => img.Url == imageUrlToAdd).FirstOrDefaultAsync();
                newImageUrls.Add(url);
            }

            //Changing progress string values in front-end to Enum values in backEnd
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

            //Changing category string values in front-end to Enum values in backEnd
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

            //Setting projects settings to the new ones and saving the database
            project.Name = projectEditDTO.Name;
            project.Description = projectEditDTO.Description;
            project.ImageURLs = newImageUrls;
            project.NeededSkills = newSkills;
            await dbRepositoryContext.SaveChangesAsync();
        }

        //Method to add new contributor to the the project with given id
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
        //method to add new admin to the project with given id
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

        //add new image to project
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

        //method to create a new project
        public async Task PostProject(ProjectCreateDTO projectCreateDTO)
        {
            //if there is no same skill in the DB - create new one
            foreach (var skill in projectCreateDTO.NeededSkills.ToList())
            {
                if (await dbRepositoryContext.Skills.Where(sk => sk.Name == skill).FirstOrDefaultAsync() == null)
                {
                    dbRepositoryContext.Add(new Skill { Name = skill });
                }
            }

            //if there is no same Url in the DB - create new one
            foreach (var url in projectCreateDTO.ImageUrls.ToList())
            {
                if (await dbRepositoryContext.ImageUrls.Where(ur => ur.Url == url).FirstOrDefaultAsync() == null)
                {
                    dbRepositoryContext.Add(new ImageUrl { Url = url });
                }
            }
            //save changes
            await dbRepositoryContext.SaveChangesAsync();

            List<Skill> skillsToAdd = new List<Skill>();
            List<ImageUrl> imageUrlsToAdd = new List<ImageUrl>();

            //for each string in projectDTO find the skill in Skills table and add it to the list
            foreach (var skillToAdd in projectCreateDTO.NeededSkills.ToList())
            {
                Skill skill = await dbRepositoryContext.Skills.Where(sk => sk.Name == skillToAdd).FirstOrDefaultAsync();
                skillsToAdd.Add(skill);

            }

            //for each string in projectDTO find the url in Urls table and add it to the list
            foreach (var imageUrlToAdd in projectCreateDTO.ImageUrls.ToList())
            {
                ImageUrl url = await dbRepositoryContext.ImageUrls.Where(img => img.Url == imageUrlToAdd).FirstOrDefaultAsync();
                imageUrlsToAdd.Add(url);
            }
            //find admin that has created the project
            User admin = await dbRepositoryContext.Users.FindAsync(projectCreateDTO.adminId);
            CategoryState category = new CategoryState();
            ProgressState progress = new ProgressState();

            //Converting Progress as string to enum value
            if (projectCreateDTO.Progress == "Oppstart")
            {
                progress = ProgressState.Oppstart;
            }
            else if (projectCreateDTO.Progress == "UnderUtvikling")
            {
                progress = ProgressState.UnderUtvikling;

            }
            else if (projectCreateDTO.Progress == "Utsatt")
            {
                progress = ProgressState.Utsatt;

            }
            else if (projectCreateDTO.Progress == "Ferdig")
            {
                progress = ProgressState.Ferdig;

            }

            //Converting Category string value to Enum value
            if (projectCreateDTO.Category == "Musikk")
            {
                category = CategoryState.Musikk;
            }
            else if (projectCreateDTO.Category == "Film")
            {
                category = CategoryState.Film;
            }
            else if (projectCreateDTO.Category == "SpillUtvikling")
            {
                category = CategoryState.SpillUtvikling;
            }
            else if (projectCreateDTO.Category == "NettUtvikling")
            {
                category = CategoryState.NettUtvikling;
            }

            //Creating new project with the given properties
            Project project = new Project
            {
                Name = projectCreateDTO.Name,
                Category = category,
                Progress = progress,
                Description = projectCreateDTO.Description,
                GitURL = projectCreateDTO.GitURL,
                ImageURLs = imageUrlsToAdd,
                NeededSkills = skillsToAdd,
                Admins = new List<User> { admin },
                Contributors = new List<User> { admin }
            };

            //Adding the project to the DB and saving the changes.
            dbRepositoryContext.Projects.Add(project);
            await dbRepositoryContext.SaveChangesAsync();
        }



    }

}




