using System.Media;

namespace DungeonWorld.Engine.Models
{
    public class Audio
    {
        public bool IsPlaying;
        public SoundPlayer Source;

        public Audio(string filepath)
        {
            IsPlaying = false;
            Source = new SoundPlayer(filepath);
        }
    }
}
