using System;
using System.Threading;

namespace Exam2
{
    /// <summary>
    /// Defines a class that provides a thread safe random function
    /// </summary>
    public static class ThreadSafeRandom
    {
        /// <summary>
        /// Thread safe instance of <see cref="Random"/>
        /// </summary>
        [ThreadStatic]
        private static Random? s_instance;

        /// <summary>
        /// Get an instance of this threads <see cref="Random"/>
        /// </summary>
        public static Random GetThreadSafeRandom => s_instance ??= new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId));
    }
}
