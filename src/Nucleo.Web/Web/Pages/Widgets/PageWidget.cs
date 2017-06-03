using System;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Web.Description;

namespace Nucleo.Web.Pages.Widgets
{
	/// <summary>
	/// Represents a widget for the <see cref="BaseAjaxPage">BaseAjaxPage page implementations</see>.
	/// </summary>
	public class PageWidget
	{
		#region " Methods "

		protected internal virtual void RegisterAjaxDescriptors(IContentRegistrar registrar, ComponentDescriptor pageDescriptor)
		{

		}

		protected internal virtual void RegisterAjaxReferences(IContentRegistrar registrar)
		{
#if DEBUG
			registrar.AddReference(new ScriptReferencingRequestDetails(typeof(PageWidget), ScriptMode.Debug));
#else
			registrar.AddReference(new ScriptReferencingRequestDetails(typeof(PageWidget), ScriptMode.Release));
#endif
		}

		protected internal virtual void RegisterCssReferences(IContentRegistrar registrar)
		{

		}

		#endregion
	}
}
