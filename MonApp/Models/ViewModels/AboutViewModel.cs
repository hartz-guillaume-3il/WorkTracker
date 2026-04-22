namespace WorkTracker.MonApp.Models.ViewModels;

/// <summary>
/// ViewModel de la page "À propos".
/// Contient uniquement des propriétés en lecture seule (pas de set).
/// Le XAML accède à ces propriétés via {Binding NomDeLaPropriete}.
/// </summary>
public class AboutViewModel
{
    public string AppName => "WorkTracker";

    public string Version => $"v{AppInfo.VersionString}";

    public string Description =>
        "Application de suivi du temps de travail par projet.\n" +
        "Développée avec .NET MAUI dans le cadre du module développement mobile.";

    public string WebsiteUrl => "https://www.3il-ingenieurs.fr/";
}
