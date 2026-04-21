using WorkTracker.MonApp.Models;
using WorkTracker.MonApp.Services;

namespace WorkTracker.MonApp.Views;

public partial class ProjectsPage : ContentPage
{
    public ProjectsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        cvProjets.ItemsSource = ProjectService.Instance.GetAll();
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ProjectEditPage));
    }

    private async void OnProjectSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Project project)
            return;

        cvProjets.SelectedItem = null;

        await Shell.Current.GoToAsync(
            $"{nameof(SessionsPage)}?{nameof(SessionsPage.ProjectId)}={project.Id}");
    }
}