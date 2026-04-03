// AppShell.xaml.cs
// Les routes des pages de navigation (push) sont enregistrées ici,
// au démarrage de l'application, avant tout GoToAsync.

namespace WorkTracker;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // TODO Partie 2 : enregistrer les routes vers ProjectEditPage et SessionsPage
        Routing.RegisterRoute(nameof(ProjectEditPage), typeof(ProjectEditPage));
        Routing.RegisterRoute(nameof(SessionsPage), typeof(SessionsPage));
    }
}
