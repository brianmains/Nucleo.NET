using System;
using System.Collections.Generic;


namespace Nucleo.DataServices.Modules
{
	public class FakeModuleLoader : BaseModuleLoader
	{
		private DataServiceModuleCollection _modules = new DataServiceModuleCollection();
		private List<string> _names = new List<string>();



		#region " Methods "

		public override DataServiceModuleCollection GetModules(IEnumerable<ModuleIdentifier> identifiers)
		{
			DataServiceModuleCollection outputModules = new DataServiceModuleCollection();

			foreach (ModuleIdentifier identifier in identifiers)
			{
				int index = _names.IndexOf(identifier.Name);
				if (index < 0)
					continue;

				outputModules.Add(_modules[index]);
			}

			return outputModules;
		}

		public void LoadModules(IEnumerable<IDataServiceModule> modules, IEnumerable<string> names)
		{
			if (modules == null)
				throw new ArgumentNullException("modules");
			if (names == null)
				throw new ArgumentNullException("names");

			_modules.AddRange(modules);
			_names.AddRange(names);

			if (_modules.Count != _names.Count)
				throw new InvalidOperationException("The module count has to be the same as the name count");
		}

		#endregion
	}
}
