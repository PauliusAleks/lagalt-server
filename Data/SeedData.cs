using lagalt_back_end.Models;

namespace lagalt_back_end.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class SeedData
    {
        /// <summary>
        /// The movies.
        /// </summary>
        private static List<Project> _projects = new List<Project>
        {
                new Project
                {
                    Name = "Tinder v2",
                    Category = CategoryState.WebDevelopment,
                    Progress = ProgressState.Founding,//In percentage
                    Description = "Joachim Rønning",
                    GitURL = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/C6AB0EDCE8F41882EBBB782B76DD4F05D7E360D7C3F23B4F6D02C24699B26105/scale?width=1200&aspectRatio=1.78&format=jpeg",
                    ImageURL = new List<string> {"https://www.youtube.com/watch?v=LkWQvzrv6gI" } ,
                    NeededSkills = new List<string>{"Drawing","Programming","Hiking" }
                },
                new Project
                {
                    Name = "EF_CodeFirst",
                    Category = CategoryState.WebDevelopment,
                    Progress = ProgressState.Founding,
                    Description = "Looking for a c# back-end developer",
                    GitURL = "https://gitlab.com/Frechr/assignment-three/-/tree/master/",
                    ImageURL = new List<string>{"https://picsum.photos/200/300" },
                    NeededSkills = new List<string>{"C#", ".NET", "SQL"}

                },
                 new Project
                {
                    Name = "Exciting_Angular_Project",
                    Category = CategoryState.WebDevelopment,
                    Progress = ProgressState.InProgress,//In percentage
                    Description = "Web app to catch pokemons!",
                    GitURL = "https://gitlab.com/JarandNL/angular_pokemontrainer",
                    ImageURL = new List<string> { "https://picsum.photos/200/350,https://picsum.photos/200/250" } ,
                    NeededSkills = new List<string>{"TypeScript","Html","Tailwind CSS" }
                },
                 new Project
                {
                    Name = "High School Musical",
                    Category = CategoryState.Film,
                    Progress = ProgressState.Completed,//In percentage
                    Description = "Hot youth!!!!",
                    GitURL = "https://www.imdb.com/title/tt0475293/",
                    ImageURL = new List<string> { "https://m.media-amazon.com/images/M/MV5BZmQ3MWEyNTYtOTY1OC00MTljLWI3OGUtMmU1ZDc2OTYxNDQ4L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTczNjQwOTY@._V1_.jpg" } ,
                    NeededSkills = new List<string>{"Singer","Actor","Dancer" }
                },
                 new Project
                {
                    Name = "Best song ever!!!",
                    Category = CategoryState.Music,
                    Progress = ProgressState.InProgress,//In percentage
                    Description = "Pls help make the best song ever",
                    ImageURL = new List<string> { "https://www.aboutmusictheory.com/wp-content/uploads/2012/04/composing-music-verse-pop-song.jpg" } ,
                    NeededSkills = new List<string>{"Singer", "Writer", "Composer" }
                }

         };
        private static List<User> Users = new List<User>
        {
            new User 
            {
                Username = "adminBoy",
                FirstName = "Admin",
                LastName = "Adminson",
                Email = "admin123@admin.no",
                UserStatus = false,
                Skills = new List<string>{"Singer","HTML","CSS","Dancer","Administration"},
                MotivationLetter = "I am very good at being admin",
            },

            new User
            {
                Username = "sharkboy05",
                FirstName = "Per",
                LastName = "Polle",
                Email = "PerPolle@sharkboy.no,",
                Skills = new List<string>{"Actor", "Worker", "Dancer", "Singer"},
                MotivationLetter = "I really need a job, I can do everything!",
                UserStatus = true
            },
            new User
            {
                Username = "ProperUser",
                FirstName = "Proper",
                LastName = "Userito",
                Email = "testing123@Proper.no",
                UserStatus = false,
                Skills = new List<string>{"Singer","Running","TypeScript","Dancer","Gaming"},
                MotivationLetter = "I am working so hard, please add me.",
            },
            new User
            {
                Username = "StrangerHere",
                FirstName = "Bob",
                LastName = "Forr",
                Email = "BobBobby@mail.no",
                UserStatus = true,
                Skills = new List<string>{"Writing","Sitting","Reading", "Comedian"},
                MotivationLetter = "Roses are red, violets are blue... ",
            },
        };
                 




/// <summary>
/// Gets the character seed data.
/// </summary>
/// <returns>The character seed data.</returns>
public static List<Project> GetProjectSeedData()
        {
            return _projects;
        }
    }
}
