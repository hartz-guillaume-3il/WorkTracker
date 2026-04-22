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
    // Instance unique partagée entre tous les ViewModels
    public static readonly ProjectService Instance = new();

    private readonly ObservableCollection<Project> _projects = new();

    private ProjectService()
    {
        _projects.Add(new Project { Id = 1, Name = "Site web", Description = "Refonte du site vitrine" });
        _projects.Add(new Project { Id = 2, Name = "API REST", Description = "Développement backend" });
        _projects.Add(new Project { Id = 3, Name = "Formation", Description = "Préparation des TPs MAUI" });
        _projects.Add(new Project { Id = 4, Name = "Formation", Description = "Cours de chant" });

    }

    /// <summary>Retourne la liste complète des projets.</summary>
    public IReadOnlyList<Project> GetAll()
    {
        return _projects;
    }

    /// <summary>Ajoute un projet et lui attribue un Id auto-incrémenté.</summary>
    public void Add(Project project)
    {
        var id = -1;
        foreach (Project p in _projects)
        {
            if (p.Id >id) id=p.Id;
        }
        project.Id = id+1;
        _projects.Add(project);

    }

    /// <summary>Supprime un projet de la liste.</summary>
    public void Delete(Project project)
    {
        _projects.Remove(project);
    }
}
