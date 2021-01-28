using System;
using System.Collections.Generic;
using DungeonWorld.Engine.Interfaces;
using DungeonWorld.Engine.Models;

namespace App.Core.System
{
    public class ViewSystem : ISystem
    {
        private TypeList<IView> list;
        private Stack<IView> previous;
        private IView current;

        public ViewSystem()
        {
            list = new TypeList<IView>();
            previous = new Stack<IView>();
            current = null;
        }

        public void OnUpdate()
        {
            // required by ISystem
        }

        public T Get<T>() where T : IView
        {
            return list.Get<T>();
        }

        public void Add<T>() where T : IView, new()
        {
            list.Add<T>();
        }

        private void DrawView(IView view)
        {
            Console.Clear();
            view.Draw();
        }

        public void SetView<T>() where T : IView
        {
            if (list.Contains<T>())
            {
                current = Get<T>();
            }

            if (current != null && previous.Count > 0 && previous.Peek() != current)
            {
                previous.Push(current);
            }

            DrawView(current);
        }

        public void ResetView()
        {
            DrawView(current);
        }

        public void RevertView()
        {
            if (previous.Count > 0)
            {
                DrawView(previous.Pop());
            }
            else
            {
                ResetView();
            }
        }
    }
}
