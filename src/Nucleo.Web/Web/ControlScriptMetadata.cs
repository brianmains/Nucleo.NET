using System;
using System.Collections.Generic;

using Nucleo.Reflection;


namespace Nucleo.Web
{
	public static class ControlScriptMetadata
	{
		#region " Methods "

		public static WebScriptMetadata[] GetWebScriptMetadata(object component)
		{
			return Reflect.Public(component).Type().GetObjectFromTypeAttributes<WebScriptMetadata, WebScriptMetadataAttribute>(
				(obj) => { obj.Initialize(component); }, true);
		}

		public static WebScriptMetadata[] GetWebScriptMetadataRelationships(WebScriptMetadata scriptMetadata)
		{
			List<WebScriptMetadata> metadataList = new List<WebScriptMetadata>(Reflect.Public(scriptMetadata).Type().GetObjectFromTypeAttributes<WebScriptMetadata, WebScriptMetadataRelationshipAttribute>());

			foreach (WebScriptMetadata metadata in metadataList)
			{
				WebScriptMetadata[] metadataRelationships = GetWebScriptMetadataRelationships(metadata);
				if (metadataRelationships.Length > 0)
					metadataList.AddRange(metadataRelationships);
			}

			return metadataList.ToArray();
		}

		#endregion
	}
}
