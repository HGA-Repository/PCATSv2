using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Common.Extentions
{
    public static class TypeExtentions
    {

        private static BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        public static object Call(this Type obj_type, object instance, string name)
        {
            object result = null;

            if (obj_type.HasProperty(name))
                result = obj_type.PropertityValue(instance, name);
            else if (obj_type.HasMethod(name))
                result = obj_type.MethodValue(instance, name);
            else if (obj_type.HasField(name))
                result = obj_type.FieldValue(instance, name);

            return result;
        }


        public static bool CallSet<T>(this Type obj_type, object instance, string name, T value)
        {

            if (obj_type.HasProperty(name))
                return obj_type.SetPropertityValue(instance, name, value);
            else if (obj_type.HasField(name))
                return obj_type.SetFieldValue(instance, name, value);
            return false;
        }



        public static bool HasProperty(this Type obj_type, string name)
        {
            return obj_type.GetProperties(Flags).Any(prop => prop.Name == name);
        }

        public static object PropertityValue(this Type obj_type, object instance, string name)
        {
            return obj_type.GetProperty(name,Flags).GetValue(instance, null);
        }

        public static bool SetPropertityValue<T>(this Type obj_type, object instance, string name, T value)
        {
           obj_type.GetProperty(name, Flags).SetValue(instance, value, null);
           return true;
        }



        public static object MethodValue(this Type obj_type, object instance, string name)
        {
            return obj_type.GetMethod(name, Flags).Invoke(instance, null);
        }

        public static bool HasMethod(this Type obj_type, string name)
        {
            return obj_type.GetMethods(Flags).Any(prop => prop.Name == name);
        }



        public static object FieldValue(this Type obj_type, object instance, string name)
        {
            return obj_type.GetField(name,Flags).GetValue(instance);
        }

        public static bool HasField(this Type obj_type, string name)
        {
            return obj_type.GetFields(Flags).Any(field => field.Name == name);
        }

        public static bool SetFieldValue<T>(this Type obj_type, object instance, string name, T value)
        {
            obj_type.GetField(name, Flags).SetValue(instance, value);
            return true;
        }

    }


}
