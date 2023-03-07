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
                    Id= 1,
                    Name = "Pirates of the Carribean",
                    Category = "Fantsy, Adventure, Action",
                    Progress = Progress.Founding,//In percentage
                    Description = "Joachim Rønning",
                    GitURL = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/C6AB0EDCE8F41882EBBB782B76DD4F05D7E360D7C3F23B4F6D02C24699B26105/scale?width=1200&aspectRatio=1.78&format=jpeg",
                    ImageURL = "https://www.youtube.com/watch?v=LkWQvzrv6gI" ,
                    NeededSkills = new List<string>{"Drawing","Programming","Hiking" }
                }
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
