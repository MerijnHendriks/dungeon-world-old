namespace DungeonWorld.Core.Models
{
    public class Stats
    {
        public int Level;
        public int Experience;
        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Intelligence;
        public int Wisdom;
        public int Charisma;

        public Stats(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }

        // based on Dungeon World playbook
        public int GetModifier(string attribute)
        {
            int value = 0;

            switch (attribute)
            {
                case "str":
                    value = Strength;
                    break;

                case "con":
                    value = Constitution;
                    break;

                case "dex":
                    value = Dexterity;
                    break;

                case "wis":
                    value = Wisdom;
                    break;

                case "int":
                    value = Intelligence;
                    break;

                case "cha":
                    value = Charisma;
                    break;
            }

            // 18 to 20
            if (value > 17)
            {
                return 3;
            }

            // 15 to 17
            if (value > 15)
            {
                return 2;
            }
            
            // 13 to 14
            if (value > 12)
            {
                return 1;
            }

            // 9 to 12
            if (value > 8)
            {
                return 1;
            }

            // 7 to 8
            if (value > 8)
            {
                return -1;
            }

            // 4 to 6
            if (value > 3)
            {
                return -2;
            }

            // 3 to 1
            return -3;
        }
    }
}
