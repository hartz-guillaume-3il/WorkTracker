using SQLite;

namespace WorkTracker.MonApp.Models
{
    [Table("Projects")]
    public class Project
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = "#005067";

        [Ignore]
        public string Initials => Name?.Length >= 2 ? Name.Substring(0, 2).ToUpper() : "??";
    }
}