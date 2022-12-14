using System;
using WpfAppForEmployees.Commands.Base;

namespace WpfAppForEmployees.Commands
{
    internal class ActionCommand : BaseCommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public ActionCommand(Action<object> execute, Func<object, bool> can = null!)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = can;
        }

        public override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter!) ?? true;

        public override void Execute(object? parameter) => _execute(parameter!);
    }
}
