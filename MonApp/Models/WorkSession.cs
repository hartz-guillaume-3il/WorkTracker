namespace WorkTracker.MonApp.Models;

public class WorkSession
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Note { get; set; } = string.Empty;
    public string StartFormatted => StartTime.ToString("dd/MM/yyyy HH:mm");
    public TimeSpan Duration => EndTime - StartTime;
    public string DurationFormatted => $"{(int)Duration.TotalHours}h {Duration.Minutes:D2}min";
}