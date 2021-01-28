namespace DungeonWorld.Engine.Models
{
    public enum TextStyles
    {
        None = 0,
        Bold,
        Faint,
        Italic,
        Underlined,
        Inverse,
        Strikethrough
    }

    public class TextStyle
    {
        public string ColorFront;
        public string ColorBack;
        public TextStyles Style;

        public TextStyle()
        {
            ColorFront = "#000000";
            ColorBack = "#FFFFFF";
            Style = TextStyles.None;
        }

        public TextStyle(string colorFront, string colorBack, TextStyles style)
        {
            ColorFront = colorFront;
            ColorBack = colorBack;
            Style = style;
        }
    }
}
