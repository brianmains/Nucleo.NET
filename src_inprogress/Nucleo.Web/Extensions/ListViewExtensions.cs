using System;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace System.Web.UI.WebControls
{
	public static class ListViewExtensions
	{
		#region " Methods "

		/// <summary>
		/// Binds data to the view.
		/// </summary>
		/// <param name="grid">The view to bind.</param>
		/// <param name="data">The data to bind.</param>
		public static void BindData(this ListView grid, object data)
		{
			grid.DataSource = data;
			grid.DataBind();
		}

		public static object GetDataKeyValue(this ListViewDataItem row)
		{
			ListView view = (ListView)row.Parent;
			return view.DataKeys[row.DataItemIndex].Value;
		}

		public static IOrderedDictionary GetDataKeyValues(this ListViewDataItem row)
		{
			ListView view = (ListView)row.Parent;
			return view.DataKeys[row.DataItemIndex].Values;
		}

		#endregion
	}
}
