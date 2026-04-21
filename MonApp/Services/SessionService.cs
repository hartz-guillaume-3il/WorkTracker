using WorkTracker.MonApp.Models;

namespace WorkTracker.MonApp.Services;

public class SessionService
{
    public static readonly SessionService Instance = new();

    private readonly List<WorkSession> _sessions = new();
    private int _nextId = 1;

    private SessionService()
    {
        Add(new WorkSession
        {
            ProjectId = 1,
            StartTime = DateTime.Now.AddDays(-2).AddHours(-3),
            EndTime = DateTime.Now.AddDays(-2).AddHours(-1),
            Note = "Maquettage"
        });

        Add(new WorkSession
        {
            ProjectId = 1,
            StartTime = DateTime.Now.AddDays(-1).AddHours(-4),
            EndTime = DateTime.Now.AddDays(-1).AddHours(-2),
            Note = "Développement"
        });

        Add(new WorkSession
        {
            ProjectId = 2,
            StartTime = DateTime.Now.AddHours(-5),
            EndTime = DateTime.Now.AddHours(-3),
            Note = "Tests API"
        });
    }

    public List<WorkSession> GetByProject(int projectId)
    {
        return _sessions
            .Where(s => s.ProjectId == projectId)
            .OrderByDescending(s => s.StartTime)
            .ToList();
    }

    public void Add(WorkSession session)
    {
        session.Id = _nextId++;
        _sessions.Add(session);
    }
}