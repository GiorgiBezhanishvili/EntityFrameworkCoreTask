using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkCoreTask.HelperMethods
{
    public static class CollectionHelpers
    {
        public static TSource Random<TSource>(this List<TSource> source)
        {
            if (source.Count == 0) throw new NullReferenceException("List is empty!");

            var rand = new Random();

            var maxValue = source.Count - 1;

            var randomNumber = rand.Next(maxValue);

            return source[randomNumber];
        }

        public static TSource Random<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new NullReferenceException("Empty collection!");

            var rand = new Random();

            var count = 0;

            foreach (var item in source)
            {
                count++;
            }

            var maxValue = count - 1;

            var randomNumber = rand.Next(maxValue);

            return source.ElementAt(randomNumber);
        }

        public static TSource Random<TSource>(this TSource[] source)
        {
            foreach (var item in source)
            {
                if (item == null) throw new NullReferenceException("Array element is empty!");
            }

            var rand = new Random();

            var count = 0;

            foreach (var item in source)
            {
                count++;
            }

            var maxValue = count;

            var randomNumber = rand.Next(maxValue);

            return source[randomNumber];
        }
    }
}
