using lagalt_web_api.Models;

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
                    GitURL = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/C6AB0EDCE8F41882EBBB782B76DD4F05D7E360D7C3F23B4F6D02C24699B26105/scale?width=1200&aspectRatio=1.78&format=jpeg"
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
                    IsHidden = false,
                },

                new User
                {
                    Id = 2,
                    Username = "sharkboy05",
                    FirstName = "Per",
                    LastName = "Polle",
                    Email = "PerPolle@sharkboy.no,",
                    IsHidden = true,

                },
                new User
                {
                    Id = 3,
                    Username = "ProperUser",
                    FirstName = "Proper",
                    LastName = "Userito",
                    Email = "testing123@Proper.no",
                    IsHidden = false,
                },
                new User
                {
                    Id = 4,
                    Username = "StrangerHere",
                    FirstName = "Bob",
                    LastName = "Forr",
                    Email = "BobBobby@mail.no",
                    IsHidden = true,
                },
                new User
                {
                    Id = 5,
                    Username = "hulken",
                    FirstName = "Ole",
                    LastName = "Dole",
                    Email = "OleDole@mail.no",
                    IsHidden = true,
                },
            };


        public static List<ImageUrl> ImageURLs => new List<ImageUrl>
        {
                 new ImageUrl {Id=5, Url="https://www.youtube.com/watch?v=LkWQvzrv6gI" },
                 new ImageUrl {Id=4, Url="https://picsum.photos/200/300" },
                 new ImageUrl {Id=3, Url="https://www.aboutmusictheory.com/wp-content/uploads/2012/04/composing-music-verse-pop-song.jpg" },
                 new ImageUrl {Id=2, Url="https://m.media-amazon.com/images/M/MV5BZmQ3MWEyNTYtOTY1OC00MTljLWI3OGUtMmU1ZDc2OTYxNDQ4L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTczNjQwOTY@._V1_.jpg" },
                 new ImageUrl {Id=1, Url="https://picsum.photos/200/350,https://picsum.photos/200/250" }
         };


        public static List<Skill> Skills => new List<Skill>
            {
                new Skill{ Id=1, Name="Java"},
                new Skill{ Id=2, Name="C#"},
                new Skill{ Id=3, Name="Photoshop"},
                new Skill{ Id=4, Name="Sony Vegas"},
                new Skill{ Id=5, Name="Fruity Loops Studio"}
            };



        public static List<Application> Applications => new List<Application>
            {
                new Application { Id = 1, State = ApplicationState.Pending, MotivationLetter = "Please give me access!", UserId=2, ProjectId = 1 },
                new Application { Id = 2, State = ApplicationState.Pending, MotivationLetter = "I am so good!(btw I run arch)", UserId = 3, ProjectId = 2 },
                new Application { Id = 3, State = ApplicationState.Pending, MotivationLetter = "I am not good, but fake it til you make it!", UserId=4, ProjectId = 2 },
                new Application { Id = 4, State = ApplicationState.Pending, MotivationLetter = "I am a fast learner, so give me a chance...", UserId=4, ProjectId = 3 },
                new Application { Id = 5, State = ApplicationState.Pending, MotivationLetter = "This is the opportunity of a lifetime! So excited!", UserId=5, ProjectId = 5 },
            };


    }
}
