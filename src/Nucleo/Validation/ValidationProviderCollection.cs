using System;
using System.Configuration.Provider;

using Nucleo.Collections;
using Nucleo.Providers;


namespace Nucleo.Validation
{
	public class ValidationProviderCollection : SimpleCollection<ValidationProvider>, IProviderCollection
	{
		#region " Properties "

		public ValidationProvider this[string name]
		{
			get
			{
				for (int index = 0, len = this.Count; index < len; index++)
				{
					if (string.Compare(this[index].Name, name, StringComparison.InvariantCultureIgnoreCase) == 0)
						return this[index];
				}

				return null;
			}
		}

		#endregion

		#region IProviderCollection Members

		void IProviderCollection.Add(IProvider provider)
		{
			if (!(provider is ValidationProvider))
				throw new InvalidCastException("Cannot convert provider to ValidationProvider");

			this.Add((ValidationProvider)provider);
		}

		void IProviderCollection.Remove(IProvider provider)
		{
			if (!(provider is ValidationProvider))
				throw new InvalidCastException("Cannot convert provider to ValidationProvider");

			this.Remove((ValidationProvider)provider);
		}

		#endregion
	}
}
