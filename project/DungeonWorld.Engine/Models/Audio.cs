using System.Media;

namespace DungeonWorld.Engine.Models
{
    public class Audio
    {
        private SoundPlayer source;
        public bool IsPlaying { get; private set; }

        public Audio(string filepath)
        {
            IsPlaying = false;
            source = new SoundPlayer(filepath);
            source.Load();
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

            IsPlaying = true;
        }

        public void Stop()
        {
            source.Stop();
            IsPlaying = false;
        }
    }
}
