using DungeonWorld.Engine.Interfaces;

namespace DungeonWorld.App.Commands
{
    public class ExitCommand : ICommand
    {
        public bool Executing { get; private set; }

        public ExitCommand()
        {
            Executing = false;
        }

        public bool IsMatch(string[] args)
        {
            return args[0] == "exit";
        }

        public void Execute(string[] args)
        {
            Executing = true;
        }
    }
}
