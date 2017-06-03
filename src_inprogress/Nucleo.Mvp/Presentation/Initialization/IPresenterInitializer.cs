using System;


namespace Nucleo.Presentation.Initialization
{
	/// <summary>
	/// Represents the interface to initialize a presenter.  This runs after the presenter has been constructed.  This is served up to the <see cref="PresentionManager"/> by the <see cref="Nucleo.Dependencies.IDependencyResolver"/> component.
	/// </summary>
	public interface IPresenterInitializer
	{
		/// <summary>
		/// Initializes the presenter.
		/// </summary>
		/// <param name="Presenter">The presenter to initialize.</param>
		void Initialize(IPresenter Presenter);
	}
}
