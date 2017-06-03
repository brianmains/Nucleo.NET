using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Navigation
{
	/// <summary>
	/// Represents the presenter that is involved in navigation.
	/// </summary>
	public interface IInlineNavigationPresenter
	{
		#region " Properties "

		void ChangeStatus(string navigationCommandName, bool active);

		/// <summary>
		/// Gets the navigation command names associated with the presenter.
		/// </summary>
		/// <returns>The array of command names.</returns>
		string[] GetNavigationCommandNames();

		#endregion
	}
}
