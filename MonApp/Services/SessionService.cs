using WorkTracker.MonApp.Models;

namespace WorkTracker.MonApp.Services;

/// <summary>
/// Service de gestion des sessions de travail — stockage en mémoire.
/// Même pattern que ProjectService.
/// </summary>
public class SessionService
{
    public static readonly SessionService Instance = new();

    private readonly List<WorkSession> _sessions = new();
    private int _nextId = 1;

    private SessionService() { }

    /// <summary>Retourne toutes les sessions d'un projet donné.</summary>
    public IReadOnlyList<WorkSession> GetByProject(int projectId)
    {
        List<WorkSession> projectSessions = new();

        projectSessions.AddRange(_sessions.Where(s => s.ProjectId == projectId));   

        return projectSessions;
    }

    /// <summary>Ajoute une session et lui attribue un Id.</summary>
    public void Add(WorkSession session)
    {
        // TODO Partie 4 : affecter _nextId, incrémenter, ajouter à _sessions
        session.Id = _nextId;
        _nextId++;
        _sessions.Add(session);
    }

    public void Delete(WorkSession session) => _sessions.Remove(session);
}
