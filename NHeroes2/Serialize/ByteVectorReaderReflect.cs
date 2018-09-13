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

        private static Dictionary<Type, Action<ByteVectorWriter, object>> _typeWriters =
            new Dictionary<Type, Action<ByteVectorWriter, object>>();
            

        static ByteVectorReaderReflect()
        {
            AddTypeReader(reader => (int)reader.getLE32());
            AddTypeReader(reader => (UInt32) reader.getLE32());
            AddTypeReader(reader => (byte) reader.Get8());
            AddTypeReader( reader => (UInt16) reader.getLE16());
            
            AddTypeWriter<byte>((writer, val) => { writer.put8(val); });
            
        }

        public static void AddTypeReader<T>(Action<ByteVectorReader,T> func) where T : new() 
            => 
                _typeReaders[typeof(T)] = (reader) =>
            {
                var newInst = new T();
                func(reader, newInst);
                return newInst;

            };
        public static void AddTypeReader<T>(Func<ByteVectorReader,T> func) 
            => _typeReaders[typeof(T)] = reader => func(reader);

        public static void AddTypeWriter<T>(Action<ByteVectorWriter, T> func) 
            => _typeWriters[typeof(T)] = (writer, obj) => func(writer, (T) obj);


        public static T ReadData<T>(this ByteVectorReader byteVectorReader)
            where T : new()
        {
            if (_typeReaders.TryGetValue(typeof(T), out var factoryFunction))
            {
                return (T) factoryFunction(byteVectorReader);
            }
            var fieldsData = GetFieldsDataOfType(typeof(T));

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

        public static void Write<T>(this ByteVectorWriter byteVectorWriter, T instance)
        {
            var fieldsData = GetFieldsDataOfType(typeof(T));
            foreach (var fieldInfo in fieldsData)
            {
            }
        }

        private static FieldInfo[] GetFieldsDataOfType(Type itemType)
        {
            FieldInfo[] fieldsData;
            if (!_typeFields.TryGetValue(itemType, out fieldsData))
            {
                var fields = itemType.GetFields();
                _typeFields[itemType] = fields;
                fieldsData = fields;
            }

            return fieldsData;
        }
    }
}