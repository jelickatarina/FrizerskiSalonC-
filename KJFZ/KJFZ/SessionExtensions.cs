//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-9.0
using System.Text.Json;

namespace KJFZ
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value) //Cuvanje objekta u sesiji
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key) //Dohvata objekat iz sesije
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
