using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WorkTracker.MonApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public String Titre { get; } = "WordTracker";
        public String Message { get; } = "Sélectionnez un projet pour commencer.";

        private int _nombreProjets = 3;
        public int NombreProjets
        {
            get => _nombreProjets;
            set
            {
                if (_nombreProjets == value) return;


                _nombreProjets = value;

                OnPropertyChanged("NombreProjets");
                OnPropertyChanged("ResumeProjets");
            }
        }


        public String ResumeProjets {
            get
            {               
                return NombreProjets == 1 ? "1 projet en cours" : $"{NombreProjets} projets en cours";
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
