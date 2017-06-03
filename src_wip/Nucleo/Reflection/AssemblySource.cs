using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Nucleo.Reflection
{
	public static class AssemblySource
	{
		public static IEnumerable<Assembly> GetAll()
		{
			return AppDomain.CurrentDomain.GetAssemblies().Where(i => !i.FullName.StartsWith("mscorlib") && !i.FullName.StartsWith("System") && !i.FullName.StartsWith("Microsoft"));
		}


		public static bool HasAssemblyResource<TAttrib>(Assembly assembly)
			where TAttrib: System.Attribute
		{
			return (assembly.GetCustomAttributes(typeof(TAttrib), false).Length > 0);
		}

		public static bool HasAssemblyResourceWith(Assembly assembly, Func<Attribute, bool> match)
		{
			var attributes = assembly.GetCustomAttributes(false);
			foreach (Attribute attribute in attributes)
			{
				if (match(attribute))
					return true;
			}

			return false;
		}
	}
}
