using DungeonWorld.Engine.Interfaces;
using DungeonWorld.Engine.Models;

namespace DungeonWorld.Engine.Systems
{
    public static class SystemManager
    {
        static TypeList<ISystem> list;

        static SystemManager()
        {
            list = new TypeList<ISystem>();
        }

        public static void OnUpdate()
        {
            foreach (ISystem item in list)
            {
                item.OnUpdate();
            }
        }

        public static T Get<T>() where T : ISystem
        {
            return list.Get<T>();
        }

        public static void Add<T>() where T : ISystem, new()
        {
            list.Add<T>();
        }
    }
}
