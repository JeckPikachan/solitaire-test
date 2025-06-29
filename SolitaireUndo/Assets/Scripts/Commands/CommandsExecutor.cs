using System.Collections.Generic;

namespace SolitaireUndo.Commands
{
    public class CommandsExecutor
    {
        public static CommandsExecutor Instance => _instance ??= new CommandsExecutor();

        private static CommandsExecutor _instance;
        
        private readonly Stack<ICommand> _commands = new();

        private CommandsExecutor()
        {
        }

        public void Execute(ICommand command)
        {
            _commands.Push(command);
            command.Do();
        }

        public void Undo()
        {
            if (_commands.Count > 0)
            {
                ICommand command = _commands.Pop();
                command.Undo();
            }
        }
    }
}