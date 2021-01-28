namespace DungeonWorld.Core.Models
{
    public enum Attribute
    {
        Strength = 0,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }

    public class Attributes
    {
        int[] attributes;

        public Attributes(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            attributes = new int[6] { strength, dexterity, constitution, intelligence, wisdom, charisma };
        }

        int GetAttribute(Attribute attribute)
        {
            return attributes[(int)attribute];
        }

        int GetModifier(int attribute)
        {
            // -inf to 3
            if (attribute <= 3)
                return -3;

            // 4 to 5
            if (attribute <= 5)
                return -2;

            // 6 to 8
            if (attribute <= 8)
                return -1;

            // 9 to 12
            if (attribute <= 12)
                return 0;

            // 13 to 15
            if (attribute <= 15)
                return 1;

            // 16 to 17
            if (attribute <= 17)
                return 2;

            // 18 to +inf
            return 3;
        }

        public int GetModifier(Attribute attribute)
        {
            return GetModifier(GetAttribute(attribute));
        }
    }
}
