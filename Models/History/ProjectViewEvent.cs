namespace lagalt_web_api.Models.History
{
    public class ProjectViewEvent : ProjectEvent
    {
        public override string Name { get => $"{DateTime.ToShortDateString}: Viewed project '{Project.Name}' at {DateTime.ToShortTimeString}.";   }
        public override string Description { get => $"You viewed a {Project.Category.ToString()} project called {Project.Name}.";   }
    }
}
