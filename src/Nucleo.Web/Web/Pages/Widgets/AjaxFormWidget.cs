using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Pages.Widgets
{
	public class AjaxFormWidget : PageWidget 
	{
		#region " Methods "

		protected override void RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			base.RegisterAjaxDescriptors(registrar, currentDescriptor);
		}

		protected override void RegisterAjaxReferences(IContentRegistrar registrar)
		{
			base.RegisterAjaxReferences(registrar);
		}

		#endregion
	}
}
