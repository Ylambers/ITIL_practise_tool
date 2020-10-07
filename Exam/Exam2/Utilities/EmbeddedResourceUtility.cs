using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Exam2.Utilities
{
    /// <summary>
    /// Defines a class that provides utilities for working with embedded resources
    /// </summary>
    public static class EmbeddedResourceUtility
    {
        /// <summary>
        /// Get a <see cref="Stream"/> containing a embedded resource
        /// </summary>
        /// <param name="resourceName">The name of the embedded resource to get</param>
        /// <returns>Returns <see cref="Stream"/> containing the resource or <see langword="null"/> if it doesn't exist</returns>
        public static Stream? GetEmbeddedResourceStream(string resourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }

        /// <summary>
        /// Get all the embedded resource names
        /// </summary>
        /// <returns><see cref="string[]"/> containing all embedded resource names</returns>
        public static string[] GetEmbeddedResourceNames()
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceNames();
        }
    }
}
