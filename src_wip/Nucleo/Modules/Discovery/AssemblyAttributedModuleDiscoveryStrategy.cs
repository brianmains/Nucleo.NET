using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Nucleo.Reflection;


namespace Nucleo.Modules.Discovery
{
	/// <summary>
	/// Represents the module discovery strategy that uses an assembly attribute (of type <see cref="ModuleAttribute"/>) that is the marker.
	/// </summary>
	public class AssemblyAttributedModuleDiscoveryStrategy : IModuleDiscoveryStrategy
	{
		private IModule GetModule(Assembly assembly)
		{
			return ModuleInspector.GetModule(assembly);
		}


		/// <summary>
		/// Finds the modules where a <see cref="ModuleAttribute"/> is found.
		/// </summary>
		/// <param name="options">The options used to find an object.</param>
		/// <returns>The collection of modules where the attribute is found defined on the assembly.</returns>
		public ModuleCollection Find(ModuleDiscoveryOptions options)
		{
			var assemblies = AssemblySource.GetAll().Where(a => AssemblySource.HasAssemblyResource<ModuleAttribute>(a));
			var modules = new ModuleCollection();

			foreach (var assembly in assemblies)
			{
				IModule module = GetModule(assembly);
				module.Initialize();
			}

			return modules;
		}
	}
}
