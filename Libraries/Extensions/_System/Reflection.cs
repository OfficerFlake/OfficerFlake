using System;
using System.Linq;
using System.Reflection;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class ReflectionExtensions
	{
        public static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
                assembly.GetTypes()
                    .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                    .ToArray();
        }
    }
}