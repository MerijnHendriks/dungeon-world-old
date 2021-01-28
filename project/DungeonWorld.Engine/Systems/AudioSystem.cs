using System;
using System.Collections.Generic;
using System.IO;
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

            FileInfo[] files = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "assets/audio/")).GetFiles();

            foreach (FileInfo file in files)
            {
                Import(file.Name, file.FullName);
            }
        }

        public void OnUpdate()
        {
            // ISystem
        }

        public void Import(string name, string filepath)
        {
            list[name] = new Audio(filepath);
        }

        public void Play(string name, bool loop)
        {
            list[name].Play(loop);
        }

        public void Stop(string name)
        {
            list[name].Stop();
        }

        public void StopAll()
        {
            foreach (KeyValuePair<string, Audio> item in list)
            {
                item.Value.Stop();
            }
        }
    }
}
