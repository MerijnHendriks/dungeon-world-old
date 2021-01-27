using System.Text.Json;

namespace DungeonWorld.Engine.Utils
{
    public static class JsonUtil
    {
        public static string Serialize(object o)
        {
            return JsonSerializer.Serialize(o);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
