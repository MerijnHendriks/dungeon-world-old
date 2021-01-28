using System.Collections;
using System.Collections.Generic;

namespace DungeonWorld.Engine.Models
{
    public class TypeList<T1> : IEnumerable<T1>
    {
        private List<T1> list;

        public int Count
        {
            get { return list.Count; }
        }

        public TypeList()
        {
            list = new List<T1>();
        }

        public IEnumerator<T1> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public T2 Get<T2>() where T2 : T1
        {
            foreach (T1 item in list)
            {
                if (item.GetType() == typeof(T2))
                {
                    return (T2)item;
                }
            }

            return default;
        }

        public int IndexOf<T2>() where T2 : T1
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetType() == typeof(T2))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains<T2>() where T2 : T1
        {
            return (Get<T2>() != null);
        }

        public void Insert<T2>(int index) where T2 : T1, new()
        {
            if (!Contains<T2>())
            {
                list.Insert(index, new T2());
            }
        }

        public void Add<T2>() where T2 : T1, new()
        {
            if (!Contains<T2>())
            {
                list.Add(new T2());
            }
        }

        public void Remove<T2>() where T2 : T1
        {
            if (Contains<T2>())
            {
                list.RemoveAt(IndexOf<T2>());
            }
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public void Clear()
        {
            list.Clear();
        }
    }
}
