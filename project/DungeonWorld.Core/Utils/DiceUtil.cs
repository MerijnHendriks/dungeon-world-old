using System;

namespace DungeonWorld.Core.Utils
{
    public enum DiceResult
    {
        Failure = 0,
        Partial,
        Success
    }

    public static class DiceUtil
    {
        static Random random;

        static DiceUtil()
        {
            random = new Random();
        }

        public static int Roll(string dice)
        {
            string[] split = dice.Split('d');
            int count = Convert.ToInt32(split[0]);
            int sides = Convert.ToInt32(split[1]);
            int result = 0;

            for (int i = 0; i < count; i++)
            {
                result += random.Next(1, sides + 1);
            }

            return result;
        }
    }
}
