namespace lagalt_web_api.Models.History
{
    public class ProjectContributeEvent : ProjectEvent
    {
        public override string Name { get => $"{DateTime.ToShortDateString}: Contributed to project '{Project.Name}' at {DateTime.ToShortTimeString}."; }
        public override string Description { get => $"You contributed to a {Project.Category.ToString()} project called {Project.Name}."; } 
    }
}
