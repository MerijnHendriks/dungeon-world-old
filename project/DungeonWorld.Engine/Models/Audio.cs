using System.Media;

namespace DungeonWorld.Engine.Models
{
    public class Audio
    {
        SoundPlayer source;

        public Audio(string filepath)
        {
            source = new SoundPlayer(filepath);
            source.Load();
        }

        public void Play()
        {
            source.Play();
        }

        public void Stop()
        {
            source.Stop();
        }
    }
}
