using System;

using Nucleo.Collections;


namespace Nucleo.Context.Providers
{
	public interface IApplicationContextServiceRegistry
	{
		#region " Methods "

		/// <summary>
		/// Loads the services into a provider, so the services can be used later.
		/// </summary>
		/// <param name="provider">The provider to use to register services.</param>
		void LoadServices(TypeRegistry registry);

		#endregion
	}
}
