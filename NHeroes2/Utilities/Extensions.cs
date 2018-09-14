using System;
using System.Collections.Generic;
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

        public static T back<T>(this IList<T> items) 
        {
            if (items.Count == 0)
                return default(T);
            return items[items.Count - 1];
        }


        public static T front<T>(this IList<T> items) 
        {
            if (items.Count == 0)
                return default(T);
            return items[0];
        }

        public static bool empty<T>(this IList<T> items)
        {
            return items.Count == 0;
        }
    }
}