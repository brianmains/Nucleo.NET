using System;
using System.Collections.Generic;


namespace Nucleo.Web.Collections
{
	public static class AjaxCollectionConverter
	{
		/// <summary>
		/// Converts an AJAX collection implementing the<see cref="IAjaxSerializableCollection">IAjaxSerializableCollection interface</see> into a client-side component for use with the AjaxCollectionConverter client-side component.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public static string ConvertAjaxCollection(IAjaxSerializableCollection collection)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			string clientType = collection.GetClientCollectionType();

			if (!string.IsNullOrEmpty(clientType))
				return string.Format("{{ ClientType: '{0}', Values: [{1}] }}", clientType, collection.ToJson());
			else
				return string.Format("[{0}]", collection.ToJson());
		}
	}
}
