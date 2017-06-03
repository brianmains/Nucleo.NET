using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm
{
	/// <summary>
	/// Represents an object that was changed.
	/// </summary>
    public class ChangedObject
    {
		/// <summary>
		/// Get or set the entity that changes.
		/// </summary>
        public object Entity { get; set; }

		/// <summary>
		/// Gets or set the key of the entity.
		/// </summary>
        public object Key { get; set; }

		/// <summary>
		/// Gets or sets the the of modification made.
		/// </summary>
        public ModificationType Modification { get; set; }
    }
}
