namespace DungeonWorld.Engine.Models
{
    public class BorderStyle
    {
        public string Horizontal;
        public string Vertical;
        public string LeftTop;
        public string LeftBottom;
        public string RightTop;
        public string RightBottom;

        public BorderStyle()
        {
            Horizontal = "─";
            Vertical = "│";
            LeftTop = "┌";
            LeftBottom = "└";
            RightTop = "┐";
            RightBottom = "┘";
        }

        public BorderStyle(string horizontal, string vertical, string leftTop, string leftBottom, string rightTop, string rightBottom)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            LeftTop = leftTop;
            LeftBottom = leftBottom;
            RightTop = rightTop;
            RightBottom = rightBottom;
        }
    }
}
