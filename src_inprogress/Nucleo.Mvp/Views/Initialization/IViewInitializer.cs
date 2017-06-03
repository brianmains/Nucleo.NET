using System;

using Nucleo.Views;


namespace Nucleo.Views.Initialization
{
	/// <summary>
	/// Represents the interface to initialize a view.  This runs after the view has been initialized.  This is served up to the view by the <see cref="Nucleo.Dependencies.IDependencyResolver"/> component.
	/// </summary>
	public interface IViewInitializer
	{
		/// <summary>
		/// Initializes the view.
		/// </summary>
		/// <param name="view">The view to initialize.</param>
		void Initialize(IView view);
	}
}
