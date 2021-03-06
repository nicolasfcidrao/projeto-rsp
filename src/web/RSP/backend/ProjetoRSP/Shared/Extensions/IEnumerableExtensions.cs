using System;
using System.Collections.Generic;

namespace ProjetoRSP.Shared.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
                action?.Invoke(item);
        }
    }
}
