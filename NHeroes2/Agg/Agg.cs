using System;
using System.Collections.Generic;
using System.IO;

namespace NHeroes2.Agg
{
    public class AggFile
    {
        const int FATSIZENAME = 15;
        
        string filename;
        Dictionary<string, AggFat> fat = new Dictionary<string, AggFat>();
        int count_items = 0;
        private int size;
        private ByteVectorReader stream;
        byte[] fileContent;
        string key;
        byte[] body;

        public bool Read(string fname)
        {
            
            filename = fname;
            if (!File.Exists(fname))
                return false;
            
            fileContent = File.ReadAllBytes(filename);
            size = fileContent.Length;
            stream = new ByteVectorReader(fileContent);
            
            count_items = stream.getLE16();

            stream.seek(size - FATSIZENAME * count_items);
            var vectorNames = new List<string>(count_items);
            
            for (var ii = 0; ii < count_items; ++ii)
            {
                vectorNames.Add(stream.toString(FATSIZENAME));
            }
            stream.seek(2);
            for (var ii = 0; ii < count_items; ++ii)
            {
                var itemName = vectorNames[ii];
                AggFat f = new AggFat();
                var crc = stream.getLE32();
                f.crc = crc;
                var offset = stream.getLE32();
                f.offset = offset;
                var sizeChunk = stream.getLE32();
                f.size = sizeChunk;
                fat[itemName] = f;
            }

            return true;
        }
    }
}