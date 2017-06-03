using System;
using System.Collections.Generic;


namespace Nucleo.Web
{
	public interface IScriptComponent
	{
		void RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor);
		void RegisterAjaxReferences(IContentRegistrar registrar);
	}
}
