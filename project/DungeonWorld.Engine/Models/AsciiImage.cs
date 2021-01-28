namespace DungeonWorld.Engine.Models
{
    public class AsciiImage
    {
        public string[,] Text;
        public TextStyle[,] Colors;

        public AsciiImage(int width, int height)
        {
            Text = new string[height, width];
            Colors = new TextStyle[height, width];
        }
    }
}
