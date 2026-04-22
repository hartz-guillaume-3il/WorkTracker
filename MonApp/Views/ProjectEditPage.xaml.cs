using WorkTracker.MonApp.Models.ViewModels;

namespace WorkTracker.MonApp.Views;

public partial class ProjectEditPage : ContentPage
{
    public ProjectEditPage()
    {
        InitializeComponent();
        // TODO Partie 3.2 : affecter BindingContext = new ProjectEditViewModel();
        BindingContext = new ProjectEditViewModel();
    }
}
