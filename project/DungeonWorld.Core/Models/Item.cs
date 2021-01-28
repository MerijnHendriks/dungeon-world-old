namespace DungeonWorld.Core.Models
{
    public enum ItemTags
    {
        Precise
    }

    public class Item
    {
        public int weight;
        public int damage;
        public ItemTags[] tags;
    }
}
