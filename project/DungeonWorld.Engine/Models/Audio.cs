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
            source.
        }

        public void Play(bool loop)
        {
            if (loop)
            {
                source.PlayLooping();
            }
            else
            {
                source.Play();
            }
        }

        public void Stop()
        {
            source.Stop();
        }
    }
}
