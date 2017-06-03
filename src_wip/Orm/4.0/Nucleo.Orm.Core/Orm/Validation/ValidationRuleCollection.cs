using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Collections;


namespace Nucleo.Orm.Validation
{
	/// <summary>
	/// Represents the collection of validation rules.
	/// </summary>
	public class ValidationRuleCollection : SimpleCollection<IValidationRule>
	{
		/// <summary>
		/// Adds a range of rules to the collection.
		/// </summary>
		/// <param name="rules">The rules to add.</param>
		public void AddRange(IEnumerable<IValidationRule> rules)
		{
			Guard.NotNull(rules);

			foreach (var rule in rules)
				this.Add(rule);
		}
	}
}
