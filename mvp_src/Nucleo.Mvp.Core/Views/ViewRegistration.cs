using System;
using System.Linq;
using System.Collections.Generic;


namespace Nucleo.Views
{
	/// <summary>
	/// Registers the view by creating a metadata object containing the view registration details.
	/// </summary>
	public static class ViewRegistration
	{

		private static List<ViewMetadata> _registrations = new List<ViewMetadata>();

		public static ViewMetadata Get(Type contractType)
		{
			return _registrations.FirstOrDefault(i => i.ContractType.Equals(contractType));
		}

		public static ViewMetadata Get<T>()
		{
			return Get(typeof(T));
		}

		/// <summary>
		/// Registers the view with the following metadata.
		/// </summary>
		/// <param name="contractType">The contract (interface) type.</param>
		/// <param name="viewType">The view (implementation) type.</param>
		/// <param name="presenterType">The presenter type.</param>
		/// <returns>The view metadata.</returns>
		public static ViewMetadata Register(Type contractType, Type viewType, Type presenterType)
		{
			ViewMetadata reg = new ViewMetadata
			{
				ContractType = contractType,
				ViewType = viewType,
				PresenterType = presenterType
			};
			_registrations.Add(reg);

			return reg;
		}

		/// <summary>
		/// Registers the view with the following metadata.
		/// </summary>
		/// <typeparam name="TCon">The contract (interface) type.</typeparam>
		/// <typeparam name="TView">The view (implementation) type.</typeparam>
		/// <param name="presenterType">The presenter type.</param>
		/// <returns>The view metadata.</returns>
		public static ViewMetadata Register<TCon, TView>(Type presenterType)
		{
			ViewMetadata reg = new ViewMetadata
			{
				ContractType = typeof(TCon),
				ViewType = typeof(TView),
				PresenterType = presenterType
			};
			_registrations.Add(reg);

			return reg;
		}

	}
}
