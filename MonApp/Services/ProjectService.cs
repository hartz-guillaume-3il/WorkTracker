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
        // TODO Partie 3 : ajouter 2-3 projets de test ici
    }

    /// <summary>Retourne la liste complète des projets.</summary>
    public IReadOnlyList<Project> GetAll()
    {
        // TODO Partie 3 : retourner _projects
        throw new NotImplementedException();
    }

    /// <summary>Ajoute un projet et lui attribue un Id auto-incrémenté.</summary>
    public void Add(Project project)
    {
        // TODO Partie 3 : calculer l'Id et ajouter à _projects
        throw new NotImplementedException();
    }

    /// <summary>Supprime un projet de la liste.</summary>
    public void Delete(Project project)
    {
        // TODO Partie 3
        throw new NotImplementedException();
    }
}
