using System;
using DungeonWorld.Engine.Interfaces;
using DungeonWorld.Engine.Models;

namespace DungeonWorld.Engine.Systems
{
    public class CommandSystem : ISystem
    {
        private TypeList<ICommand> list;

        public CommandSystem()
        {
            list = new TypeList<ICommand>();
        }

        public void OnUpdate()
        {
            string[] args = Console.ReadLine().ToLower().Split(' ');

            foreach (ICommand item in list)
            {
                if (item.IsMatch(args))
                {
                    item.Execute(args);
                    return;
                }
            }

            Console.WriteLine($"{args[0]} is not recognized as an command");
        }

        public T Get<T>() where T : ICommand
        {
            return list.Get<T>();
        }

        public void Add<T>() where T : ICommand, new()
        {
            list.Add<T>();
        }
    }
}
