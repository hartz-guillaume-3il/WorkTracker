using WorkTracker.MonApp.Models.ViewModels;

namespace WorkTracker.MonApp.Views;

/// <summary>
/// Code-behind de la page chronomètre.
///
/// Remarque : les méthodes OnToggleClicked et OnResetClicked appellent
/// directement le ViewModel via BindingContext. C'est acceptable pour
/// l'instant. Dans la Partie 4, elles seront remplacées par des ICommand
/// — le code-behind ne contiendra alors plus aucune logique.
/// </summary>
public partial class ChronoPage : ContentPage
{
    public ChronoPage()
    {
        InitializeComponent();
        // TODO Partie 2 : instancier ChronoViewModel et l'affecter à BindingContext
        var vm = new ChronoViewModel();
        BindingContext = vm;
    }

}
