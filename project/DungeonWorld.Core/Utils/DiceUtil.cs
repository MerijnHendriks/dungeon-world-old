using System;

using DungeonWorld.Core.Models;

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

        private static int Roll(int count, int sides, int modifier)
        {
            int result = 0;

            for (int i = 0; i < count; i++)
            {
                result += random.Next(1, sides + 1);
            }

            return result + modifier;
        }

        public static int Roll(string input = "2d6", Stats stats = null)
        {
            // get modifier
            string[] dice = (input.Contains('+')) ? input.Split('+') : new string[1] { input };
            int modifier = 0;

            if (dice.Length > 1)
            {
                modifier = stats.GetModifier(dice[1]);
            }

            // get dice
            int count = Convert.ToInt32(dice[0].Split('d')[0]);
            int sides = Convert.ToInt32(dice[0].Split('d')[1]);

            return Roll(count, sides, modifier);
        }

        // based on Dungeon World playbook
        public static DiceResult GetResult(Stats stats)
        {
            int result = Roll("2d6", stats);

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

            // 2 to 6
            stats.Experience++;
            return DiceResult.Failure;
        }

        // based on Dungeon World playbook
        public static DiceResult GetResult(Stats stats, string attribute = "")
        {
            int result = Roll($"2d6+{attribute}", stats);

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

            // 2 to 6
            stats.Experience++;
            return DiceResult.Failure;
        }
    }
}
