using System.IO;
using System.Linq;
using System.Text;
using NHeroes2.Serialize;

namespace NHeroes2.Agg.Music
{
    static class MiniLog
    {
        static StringBuilder _logText = new StringBuilder();
        private static int _bufPos;

        public static void addLine(string row, int val)
        {
            addLine(row + ": " + val);
        }
        public static void addLine(string row)
        {
            _logText.AppendLine(row);
        }

        private static string JoinValues(byte[] value, int startPos)
        {
            return string.Join(",", value.Skip(startPos).Select(b => (int) b));
        }

        static void addLine(string row, byte[] value, int startPos)
        {
            _logText
                .Append(row)
                .Append(": ")
                .AppendLine(JoinValues(value, startPos));
        }
        public static void addLine(string row, byte[] value)
        {
            addLine(row, value, 0);
        }

        public static void writeBuf(string text, ByteVectorWriter st)
        {
            addLine(text, st.data(), _bufPos);
            _bufPos = st.data().Length;
        }
        public static void flushLog()
        {
            File.WriteAllText("eventsLog.txt", _logText.ToString());
        }
    }
}