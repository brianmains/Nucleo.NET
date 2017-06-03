using System;
using System.Collections.Generic;

using Nucleo.Reflection;


namespace Nucleo.Web
{
	public static class ControlCssMetadata
	{
		#region " Methods "

		public static WebCssMetadata[] GetWebCssMetadata(object component)
		{
			return Reflect.Public(component).Type().GetObjectFromTypeAttributes<WebCssMetadata, WebCssMetadataAttribute>(
				(obj) => { obj.Initialize(component); }, true);
		}

		public static WebCssMetadata[] GetWebCssMetadataRelationships(WebCssMetadata scriptMetadata)
		{
			List<WebCssMetadata> metadataList = new List<WebCssMetadata>(Reflect.Public(scriptMetadata).Type().GetObjectFromTypeAttributes<WebCssMetadata, WebScriptMetadataRelationshipAttribute>());

			foreach (WebCssMetadata metadata in metadataList)
			{
				WebCssMetadata[] metadataRelationships = GetWebCssMetadataRelationships(metadata);
				if (metadataRelationships.Length > 0)
					metadataList.AddRange(metadataRelationships);
			}

			return metadataList.ToArray();
		}

		#endregion
	}
}
