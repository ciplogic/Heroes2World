﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace NHeroes2.Utilities
{
    public static class Extensions
    {
        public static T Set<TK, T>(this Dictionary<TK, T> dictionary, TK key) where T : new()
        {
            if (dictionary.TryGetValue(key, out var result))
                return result;
            result = new T();
            dictionary[key] = result;
            return result;
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items) action(item);
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T, int> action)
        {
            var pos = -1;
            foreach (var item in items)
            {
                ++pos;
                action(item, pos);
            }
        }

        public static void SerializeToJsonFile(this object data, string fileName)
        {
            var jsonText = data.SerializeToJsonString();
            File.WriteAllText(fileName, jsonText);
        }

        public static string SerializeToJsonString(this object data)
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

        public static void SetSize<T>(this List<T> collection, int newSize)
            where T : new()
        {
            collection.Clear();
            collection.Capacity = newSize;
            for (var i = 0; i < newSize; i++) collection.Add(new T());
        }
    }
}