using System;
using System.Collections.Generic;
using System.Reflection;

namespace NHeroes2.Serialize
{
    public static class ByteVectorReaderReflect
    {
        private static Dictionary<Type, FieldInfo[]> _typeFields = new Dictionary<Type, FieldInfo[]>();

        private static Dictionary<Type, Func<ByteVectorReader, object>> _typeReaders =
            new Dictionary<Type, Func<ByteVectorReader, object>>();

        static ByteVectorReaderReflect()
        {
            _typeReaders[typeof(int)] = reader => reader.getLE32();
            _typeReaders[typeof(UInt32)] = reader => (UInt32) reader.getLE32();
            _typeReaders[typeof(byte)] = reader => (byte) reader.Get8();
            _typeReaders[typeof(UInt16)] = reader => (UInt16) reader.getLE16();
        }

        public static T ReadData<T>(this ByteVectorReader byteVectorReader)
            where T : new()
        {
            var itemType = typeof(T);
            FieldInfo[] fieldsData;
            if (!_typeFields.TryGetValue(itemType, out fieldsData))
            {
                var fields = itemType.GetFields();
                _typeFields[itemType] = fields;
                fieldsData = fields;
            }


            var result = new T();
            foreach (var fieldInfo in fieldsData)
            {
                Func<ByteVectorReader, object> reader;
                if (!_typeReaders.TryGetValue(fieldInfo.FieldType, out reader))
                {
                    throw new InvalidOperationException("Shoud read type: " + fieldInfo.FieldType);
                }

                var value = reader(byteVectorReader);
                fieldInfo.SetValue(result, value);
            }

            return result;
        }
    }
}