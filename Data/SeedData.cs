﻿using lagalt_web_api.Models;
using lagalt_web_api.Models.LinkerModels;

namespace lagalt_web_api.Data
{
    /// <summary>
    /// Seeding data for testing purposes
    /// </summary>
    public class SeedData
    {
        /// <summary>
        /// The projects.
        /// </summary>
        /// 
        public static List<Project> Projects => new List<Project>
        {
                new Project
                {
                    Id = 1,
                    Name = "Tinder v2",
                    Category = CategoryState.WebDevelopment,
                    Progress = ProgressState.Founding,//In percentage
                    Description = "Joachim Rønning",
                    GitURL = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/C6AB0EDCE8F41882EBBB782B76DD4F05D7E360D7C3F23B4F6D02C24699B26105/scale?width=1200&aspectRatio=1.78&format=jpeg",
                },
                new Project
                {
                    Id = 2,
                    Name = "EF_CodeFirst",
                    Category = CategoryState.WebDevelopment,
                    Progress = ProgressState.Founding,
                    Description = "Looking for a c# back-end developer",
                    GitURL = "https://gitlab.com/Frechr/assignment-three/-/tree/master/"

                },
                 new Project
                {
                    Id = 3,
                    Name = "Exciting_Angular_Project",
                    Category = CategoryState.WebDevelopment,
                    Progress = ProgressState.InProgress,//In percentage
                    Description = "Web app to catch pokemons!",
                    GitURL = "https://gitlab.com/JarandNL/angular_pokemontrainer"
                },
                 new Project
                {
                    Id = 4,
                    Name = "High School Musical",
                    Category = CategoryState.Film,
                    Progress = ProgressState.Completed,//In percentage
                    Description = "Hot youth!!!!",
                    GitURL = "https://www.imdb.com/title/tt0475293/",
                },
                 new Project
                {
                    Id = 5,
                    Name = "Best song ever!!!",
                    Category = CategoryState.Music,
                    Progress = ProgressState.InProgress,//In percentage
                    Description = "Pls help make the best song ever",
                }
            };


        /// <summary>
        /// The users
        /// </summary>
        public static List<User> Users =>
            new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "adminBoy",
                    FirstName = "Admin",
                    LastName = "Adminson",
                    Email = "admin123@admin.no",
                    UserStatus = false,
                },

                new User
                {
                    Id = 2,
                    Username = "sharkboy05",
                    FirstName = "Per",
                    LastName = "Polle",
                    Email = "PerPolle@sharkboy.no,",
                    UserStatus = true,

                },
                new User
                {
                    Id = 3,
                    Username = "ProperUser",
                    FirstName = "Proper",
                    LastName = "Userito",
                    Email = "testing123@Proper.no",
                    UserStatus = false,
                },
                new User
                {
                    Id = 4,
                    Username = "StrangerHere",
                    FirstName = "Bob",
                    LastName = "Forr",
                    Email = "BobBobby@mail.no",
                    UserStatus = true,
                },
            };
        public static ICollection<Admin> Admins => new List<Admin>
        {
            new Admin { Id=1, UserId = 1, ProjectId = 1 },
            new Admin { Id=2, UserId = 2, ProjectId = 2 },
            new Admin { Id=3, UserId = 1, ProjectId = 2 },
            new Admin { Id=4, UserId = 3, ProjectId = 3 },
        };

        public static ICollection<Contributor> Contributors => new List<Contributor>
        {
            new Contributor { Id=1,UserId = 1, ProjectId = 1 },
            new Contributor { Id=2,UserId = 2, ProjectId = 2 },
            new Contributor { Id=3,UserId = 1, ProjectId = 3 },
            new Contributor { Id=4,UserId = 3, ProjectId = 1 },
        };

        public static ICollection<ProjectSkill> ProjectSkills => new List<ProjectSkill>
        {
            new ProjectSkill { Id=1, SkillId = 1, ProjectId = 1 },
            new ProjectSkill { Id=2, SkillId = 2, ProjectId = 2 },
            new ProjectSkill { Id=3, SkillId = 1, ProjectId = 3 },
            new ProjectSkill { Id=4, SkillId = 3, ProjectId = 1 },
        };

        public static ICollection<UserSkill> UserSkills => new List<UserSkill>
        {
            new UserSkill { Id=1, SkillId = 1, UserId = 1 },
            new UserSkill { Id=2, SkillId = 2, UserId = 2 },
            new UserSkill { Id=3, SkillId = 1, UserId = 3 },
            new UserSkill { Id=4, SkillId = 3, UserId = 1 },
        };
        public static ICollection<ProjectImageUrl> ProjectImageURLs => new List<ProjectImageUrl>
        {
            new ProjectImageUrl { Id=1, ProjectId = 1, ImageURLId = 1 },
            new ProjectImageUrl { Id=2, ProjectId = 2, ImageURLId = 2 },
            new ProjectImageUrl { Id=3, ProjectId = 1, ImageURLId = 3 },
            new ProjectImageUrl { Id=4, ProjectId = 3, ImageURLId = 1 },
        };

        public static ICollection<ImageUrl> ImageURLs => new List<ImageUrl>
        {
                 new ImageUrl {Id=5, Url="https://www.youtube.com/watch?v=LkWQvzrv6gI" },
                 new ImageUrl {Id=4, Url="https://picsum.photos/200/300" },
                 new ImageUrl {Id=3, Url="https://www.aboutmusictheory.com/wp-content/uploads/2012/04/composing-music-verse-pop-song.jpg" },
                 new ImageUrl {Id=2, Url="https://m.media-amazon.com/images/M/MV5BZmQ3MWEyNTYtOTY1OC00MTljLWI3OGUtMmU1ZDc2OTYxNDQ4L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTczNjQwOTY@._V1_.jpg" },
                 new ImageUrl {Id=1, Url="https://picsum.photos/200/350,https://picsum.photos/200/250" }
         };


        public static ICollection<Skill> Skills => new List<Skill>
            {
                new Skill{ Id=1, Name="Java"},
                new Skill{ Id=2, Name="C#"},
                new Skill{ Id=3, Name="Photoshop"},
                new Skill{ Id=4, Name="Sony Vegas"},
                new Skill{ Id=5, Name="Fruity Loops Studio"}
            };




        public static ICollection<Application> Applications => new List<Application>
            {
                new Application
                {
                    Id = 1, MotivationLetter = "Hallais", State = ApplicationState.Accepted, UserId= 1, ProjectId = 1
                },
                new Application
                {
                    Id = 2, MotivationLetter = "Hallais", State = ApplicationState.Pending, UserId= 2, ProjectId = 3
                }
            };
    }
}
