namespace WorkTracker.MonApp.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }
    private void OnAjouterProjetClicked(object sender, EventArgs e)
    {
        if (BindingContext is MonApp.Models.ViewModels.HomeViewModel vm)
            vm.NombreProjets++;
    }

}
