// TODO : ajouter using SQLite;

using SQLite;

using WorkTracker.MonApp.Models;

namespace WorkTracker.MonApp.Services;

/// <summary>
/// Service central de gestion de la connexion SQLite.
///
/// Une seule connexion partagée entre tous les repositories :
/// ouvrir et fermer une connexion est coûteux, la réutiliser est
/// la pratique recommandée avec sqlite-net-pcl.
///
/// TODO Partie 3 : compléter le constructeur
/// </summary>
public class DatabaseService
{
    public static readonly DatabaseService Instance = new();

    // TODO Partie 3 : déclarer private readonly SQLiteConnection _db;
    private readonly SQLiteConnection _db;

    private DatabaseService()
    {
        // TODO Partie 3 :
        // 1. Calculer le chemin du fichier avec
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "worktracker.db");
        // 2. Initialiser _db = new SQLiteConnection(dbPath)
        _db = new SQLiteConnection(dbPath);
        // 3. Créer les tables avec _db.CreateTable<Project>()
        _db.CreateTable<Project>();
        _db.CreateTable<WorkSession>();

        //    et _db.CreateTable<WorkSession>()
        //    (CreateTable ne fait rien si la table existe déjà)
    }

    // TODO Partie 3 : exposer la connexion via une propriété en lecture seule
    public SQLiteConnection Db => _db;
}
