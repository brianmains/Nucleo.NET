using System;


using Nucleo.Collections;


namespace Nucleo.Context.Providers
{
	public class InMemoryApplicationContextServiceRegistry : IApplicationContextServiceRegistry
	{
		private TypeRegistry _registry = null;



		#region " Constructors "

		public InMemoryApplicationContextServiceRegistry()
		{
			_registry = new TypeRegistry();
		}

		public InMemoryApplicationContextServiceRegistry(TypeRegistry registry)
		{
			if (registry == null)
				throw new ArgumentNullException("registry");

			_registry = registry;
		}

		#endregion



		#region " Methods "

		public void LoadServices(TypeRegistry registry)
		{
			registry.CopyFrom(_registry);
		}

		#endregion
	}
}
