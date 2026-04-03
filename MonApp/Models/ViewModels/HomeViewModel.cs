using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WorkTracker.MonApp.Models.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private int _nombreProjets = 3;
        public string Titre => "WorkTracker";
        public string Message => "Sélectionnez un projet pour commencer.";
        public int NombreProjets
        {
            get => _nombreProjets;
            set
            {
                if (_nombreProjets != value)
                {
                    _nombreProjets = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public string ResumeProjets => NombreProjets == 1 ? "1 projet actif" : $"{NombreProjets} projets actifs";

    }
}