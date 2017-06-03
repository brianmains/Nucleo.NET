using System;
using System.Collections.Generic;

using Nucleo.Web;


namespace Nucleo.Web.Collections
{
	public interface IAjaxSerializableCollection : IJsonOutput
	{
		#region " Methods "

		string GetClientCollectionType();

		#endregion
	}
}
