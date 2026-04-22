using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WorkTracker.MonApp.Models;
using WorkTracker.MonApp.Services;

namespace WorkTracker.MonApp.Models.ViewModels;
/// <summary>
/// ViewModel de la page d'ajout de projet.
/// Utilise CommunityToolkit.Mvvm (cf. TP 2, Partie 5).
/// </summary>
public partial class ProjectEditViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            // DisplayAlert n'est pas accessible depuis un ViewModel sans référence à la page.
            // On utilise Shell.Current.DisplayAlert, disponible globalement.
            await Shell.Current.DisplayAlertAsync(
                "Champ requis", "Le nom du projet ne peut pas être vide.", "OK");
            return;
        }

        var project = new Project
        {
            Name = Name.Trim(),
            Description = Description.Trim(),
        };

        ProjectRepository.Instance.Add(project);

        // ".." remonte d'un niveau dans la pile de navigation Shell —
        // équivalent du bouton Retour natif de chaque plateforme.
        await Shell.Current.GoToAsync("..");
    }

}
