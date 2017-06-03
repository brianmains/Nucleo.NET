using System;

using Nucleo.Windows.Actions;
using Nucleo.Windows.Application;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.ApplicationListeners
{
	public abstract class DocumentWindowListener : BaseModelListener
	{
		#region " Constructors "

		public DocumentWindowListener(ListenerControl control, ApplicationModel application)
			: base(control, application) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Determines whether the supported resource is a document window.
		/// </summary>
		/// <param name="element">The element to compare.</param>
		/// <returns>Whether the resource is supported.</returns>
		protected internal override bool IsSupportedUIElement(UIElement element)
		{
			return (element is DocumentWindow);
		}

		#endregion
	}
}
