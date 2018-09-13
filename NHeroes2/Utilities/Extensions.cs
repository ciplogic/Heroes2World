using System;
using System.IO;
using Newtonsoft.Json;

namespace NHeroes2.Utilities
{
    public static class Extensions
    {
        public static void SerializeToJsonFile(this Object data, string fileName)
        {
            var jsonText = data.SerializeToJsonString();
            File.WriteAllText(fileName, jsonText);
        }

        public static string SerializeToJsonString(this Object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}