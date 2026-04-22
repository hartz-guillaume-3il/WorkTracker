using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WorkTracker.MonApp.ViewModels;

/// <summary>
/// ViewModel du chronomètre — version CommunityToolkit.Mvvm.
///
/// Comparez ce fichier avec cor_ChronoViewModel.cs :
/// - [ObservableProperty] remplace le champ + propriété + OnPropertyChanged
/// - [RelayCommand] remplace l'instanciation manuelle de RelayCommand
/// - La classe hérite de ObservableObject (qui implémente INotifyPropertyChanged)
/// - Le mot-clé partial est obligatoire : le toolkit génère du code à la compilation
/// </summary>
public partial class ChronoViewModel : ObservableObject
{
    private readonly IDispatcherTimer _timer;
    private TimeSpan _elapsed = TimeSpan.Zero;

    // [ObservableProperty] génère automatiquement :
    //   - une propriété publique IsRunning avec get/set
    //   - l'appel à OnPropertyChanged dans le setter
    [ObservableProperty]
    private bool _isRunning;

    [ObservableProperty]
    private string _nomProjet = "Aucun projet sélectionné";

    // TempsEcoule et LabelBouton sont calculées — on les notifie manuellement
    // car leur valeur n'est pas stockée dans un champ simple.
    public string TempsEcoule => _elapsed.ToString(@"hh\:mm\:ss");
    public string LabelBouton => IsRunning ? "⏹  Arrêter" : "▶  Démarrer";

    public ChronoViewModel()
    {
        _timer = Application.Current!.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += OnTimerTick;
    }

    private void OnTimerTick(object? sender, EventArgs e)
    {
        _elapsed = _elapsed.Add(TimeSpan.FromSeconds(1));
        OnPropertyChanged(nameof(TempsEcoule));
    }

    // [RelayCommand] génère une propriété ToggleCommand de type IRelayCommand
    // et câble automatiquement la méthode Toggle comme cible.
    // Dans le XAML : Command="{Binding ToggleCommand}"
    [RelayCommand]
    private void Toggle()
    {
        if (IsRunning) { _timer.Stop(); IsRunning = false; }
        else { _timer.Start(); IsRunning = true; }
        // IsRunning est une propriété générée par [ObservableProperty]
        // Son setter appelle automatiquement OnPropertyChanged.
        // Mais LabelBouton dépend de IsRunning et n'est pas générée — on notifie manuellement.
        OnPropertyChanged(nameof(LabelBouton));
    }

    [RelayCommand]
    private void Reset()
    {
        _timer.Stop();
        _elapsed = TimeSpan.Zero;
        IsRunning = false;
        OnPropertyChanged(nameof(TempsEcoule));
        OnPropertyChanged(nameof(LabelBouton));
    }
}
