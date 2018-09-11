using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SDL2SharpTutorial.Utilities
{
    static class Extensions
    {
        public static void SerializeToFile(this Object data, string fileName)
        {
            var jsonText = JsonConvert.SerializeObject(data);
            File.WriteAllText(fileName, jsonText);
        }
    }
}