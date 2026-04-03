using System;
using System.Windows.Input;

namespace WorkTracker.MonApp.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;

        // Constructeur
        public RelayCommand(Action execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute();
        }

        public event EventHandler? CanExecuteChanged;
    }
}