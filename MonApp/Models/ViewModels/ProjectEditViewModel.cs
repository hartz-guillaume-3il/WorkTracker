using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WorkTracker.MonApp.Models;
using WorkTracker.MonApp.Services;
using static Android.Util.EventLogTags;
using static Java.Util.Jar.Attributes;

namespace WorkTracker.MonApp.ViewModels;

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
            await Shell.Current.DisplayAlert("Champ requis", "Le nom du projet ne peut pas être vide.", "OK");
            return;
        }
        var project = new Project
        { Name = Name.Trim(), Description = Description.Trim()  };
        ProjectService.Instance.Add(project);
        await Shell.Current.GoToAsync(".."); // revient à la page précédente
    }