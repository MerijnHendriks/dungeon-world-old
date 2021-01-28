namespace DungeonWorld.Core.Models
{
    public class Attributes
    {
        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Intelligence;
        public int Wisdom;
        public int Charisma;

        public Attributes(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }

        // based on Dungeon World playbook
        public static int GetModifier(int attribute)
        {
            // -inf to 3
            if (attribute <= 3)
            {
                return -3;
            }

            // 4 to 5
            if (attribute <= 5)
            {
                return -2;
            }

            // 6 to 8
            if (attribute <= 8)
            {
                return -1;
            }

            // 9 to 12
            if (attribute <= 12)
            {
                return 0;
            }

            // 13 to 15
            if (attribute <= 15)
            {
                return 1;
            }

            // 16 to 17
            if (attribute <= 17)
            {
                return 2;
            }

            // 18 to +inf
            return 3;
        }
    }
}
