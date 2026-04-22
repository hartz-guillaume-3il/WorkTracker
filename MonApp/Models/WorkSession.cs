using SQLite;

namespace WorkTracker.MonApp.Models;

[Table("Sessions")]
public class WorkSession
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Note { get; set; } = string.Empty;

    // Propriétés calculées : [Ignore] obligatoire car elles n'ont pas de setter
    // et sqlite-net-pcl ne saurait pas les lire depuis la base.
    [Ignore]
    public TimeSpan Duration => EndTime - StartTime;

    [Ignore]
    public string DurationFormatted
    {
        get
        {
            if (Duration.TotalHours >= 1)
                return $"{(int)Duration.TotalHours}h {Duration.Minutes:00}min";
            return $"{Duration.Minutes}min";
        }
    }

    [Ignore]
    public string StartFormatted => StartTime.ToString("dd/MM/yyyy HH:mm");
}
