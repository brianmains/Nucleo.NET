using System;

using Nucleo.Views;


namespace Nucleo.Presentation
{
	/// <summary>
	/// Represents the core interface for a presenter with a strongly-typed view.
	/// </summary>
	public interface IPresenter<T>
		where T : IView
	{
		/// <summary>
		/// Gets or sets the current context of the presenter.  The current context is an easy way to reference common services used within presenters, as well as a way to promote easy unit testing.
		/// </summary>
		PresenterContext CurrentContext { get; set; }

		/// <summary>
		/// Gets whether the current context exists.
		/// </summary>
		bool HasCurrentContext { get; }

		/// <summary>
		/// Gets or sets the presenter that is the parent to this current presenter.
		/// </summary>
		IPresenter Parent { get; set; }

		/// <summary>
		/// Gets the collection of subpresenters, presenters that are children to this current presenter.
		/// </summary>
		PresenterCollection Subpresenters { get; }

		/// <summary>
		/// Gets the view that represents this presenter.
		/// </summary>
		T View { get; }
	}
}
