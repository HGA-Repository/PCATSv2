using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extentions
{
    public static class ObjectExtentions
    {


        /// <summary>
        /// Call a method or property without args
        /// </summary>
        /// <param name="foo">this</param>
        /// <param name="method_or_property_name">Name of Method or property</param>
        /// <returns>object that is the return value of the Method or Property</returns>
        public static object Send(this object foo, string method_or_property_name)
        {
            return foo.GetType().Call(foo, method_or_property_name);
        }


        public static object Send(this object foo, object method_or_property_name)
        {
            return foo.Send(method_or_property_name.ToString());
        }


        public static bool SendSet<T>(this object foo, string method_or_property_name, T value)
        {
            return foo.GetType().CallSet(foo, method_or_property_name,value);
        }



        public static T As<T>(this object obj) 
        {
            if (typeof(T) == typeof(string) && obj != null)
                return (T)((object)obj.ToString());
            return (T)obj; 
        }



        /// <summary>
        /// try to get a value, returns null if the object is null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="P"></typeparam>
        /// <param name="obj"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static P @try<T, P>(this T obj, Func<T, P> f)
        {
            try
            { return obj == null ? default(P) : f(obj); }
            //only ignore null NullReferenceException
            //SSS 20131104 catch (NullReferenceException e) { return default(P); }
            //SSS 20131104 catch (IndexOutOfRangeException e) { return default(P); }
            catch (NullReferenceException) { return default(P); }
            catch (IndexOutOfRangeException)  { return default(P); }
        }




    }
}
