namespace DungeonWorld.Engine.Interfaces
{
    public interface ICommand
    {
        public bool IsMatch(string[] args);
        public void Execute(string[] args);
    }
}
