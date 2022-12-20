using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace WebTechnologiesProject.Infrastructure
{
    public class SessionExtensions
    {
        public static void SetJson(ISession session, string key, object value)
        {
            session.SetString(key, JsonConverter.SerializeObject(value));
        }
    }
}
