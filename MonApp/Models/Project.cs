namespace WorkTracker.MonApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = "#005067";
        public string Initials => Name?.Length >= 2
            ? Name.Substring(0, 2).ToUpper()
            : "??";
    }
}