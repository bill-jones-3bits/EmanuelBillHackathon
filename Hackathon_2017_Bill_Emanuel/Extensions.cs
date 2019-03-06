using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanuel.Extensions
{
    public static class ListExtensions
    {
        public static bool AnyAndNotNull<T>(this List<T> t)
        => t != null ? t.Any() : false;
    }

    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> t, Func<IEnumerable<T>, IEnumerable<T>> filterFunction) { return filterFunction(t); }
        public static IEnumerable<T> Do<T>(this IEnumerable<T> t, Action<IEnumerable<T>> action) { action(t); return t; }
        public static string AggregateToString<T>(this IEnumerable<T> t, string separator)
            =>t.Any() ? t
                .Select(e => e == null ? "<null>" : e.ToString())
                .Aggregate((a, b) => string.Concat(a, separator, b))
            : string.Empty;

        public static IEnumerable<T> DoForEach<T>(this IEnumerable<T> t, Action<T> action) { foreach (T element in t) action(element); return t; }
    }

    public static class ObjectExtensions
    {
        public static TResult Forward<T, TResult>(this T t, Func<T, TResult> func)
            => func(t);

        public static T AssignForward<T>(this T t, out T assign)
        {
            assign = t;
            return t;
        }
        public static bool AssignForwardIf<T>(this T t, Func<T, bool> condition, out T assign)
        {
            assign = t;
            if (condition(t))
            {
                return true;
            }
            return false;
        }

        public static T With<T>(this T t, Action<T> action)
        {
            action(t);
            return t;
        }
    }

    public static class BoolExtensions
    {
        public static bool? AsNullable(this bool b)
            => (bool?)b;
        public static bool NotNullNorFalse(this bool? b)
            => b.HasValue && b.Value;
    }

    public static class StringExtensions
    {
        public static string ReplaceCaseInsensitive(this string t, string find, string replace)
        {
            string r = string.Empty;
            while (t.IndexOf(find, StringComparison.InvariantCultureIgnoreCase).AssignForwardIf(i => i >= 0, out int index))
            {
                r = string.Concat(r,
                    t.Substring(0, index),
                    replace);
                t = t.Substring(index + find.Length);
            }
            return r + t;
        }

        public static (bool Found, string Head, string Tail) Crunch(this string t, string sought)
        => t.IndexOf(sought).Forward(i => i < 0 ? (false, t, string.Empty) :
            (true, t.Substring(0, i), t.Substring(i + sought.Length, t.Length - i - sought.Length)));
    }

    public static class IntExtensions
    {
        /// <summary>
        /// Returns true if a <= i <= b.
        /// </summary>
        /// <returns></returns>
        public static bool Between(this int i, int a, int b)
            => a <= i && i <= b;

        public static IEnumerable<int> EnumerateTo(this int from, int to)
        {
            for (int i = from; i < to; i++)
                yield return i;
        }
    }
}
