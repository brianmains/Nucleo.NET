using System;

using Nucleo.EventArguments;


namespace Nucleo.Web.Pages
{
	public interface IPageDriver
	{
		#region " Events "

		/// <summary>
		/// Fires before the control has initialized.
		/// </summary>
		event EventHandler Initializing;

		/// <summary>
		/// Fires before the control has loaded.
		/// </summary>
		event EventHandler Loading;

		/// <summary>
		/// Fires before the control has prepared for rendering.
		/// </summary>
		event EventHandler PrepareToRender;

		/// <summary>
		/// Fires when the control has gone through the rendering process.
		/// </summary>
		event RenderEventHandler Rendered;

		/// <summary>
		/// Fires when the control has not yet gone through the rendering process.
		/// </summary>
		event RenderEventHandler Rendering;

		/// <summary>
		/// Fires when the control starts up.
		/// </summary>
		event EventHandler Startup;

		/// <summary>
		/// Fires before the control has loaded.
		/// </summary>
		event EventHandler Unloading;

		/// <summary>
		/// Fires when the control is validating.
		/// </summary>
		event ValidateEventHandler ValidateState;

		#endregion



		#region " Properties "

		PageRequestContext CurrentContext { get; set; }

		/// <summary>
		/// Gets whether the current request is in the initial loading stages.
		/// </summary>
		bool IsInitialLoad { get; }

		#endregion
	}
}
