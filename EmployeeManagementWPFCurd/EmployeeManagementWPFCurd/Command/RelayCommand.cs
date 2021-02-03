using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeManagementWPFCurd.Command
{
    class RelayCommand : ICommand
    {
        private Func<bool> _canExecute;
        private Action _execute;

        public RelayCommand(Func<bool> canExecute,Action execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }


        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }

        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
        _execute();
        }
    }
}
