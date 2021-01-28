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
        private static Random random;

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

        // based on Dungeon World playbook
        public static DiceResult GetResult()
        {
            int result = Roll("2d6");

            // 10 to 12
            if (result > 9)
            {
                return DiceResult.Success;
            }

            // 7 to 9
            if (result > 6)
            {
                return DiceResult.Partial;
            }

            // 1 to 6
            return DiceResult.Failure;
        }
    }
}
