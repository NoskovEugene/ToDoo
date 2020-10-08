using System;
using System.Collections.Generic;
namespace ToDoo.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this List<T> lst, Action<T> action)
        {
            foreach(var item in lst)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach(var item in enumerable)
            {
                action(item);
            }
        }
    }
}