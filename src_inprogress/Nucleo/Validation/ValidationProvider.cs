using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;

using Nucleo.Providers;


namespace Nucleo.Validation
{
	public abstract class ValidationProvider : IProvider
	{
		private string _name = null;



		#region " Properties "

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		#endregion



		#region " Methods "

		public abstract bool IsCorrectValidator(object obj);

		public abstract ValidationItemCollection Validate(object obj);

		#endregion
	}
}
