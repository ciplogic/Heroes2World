using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NHeroes2.Serialize
{
    public static class ByteVectorReflect
    {
        private static readonly Dictionary<Type, FieldInfo[]> _typeFields = new Dictionary<Type, FieldInfo[]>();

        private static readonly Dictionary<Type, Func<ByteVectorReader, object>> _typeReaders =
            new Dictionary<Type, Func<ByteVectorReader, object>>();

        private static readonly Dictionary<Type, Action<ByteVectorWriter, object>> _typeWriters =
            new Dictionary<Type, Action<ByteVectorWriter, object>>();


        static ByteVectorReflect()
        {
            AddTypeReader(reader => reader.getLE32());
            AddTypeReader(reader => (uint) reader.getLE32());
            AddTypeReader(reader => (byte) reader.Get8());
            AddTypeReader(reader => (ushort) reader.getLE16());

            AddTypeWriter<byte>((writer, val) => { writer.put8(val); });
        }

        public static void AddTypeReader<T>(Action<ByteVectorReader, T> func) where T : new()
        {
            object MappingTypeReader(ByteVectorReader reader)
            {
                var newInst = new T();
                func(reader, newInst);
                return newInst;
            }

            _typeReaders[typeof(T)] = MappingTypeReader;
        }

        public static void AddTypeReader<T>(Func<ByteVectorReader, T> func)
        {
            _typeReaders[typeof(T)] = reader => func(reader);
        }

        public static void AddTypeWriter<T>(Action<ByteVectorWriter, T> func)
        {
            _typeWriters[typeof(T)] = (writer, obj) => func(writer, (T) obj);
        }


        public static T ReadData<T>(this ByteVectorReader byteVectorReader)
            where T : new()
        {
            var result = new T();
            if (_typeReaders.TryGetValue(typeof(T), out var factoryFunction))
                return (T) factoryFunction(byteVectorReader);
            var fieldsData = GetFieldsDataOfType(typeof(T));

            foreach (var fieldInfo in fieldsData)
            {
                Func<ByteVectorReader, object> reader;
                if (!_typeReaders.TryGetValue(fieldInfo.FieldType, out reader))
                    throw new InvalidOperationException("Should read type: " + fieldInfo.FieldType);

                var value = reader(byteVectorReader);
                fieldInfo.SetValue(result, value);
            }

            return result;
        }

        public static void Write<T>(this ByteVectorWriter byteVectorWriter, T instance)
        {
            var instanceType = typeof(T);
            WriteToByteVector(byteVectorWriter, instance, instanceType);
        }

        private static void WriteToByteVector(ByteVectorWriter byteVectorWriter, object instance, Type instanceType)
        {
            if (_typeWriters.TryGetValue(instanceType, out var factoryFunction))
            {
                factoryFunction(byteVectorWriter, instance);
                return;
            }

            var instanceTypeCode = Type.GetTypeCode(instanceType);
            if (instanceTypeCode == TypeCode.Object)
                throw new InvalidDataException("Expected to know how to serialize type: " + instanceType);

            var fieldsData = GetFieldsDataOfType(instanceType);
            foreach (var fieldInfo in fieldsData)
            {
                var fieldValue = fieldInfo.GetValue(instance);
                WriteToByteVector(byteVectorWriter, fieldValue, fieldInfo.FieldType);
            }
        }

        private static FieldInfo[] GetFieldsDataOfType(Type itemType)
        {
            if (_typeFields.TryGetValue(itemType, out var fieldsData))
                return fieldsData;
            var fields = itemType.GetFields();
            _typeFields[itemType] = fields;
            return fields;
        }
    }
}