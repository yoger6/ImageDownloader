using System;
using System.Windows.Input;

namespace WebsiteImageDownload
{
    public class RelayCommand : ICommand
    {
        public Action<object> Action { get; set; }
        public Predicate<object> Predicate { get; set; }


        public RelayCommand(Action<object> action, Predicate<object> predicate) : this(action)
        {
            Predicate = predicate;
        }

        public RelayCommand(Action<object> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action), "Command Action must not be null.");

            Action = action;
        }


        public bool CanExecute(object parameter)
        {
            if (Predicate == null)
                return true;

            return Predicate(parameter);
        }

        public virtual void Execute(object parameter)
        {
            Action.Invoke(parameter);
        }   

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }
    }
}
