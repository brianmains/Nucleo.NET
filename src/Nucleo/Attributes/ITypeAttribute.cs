using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Attributes
{
	/// <summary>
	/// This interface represents a System.Attribute class that stores a reference to a type instance or a type name.
	/// </summary>
	public interface ITypeAttribute
	{
		/// <summary>
		/// Gets or sets a reference to the type.  A type has a reference to the assembly.
		/// </summary>
		Type Type { get; set; }

		/// <summary>
		/// Gets or sets a reference to the name of the type, which may need to include the assembly.
		/// </summary>
		string TypeName { get; set; }
	}
}
