using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WorkTracker.MonApp.Models;
using WorkTracker.MonApp.Services;

namespace WorkTracker.MonApp.ViewModels;

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
            await Shell.Current.DisplayAlert( "Champ requis", "Le nom du projet ne peut pas être vide.", "OK");
            return;
        }
        var project = new Project
        {
            Name = Name.Trim(),
            Description = Description.Trim()
        };
        ProjectService.Instance.Add(project);
        await Shell.Current.GoToAsync("..");
    }
}