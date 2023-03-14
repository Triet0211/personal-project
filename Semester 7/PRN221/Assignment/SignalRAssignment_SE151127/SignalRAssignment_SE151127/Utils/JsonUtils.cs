using Newtonsoft.Json;

namespace SignalRAssignment_SE151127.Utils
{
    public static class JsonUtils
    {
        public static T DeserializeComplexData<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static string SerializeComplexData(object? value)
        {
            return (value != null) ? JsonConvert.SerializeObject(value) : null;
        }
    }
}