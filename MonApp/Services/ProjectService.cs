using System.Collections.ObjectModel;
using WorkTracker.MonApp.Models;

namespace WorkTracker.MonApp.Services;

/// <summary>
/// Service de gestion des projets — stockage en mémoire.
///
/// Ce service joue le rôle de couche d'accès aux données (repository).
/// Il expose une interface stable que les ViewModels utilisent
/// sans savoir si les données viennent de la mémoire, de SQLite ou d'un serveur.
///
/// En TP 4, cette classe sera remplacée (ou complétée) par une version
/// qui persiste les données dans SQLite — sans toucher aux ViewModels.
///
/// Pattern : Singleton simple via propriété statique.
/// (En production, on préférerait l'injection de dépendances — cf. MauiProgram.cs)
/// </summary>
public class ProjectService
{
    public static readonly ProjectService Instance = new();
    private readonly ObservableCollection<Project> _projects = new();
    private ProjectService()
    {
        Add(new Project { Name = "Site web", Description = "Refonte du site vitrine" });
        Add(new Project { Name = "API REST", Description = "Développement backend" });
        Add(new Project { Name = "Formation", Description = "Préparation des TPs MAUI" });
    }
    public IReadOnlyList<Project> GetAll()
    {
        return _projects;
    }
    public void Add(Project project)
    {
        project.Id = _projects.Any() ? _projects.Max(p => p.Id) + 1 : 1;
        _projects.Add(project);
    }
    public void Delete(Project project)
    {
        _projects.Remove(project);
    }
}