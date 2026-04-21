using WorkTracker.MonApp.Views;

namespace WorkTracker.MonApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ProjectEditPage), typeof(ProjectEditPage));
        Routing.RegisterRoute(nameof(SessionsPage), typeof(SessionsPage));
    }
}