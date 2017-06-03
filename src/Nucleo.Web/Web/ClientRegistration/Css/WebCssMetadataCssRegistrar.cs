using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ClientRegistration.Css
{
	public class WebCssMetadataCssRegistrar : ICssRegistrar
	{
		#region ICssRegistrar Members

		public CssReferenceRequestDetailsCollection GetPrimaryDetails(object target)
		{
			WebCssMetadata[] metadatas = ControlCssMetadata.GetWebCssMetadata(target);
			var list = new CssReferenceRequestDetailsCollection();

			if (metadatas.Length > 0)
			{
				for (int index = 0, len = metadatas.Length; index < len; index++)
				{
					CssReferenceRequestDetailsCollection references = metadatas[index].GetPrimaryCss();
					list.AddRange(references);
				}
			}

			return list;
		}

		#endregion
	}
}
