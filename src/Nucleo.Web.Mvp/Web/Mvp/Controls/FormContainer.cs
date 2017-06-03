using System;
using System.Reflection;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Core;
using Nucleo.Web.Formatting;


namespace Nucleo.Web.Mvp.Controls
{
	/// <summary>
	/// Represents a container of form elements.
	/// </summary>
	public class FormContainer : Panel
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the region.
		/// </summary>
		public string RegionName
		{
			get { return (string)ViewState["RegionName"]; }
			set { ViewState["RegionName"] = value; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets an instance of the container from the page.
		/// </summary>
		/// <param name="context">The current executing context.</param>
		/// <param name="regionName">The name of the region.</param>
		/// <returns>The form container.</returns>
		public static FormContainer GetContainer(IWebContext context, string regionName)
		{
			if (context == null)
				throw new ArgumentNullException("context");
			if (string.IsNullOrEmpty(regionName))
				throw new ArgumentNullException("regionName");

			IDictionary<string, FormContainer> items = context.LocalStorage[typeof(FormContainer)] as IDictionary<string, FormContainer>;
			if (items == null || !items.ContainsKey(regionName))
				return null;

			return items[regionName];
		}		

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="e">Event details.</param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			IDictionary<string, FormContainer> items = this.Page.Items[typeof(FormContainer)] as IDictionary<string, FormContainer>;
			string key = this.RegionName ?? "";

			if (items == null)
			{
				items = new Dictionary<string, FormContainer>();
				items.Add(key, this);
			}
			else
			{
				if (items.ContainsKey(key))
					items.Add(key, this);
				else
					throw new ArgumentException("The region is already defined in the page.");
			}

			this.Page.Items[typeof(FormContainer)] = items;
		}

		#endregion
	}
}
