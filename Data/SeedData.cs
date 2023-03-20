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
                    Category = CategoryState.NettUtvikling,
                    Progress = ProgressState.Oppstart,//In percentage
                    Description = "Joachim Rønning",
                    GitURL = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/C6AB0EDCE8F41882EBBB782B76DD4F05D7E360D7C3F23B4F6D02C24699B26105/scale?width=1200&aspectRatio=1.78&format=jpeg"
                },
                new Project
                {
                    Id = 2,
                    Name = "EF CodeFirst",
                    Category = CategoryState.NettUtvikling,
                    Progress = ProgressState.Oppstart,
                    Description = "Ser etter c# utvikler",
                    GitURL = "https://gitlab.com/Frechr/assignment-three/-/tree/master/"

                },
                 new Project
                {
                    Id = 3,
                    Name = "Exciting Angular Project",
                    Category = CategoryState.NettUtvikling,
                    Progress = ProgressState.UnderUtvikling,//In percentage
                    Description = "Applikasjon for å fange pokemons",
                    GitURL = "https://gitlab.com/JarandNL/angular_pokemontrainer"
                },
                 new Project
                {
                    Id = 4,
                    Name = "High School Musical",
                    Category = CategoryState.Film,
                    Progress = ProgressState.Ferdig,//In percentage
                    Description = "Søte ungdommer",
                    GitURL = "https://www.imdb.com/title/tt0475293/",
                },
                 new Project
                {
                    Id = 5,
                    Name = "Best song ever!!!",
                    Category = CategoryState.Musikk,
                    Progress = ProgressState.UnderUtvikling,//In percentage
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
                 new ImageUrl {Id=1, Url="https://picsum.photos/200/300" },
                 new ImageUrl {Id=2, Url="https://picsum.photos/200/325" },
                 new ImageUrl {Id=3, Url="https://picsum.photos/200/350" },
                 new ImageUrl {Id=4, Url="https://m.media-amazon.com/images/M/MV5BZmQ3MWEyNTYtOTY1OC00MTljLWI3OGUtMmU1ZDc2OTYxNDQ4L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTczNjQwOTY@._V1_.jpg" },
                 new ImageUrl {Id=5, Url="https://www.aboutmusictheory.com/wp-content/uploads/2012/04/composing-music-verse-pop-song.jpg" }
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
                new Application { Id = 1, State = ApplicationState.Ventende, MotivationLetter = "Vær så snill", UserId=2, ProjectId = 1 },
                new Application { Id = 2, State = ApplicationState.Ventende, MotivationLetter = "Jeg er veldig flink", UserId = 3, ProjectId = 2 },
                new Application { Id = 3, State = ApplicationState.Ventende, MotivationLetter = "Jeg er ikke flink men fake it til you make it!", UserId=4, ProjectId = 2 },
                new Application { Id = 4, State = ApplicationState.Ventende, MotivationLetter = "Jeg lærer fort så gi meg en sjanse...", UserId=4, ProjectId = 3 },
                new Application { Id = 5, State = ApplicationState.Ventende, MotivationLetter = "Jeg er veldig spent og motivert. Dette er alt jeg ønsker meg!", UserId=5, ProjectId = 5 },
            };


    }
}
