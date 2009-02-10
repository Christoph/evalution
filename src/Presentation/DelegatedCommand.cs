using System;
using System.Windows.Input;

namespace Presentation
{
    public class DelegatedCommand : ICommand
    {
        private readonly Action<object> mExecute;

        private readonly Predicate<object> mCanExecute;

        public DelegatedCommand(Action<object> execute, Predicate<object> canExecute)
        {
            mExecute = execute;
            mCanExecute = canExecute;
        }

        public DelegatedCommand(Action<object> execute)
            : this(execute, p => true)
        {
            
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command.  If the command does not require data to be passed, this object can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            mExecute(parameter);
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        /// <param name="parameter">
        /// Data used by the command.  If the command does not require data to be passed, this object can be set to null.
        /// </param>
        public bool CanExecute(object parameter)
        {
            return mCanExecute(parameter);
        }
    }
}