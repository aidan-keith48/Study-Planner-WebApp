using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Study_Planner_WebApp
{
    public static class SessionExtensions
    {
        // Extension method for setting an object in session
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Extension method for getting an object from session
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
