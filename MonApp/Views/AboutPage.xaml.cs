namespace WorkTracker.MonApp.Views;

/// <summary>
/// Code-behind de la page "À propos".
/// Remarque : ce fichier ne contient aucune logique métier.
/// Les données affichées sont toutes dans AboutViewModel.
/// </summary>
public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Ouvre le site web de l'école dans le navigateur du système.
    /// L'URL est récupérée depuis le ViewModel (via BindingContext), pas écrite en dur ici.
    /// </summary>
    private async void OnWebsiteClicked(object sender, EventArgs e)
    {
        if (BindingContext is MonApp.ViewModels.AboutViewModel vm)
            await Launcher.Default.OpenAsync(vm.WebsiteUrl);
    }
}
