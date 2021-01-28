using DungeonWorld.Engine.Interfaces;
using DungeonWorld.Engine.Models;
using DungeonWorld.Engine.Utils;
using DungeonWorld.Core.Utils;

namespace DungeonWorld.App.Views
{
    public class TestView : IView
    {
        TextStyle style;
        Box border;
        Coord text;

        public TestView()
        {
            style = new TextStyle("#c8c864", "#64643c", TextStyles.Underlined);
            border = new Box(10, 5, 50, 20);
            text = new Coord(20, 20);
        }

        public void Draw()
        {
            ConsoleUtil.WriteBorder(border);
            ConsoleUtil.WritePosition($"{DiceUtil.GetResult()}", text, style);
        }
    }
}
