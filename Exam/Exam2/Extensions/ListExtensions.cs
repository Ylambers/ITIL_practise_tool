using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2.Extensions
{
    /// <summary>
    /// Defines a class that provides extension methods for <see cref="IList{T}"/>
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Randomly shuffles a list of items
        /// </summary>
        /// <typeparam name="T"><see cref="Type"/> of items contained in the list</typeparam>
        /// <param name="list"><see cref="IList{T}"/> to be shuffled</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int location1 = list.Count;
            while(location1 > 1)
            {
                location1--;
                int location2 = ThreadSafeRandom.GetThreadSafeRandom.Next(location1 + 1);
                T valueStorage = list[location2]; // Temporarly store the second location while we override it with location1
                list[location2] = list[location1];
                list[location1] = valueStorage;
            }
        }
    }
}
