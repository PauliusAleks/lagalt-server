namespace lagalt_back_end.Models
{
    public class Application
    {
        public int Id { get; set; }
        public State State { get; set; }
        public string MotivationLetter { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
    }

    public enum State
    {
        Pending,
        Accepted,
        Rejected
    }
}
