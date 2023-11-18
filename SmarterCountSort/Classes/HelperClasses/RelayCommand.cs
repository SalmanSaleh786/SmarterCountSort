using System;
using System.Windows.Input;

namespace AdvancedAlgo_Assignment1.Classes.HelperClasses
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality
    /// to other objects by invoking delegates.
    /// The default return value for the CanExecute method is 'true'.
    /// RaiseCanExecuteChanged needs to be called whenever
    /// CanExecute is expected to return a different value.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> action) { _action = action; _canExecute = null; }
        public RelayCommand(Action<object> action, Predicate<object> canExecute) { _action = action; _canExecute = canExecute; }
        public void Execute(object o) => _action(o);
        public bool CanExecute(object o) => _canExecute == null ? true : _canExecute(o);
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}

