using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Presentation;


namespace Nucleo.Views
{
	/// <summary>
	/// Represents a view that will receive an assignment from a related presenter.
	/// </summary>
	public interface IViewPresenterAssignment
	{
		/// <summary>
		/// Adds a presenter to the child of the parent presenter.
		/// </summary>
		/// <param name="presenter">The presenter that's the sub-presenter to this parent presenter.</param>
		void AddSubpresenter(IPresenter presenter);
	}
}
