using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;


namespace Nucleo.Web
{
	public interface IDescriptor
	{
		#region " Properties "

		/// <summary>
		/// Gets the client ID of the described component.
		/// </summary>
		string ClientID { get; }
		
		/// <summary>
		/// Gets or sets the client-side type of the described component.
		/// </summary>
		string Type { get; set; }

		#endregion



		#region " Methods "

		void AddCollectionProperty(string name, object collection, JavaScriptConverter converter);
		void AddComponentProperty(string name, string componentID);
		void AddElementProperty(string name, string elementID);
		void AddEvent(string name, string handler);
		void AddEventIfExists(string name, string handler);
		void AddProperty(string name, object value);
		void AddProperty(string name, object value, JavaScriptConverter converter);
		void AddPropertyIfExists(string name, object value);
		void AddScriptProperty(string name, string script);
		void AddStyleProperty(Control control, string name, Style style);

		#endregion
	}
}
