using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.DataServices.Modules
{
	public class FakeDataServiceScheduler : BaseModuleScheduler
	{
		private ModuleIdentifierCollection _identifiers = new ModuleIdentifierCollection();



		#region " Methods "

		public override ModuleIdentifierCollection GetModulesForExecution()
		{
			return _identifiers;
		}

		public void LoadIdentifiers(IEnumerable<ModuleIdentifier> identifiers)
		{
			_identifiers.AddRange(identifiers);
		}

		#endregion
	}
}
