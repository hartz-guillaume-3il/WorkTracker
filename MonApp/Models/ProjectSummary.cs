using WorkTracker.MonApp.Models;

namespace WorkTracker.MonApp.Models;

/// <summary>
/// DTO d'affichage : Project + durée totale agrégée.
/// Construit dans OnAppearing de ProjectsPage, jamais persisté en base.
/// </summary>
public class ProjectSummary
{
    public Project Project { get; set; } = null!;
    public TimeSpan TotalDuration { get; set; }

    // Propriétés déléguées — permettent le {Binding} sans "Project.Name" en XAML
    public int Id => Project.Id;
    public string Name => Project.Name;
    public string Description => Project.Description;
    public string Initials => Project.Initials;

    public string TotalFormatted
    {
        get
        {
            if (TotalDuration == TimeSpan.Zero) return "—";
            if (TotalDuration.TotalHours >= 1)
                return $"{(int)TotalDuration.TotalHours}h {TotalDuration.Minutes:00}min";
            return $"{TotalDuration.Minutes}min";
        }
    }
}
