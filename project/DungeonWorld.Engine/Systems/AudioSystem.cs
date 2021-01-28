using System.Collections.Generic;
using DungeonWorld.Engine.Interfaces;
using DungeonWorld.Engine.Models;

namespace DungeonWorld.Engine.Systems
{
    public class AudioSystem : ISystem
    {
        Dictionary<string, Audio> list;

        public AudioSystem()
        {
            list = new Dictionary<string, Audio>();
        }

        public void OnUpdate()
        {
            // ISystem
        }

        public Audio Get(string name)
        {
            return list[name];
        }

        public void Add(string name, string filepath)
        {
            list[name] = new Audio(filepath);
            list[name].Source.Load();
        }

        public void Play(string name, bool loop)
        {
            if (loop)
            {
                list[name].Source.PlayLooping();
            }
            else
            {
                list[name].Source.Play();
            }

            list[name].IsPlaying = true;
        }

        public void Stop(string name)
        {
            list[name].Source.Stop();
            list[name].IsPlaying = false;
        }

        public bool IsPlaying(string name)
        {
            return list[name].IsPlaying;
        }
    }
}
