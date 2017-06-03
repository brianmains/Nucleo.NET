using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Lookups.Identification;
using Nucleo.Lookups.Repositories;


namespace Nucleo.Lookups.Providers
{
	public class StringFormatLookupProvider : ILookupProvider
	{
		private string _format = null;



		#region " Constructors "

		public StringFormatLookupProvider(string format)
		{
			if (string.IsNullOrEmpty(format))
				throw new ArgumentNullException("format");

			_format = format;
		}

		#endregion



		#region " Methods "

		public ILookupRepository GetRepository(ILookupIdentifier id)
		{
			if (!(id is NameLookupIdentifier))
				throw new InvalidOperationException();

			string name = string.Format(_format, ((NameLookupIdentifier)id).Name);
			Type type = Type.GetType(name);
			if (type == null)
				return null;

			return Activator.CreateInstance(type) as ILookupRepository;
		}

		public bool SupportsIdentifier(ILookupIdentifier id)
		{
			return (id is NameLookupIdentifier);
		}

		#endregion
	}
}
