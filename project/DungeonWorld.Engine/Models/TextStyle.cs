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
        public RGB ColorFront;
        public RGB ColorBack;
        public TextStyles Style;

        public TextStyle()
        {
            ColorFront = new RGB(0, 0, 0);
            ColorBack = new RGB(255, 255, 255);
            Style = TextStyles.None;
        }

        public TextStyle(RGB colorFront, RGB colorBack, TextStyles style)
        {
            ColorFront = colorFront;
            ColorBack = colorBack;
            Style = style;
        }
    }
}
