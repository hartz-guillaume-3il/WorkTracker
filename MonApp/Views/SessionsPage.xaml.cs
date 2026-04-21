using WorkTracker.MonApp.Models;
using WorkTracker.MonApp.Services;

namespace WorkTracker.MonApp.Views;

[QueryProperty(nameof(ProjectId), nameof(ProjectId))]
public partial class SessionsPage : ContentPage
{
    private int _projectId;
    public int ProjectId
    {
        set
        {
            _projectId = value;
            ChargerSessions();
        }
    }
    public SessionsPage()
    {
        InitializeComponent();
    }
    private void ChargerSessions()
    {
        if (cvSessions == null)
            return;

        cvSessions.ItemsSource = null;
        cvSessions.ItemsSource = SessionService.Instance.GetByProject(_projectId);
    }
    private async void OnAddSessionClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Information", "Ajout de session non implémenté dans ce TP.", "OK");
    }
}