using SQLite;
using WorkTracker.MonApp.Models;

namespace WorkTracker.MonApp.Services;

/// <summary>
/// Repository de projets — remplace ProjectService (TP 3).
///
/// Cette classe a exactement la même interface publique que ProjectService :
/// GetAll(), Add(), Delete().
/// Les ViewModels et les pages ne changent donc pas — seul le service change.
/// C'est le bénéfice direct de la séparation introduite en TP 3.
///
/// TODO Partie 3 : compléter les méthodes en utilisant DatabaseService.Instance.Db
/// </summary>
public class ProjectRepository
{
    public static readonly ProjectRepository Instance = new();

    private ProjectRepository() { }

    private SQLiteConnection Db => DatabaseService.Instance.Db;

    public IReadOnlyList<Project> GetAll()
        => Db.Table<Project>().OrderBy(p => p.Name).ToList();

    public void Add(Project project) => Db.Insert(project);
    // Après Insert, project.Id est automatiquement mis à jour par sqlite-net-pcl

    public void Update(Project project) => Db.Update(project);

    public void Delete(Project project)
    {
        // Supprimer d'abord les sessions (intégrité référentielle manuelle)
        Db.Execute("DELETE FROM Sessions WHERE ProjectId = ?", project.Id);
        Db.Delete(project);
    }

}
