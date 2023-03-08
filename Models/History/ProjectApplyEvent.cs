namespace lagalt_web_api.Models.History
{
    public class ProjecApplyEvent : ProjectEvent
    {
        public override string Name { get => $"{DateTime.ToShortDateString}: Applied to project '{Project.Name}' at {DateTime.ToShortTimeString}."; }
        public override string Description { get => $"You applied to a {Project.Category.ToString()} project called {Project.Name}."; }
    }
}
