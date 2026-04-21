using WorkTracker.MonApp.Models;

namespace WorkTracker.MonApp.Services;

/// <summary>
/// Repository de sessions — remplace SessionService (TP 3).
///
/// TODO Partie 4 : compléter les méthodes
/// </summary>
public class SessionRepository
{
    public static readonly SessionRepository Instance = new();

    private SessionRepository() { }

    private SQLite.SQLiteConnection Db => DatabaseService.Instance.Db;

    /// <summary>Retourne les sessions d'un projet, triées du plus récent au plus ancien.</summary>
    public IReadOnlyList<WorkSession> GetByProject(int projectId)
    {
        return Db.Table<WorkSession>()
                .Where(s => s.ProjectId == projectId)
                .OrderByDescending(s => s.StartTime)
                .ToList();
        
    }

    /// <summary>
    /// Retourne la durée totale travaillée sur un projet.
    /// </summary>
    public TimeSpan GetTotalDuration(int projectId)
    {
        // TODO Partie 5 :
        var sessions = GetByProject(projectId);
        var totalTicks = sessions.Sum(s => s.Duration.Ticks);
        return TimeSpan.FromTicks(totalTicks);
    }

    /// <summary>Insère une session. L'Id est affecté automatiquement.</summary>
    public void Add(WorkSession session)
    {
        Db.Insert(session);
        
    }

    /// <summary>Supprime une session.</summary>
    public void Delete(WorkSession session)
    {
        Db.Delete(session);
    }
}
