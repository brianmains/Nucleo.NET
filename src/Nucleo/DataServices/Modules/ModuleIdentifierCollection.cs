using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.DataServices.Modules
{
	/// <summary>
	/// Represents a collection of module identifiers.
	/// </summary>
	public class ModuleIdentifierCollection : SimpleCollection<ModuleIdentifier>
	{
		#region " Methods "

		public void AddRange(IEnumerable<ModuleIdentifier> identifiers)
		{
			foreach (ModuleIdentifier identifier in identifiers)
				this.Add(identifier);
		}

		#endregion
	}
}
