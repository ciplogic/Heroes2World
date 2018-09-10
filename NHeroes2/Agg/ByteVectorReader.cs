using System;

namespace NHeroes2.Agg
{
    class ByteVectorReader
    {
        private readonly byte[] _fileContent;
        int _pos;

        public ByteVectorReader(byte[] fileContent)
        {
            _fileContent = fileContent;
        }

        public int getLE16()
        {
            var lo = Get8();
            var hi = Get8();
            return lo + (hi << 8);
        }

        public int Get8()
        {
            var result = _fileContent[_pos];
            _pos++;
            return result;
        }

        public void seek(int pos)
        {
            _pos = pos;
        }

        public string toString(int lenText)
        {
            var chars = new char[lenText];
            var lenTextFinal = -1;
            for (var i = 0; i < lenText; i++)
            {
                var curChar = (char)Get8();
                if (curChar == 0 && lenTextFinal== -1)
                {
                    lenTextFinal = i;
                }
                chars[i] = curChar;
            }

            if (lenTextFinal == -1)
                lenTextFinal = lenText;
            var s = new string(chars, 0, lenTextFinal);
            return s;
        }

        public int getLE32()
        {
            var lo = getLE16();
            var hi = getLE16();
            return lo + (hi << 16);
        }
    }
}