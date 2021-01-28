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
            // 18 to 20
            if (attribute > 17)
            {
                return 3;
            }

            // 15 to 17
            if (attribute > 15)
            {
                return 2;
            }
            
            // 13 to 14
            if (attribute > 12)
            {
                return 1;
            }

            // 9 to 12
            if (attribute > 8)
            {
                return 1;
            }

            // 7 to 8
            if (attribute > 8)
            {
                return -1;
            }

            // 4 to 6
            if (attribute > 3)
            {
                return -2;
            }

            // 3 to 1
            return -3;
        }
    }
}
