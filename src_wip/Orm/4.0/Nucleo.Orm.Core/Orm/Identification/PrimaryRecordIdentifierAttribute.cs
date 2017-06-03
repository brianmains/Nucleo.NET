using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Identification
{
	/// <summary>
	/// Represents a property on an entity that is the primary identifier for a record.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class PrimaryRecordIdentifierAttribute : Attribute
	{

	}
}
