using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Nucleo.Modules
{
	/// <summary>
	/// Inspects a module's assembly, creating a module from it if it exists.
	/// </summary>
	public static class ModuleInspector
	{
		public static IModule GetModule(Assembly assembly)
		{
			var attrib = GetModuleAttribute(assembly);
			if (attrib == null)
				return null;

			Type moduleType = assembly.GetType(attrib.TypeName);
			if (moduleType == null)
				throw new InvalidOperationException("Could not load module type: " + attrib.TypeName);

			IModule module = (IModule)Activator.CreateInstance(moduleType);
			if (module == null)
				throw new InvalidOperationException("Could not load module with type: " + moduleType.FullName);

			return module;
		}

		public static ModuleAttribute GetModuleAttribute(Assembly assembly)
		{
			Guard.NotNull(assembly);

			return assembly.GetCustomAttributes(typeof(ModuleAttribute), false).FirstOrDefault() as ModuleAttribute;
		}
	}
}
