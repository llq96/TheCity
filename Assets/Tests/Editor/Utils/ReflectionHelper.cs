using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace TheCity.Tests.Utils
{
    public static class ReflectionHelper
    {
        private static bool IsHaveEmptySerializableFields(object component, out FieldInfo emptyFieldInfo)
        {
            var serializableFields = GetSerializableFields(component);
            foreach (var fieldInfo in serializableFields)
            {
                var value = fieldInfo.GetValue(component);
                if (value == null)
                {
                    emptyFieldInfo = fieldInfo;
                    return true;
                }
            }

            emptyFieldInfo = null;
            return false;
        }

        private static List<FieldInfo> GetSerializableFields(object component)
        {
            var instancePublicFlags = BindingFlags.Instance | BindingFlags.Public;
            var instanceNonPublicFlags = BindingFlags.Instance | BindingFlags.NonPublic;

            var publicFields = component.GetType().GetFields(instancePublicFlags).ToList();

            var nonPublicFields = component.GetType().GetFields(instanceNonPublicFlags).ToList();
            var serializableNonPublicFields =
                nonPublicFields.Where(x => x.IsDefined(typeof(SerializeField))).ToList();

            var serializableFields = Enumerable.Union(publicFields, serializableNonPublicFields);

            return serializableFields.ToList();
        }

        public static bool IsHaveEmptySerializableFields(IEnumerable<object> components)
        {
            return components.Any(x => IsHaveEmptySerializableFields(x, out _));
        }

        public static bool IsHaveEmptySerializableFields(IEnumerable<object> components,
            out Tuple<object, FieldInfo> emptyFieldTuple)
        {
            foreach (var component in components)
            {
                if (IsHaveEmptySerializableFields(component, out var emptyFieldInfo))
                {
                    emptyFieldTuple = new(component, emptyFieldInfo);
                    return true;
                }
            }

            emptyFieldTuple = null;
            return false;
        }

        public static void SetField(this object obj, string fieldName, object value)
        {
            var fieldInfo = obj.GetFieldAnyFlags(fieldName);
            fieldInfo.SetValue(obj, value);
        }

        public static FieldInfo GetFieldAnyFlags(this object obj, string fieldName)
        {
            return obj.GetType().GetFieldAnyFlags(fieldName);
        }

        public static FieldInfo GetFieldAnyFlags(this Type type, string fieldName)
        {
            return type.GetField(fieldName, (BindingFlags)(-1));
        }

        public static T GetField<T>(this object obj, string fieldName)
        {
            var fieldInfo = obj.GetFieldAnyFlags(fieldName);
            return (T)fieldInfo.GetValue(obj);
        }
    }
}