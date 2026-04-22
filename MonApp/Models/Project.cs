using SQLite;

namespace WorkTracker.MonApp.Models;

[Table("Projects")]
public class Project
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Color { get; set; } = "#005067";

    // [Ignore] est obligatoire : sqlite-net-pcl essaierait de créer
    // une colonne "Initials" dans la table, mais sans setter il ne
    // peut pas y écrire → exception à la création de la table.
    [Ignore]
    public string Initials => Name?.Length >= 2
        ? Name.Substring(0, 2).ToUpper()
        : "??";
}
