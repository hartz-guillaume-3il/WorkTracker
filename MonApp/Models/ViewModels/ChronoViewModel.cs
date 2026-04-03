using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Dispatching;
using Microsoft.Maui.Controls;

namespace WorkTracker.MonApp.ViewModels;

// IMPORTANT : La classe doit être "partial" pour que le Toolkit puisse générer le code manquant
public partial class ChronoViewModel : ObservableObject
{
    // ── Timer ────────────────────────────────────────────────────────────────
    private readonly IDispatcherTimer _timer;
    private TimeSpan _elapsed = TimeSpan.Zero;

    // ── Propriétés (Générées automatiquement par le Toolkit) ─────────────────

    [ObservableProperty]
    private string _nomProjet = "Aucun projet sélectionné";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(LabelBouton))] // Magie : Notifie que LabelBouton change quand _isRunning change !
    private bool _isRunning;

    // ── Propriétés calculées ─────────────────────────────────────────────────

    public string TempsEcoule => _elapsed.ToString(@"hh\:mm\:ss");

    public string LabelBouton => IsRunning ? "🛑  Arrêter" : "▶  Démarrer";

    // ── Constructeur ─────────────────────────────────────────────────────────
    public ChronoViewModel()
    {
        _timer = Application.Current!.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += OnTimerTick;
    }

    // ── Logique ─────────────────────────────────────────────────────────────

    private void OnTimerTick(object? sender, EventArgs e)
    {
        _elapsed = _elapsed.Add(TimeSpan.FromSeconds(1));
        // On notifie manuellement TempsEcoule car il dépend d'une variable qui n'est pas un ObservableProperty
        OnPropertyChanged(nameof(TempsEcoule));
    }

    // Le Toolkit va générer automatiquement une ICommand appelée "DemarrerCommand"
    [RelayCommand]
    private void Demarrer()
    {
        if (IsRunning) return;
        _timer.Start();
        IsRunning = true; // Modifie _isRunning et notifie IsRunning et LabelBouton
    }

    // Génère une ICommand appelée "ArreterCommand"
    [RelayCommand]
    private void Arreter()
    {
        if (!IsRunning) return;
        _timer.Stop();
        IsRunning = false;
    }

    // Génère une ICommand appelée "ResetCommand"
    [RelayCommand]
    private void Reset()
    {
        _timer.Stop();
        _elapsed = TimeSpan.Zero;
        IsRunning = false;
        OnPropertyChanged(nameof(TempsEcoule));
    }

    // Génère une ICommand appelée "ToggleCommand"
    [RelayCommand]
    private void Toggle()
    {
        if (IsRunning)
            Arreter();
        else
            Demarrer();
    }
}