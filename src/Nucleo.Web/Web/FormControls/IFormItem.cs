using System;


namespace Nucleo.Web.FormControls
{
	/// <summary>
	/// Represents the interface that represents each primitive control for each field in a form section.
	/// </summary>
	public interface IFormItem
	{
		#region " Properties "

		/// <summary>
		/// Gets the current view that the form item is exposing.
		/// </summary>
		FormCurrentView CurrentView { get; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Changes the current view to the new view type.
		/// </summary>
		/// <param name="formCurrentView">The view type to change to.</param>
		void ChangeView(FormCurrentView formCurrentView);

		#endregion
	}
}
