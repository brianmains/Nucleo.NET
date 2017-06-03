using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Modules
{
	/// <summary>
	/// Represents the attribute used to identify the module at an assembly level.
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly)]
	public class ModuleAttribute : Attribute
	{
		/// <summary>
		/// Gets the name of the type.
		/// </summary>
		public string TypeName
		{
			get;
			private set;
		}



		/// <summary>
		/// Initializes the attribute with the given type name.
		/// </summary>
		/// <param name="typeName">The name of the type.</param>
		public ModuleAttribute(string typeName)
		{
			Guard.NotNullOrEmpty(typeName);

			this.TypeName = typeName;
		}
	}
}
