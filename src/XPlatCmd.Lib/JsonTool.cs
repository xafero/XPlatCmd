using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XPlatCmd.Lib
{
    public static class JsonTool
    {
        private static JsonSerializerSettings GetConfig(bool format)
        {
            var config = new JsonSerializerSettings
            {
                Converters = { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = format ? Formatting.Indented : Formatting.None
            };
            return config;
        }

        public static void ToFile<T>(string file, T obj, bool format = true)
        {
            using var writer = File.CreateText(file);
            var config = GetConfig(format);
            var json = JsonConvert.SerializeObject(obj, config);
            writer.WriteLine(json);
            writer.Flush();
        }
    }
}