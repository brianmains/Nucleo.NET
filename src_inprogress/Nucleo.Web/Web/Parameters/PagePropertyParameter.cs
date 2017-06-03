using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;


namespace Nucleo.Web.Parameters
{
	public class PagePropertyParameter : Parameter
	{
		#region " Properties "

		public string PropertyName
		{
			get { return (string)ViewState["PropertyName"] ?? string.Empty; }
			set { ViewState["PropertyName"] = value; }
		}

		#endregion



		#region " Methods "

		protected override object Evaluate(System.Web.HttpContext context, Control control)
		{
			Page page = control.Page;
			PropertyInfo property = page.GetType().GetProperty(this.PropertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

			if (property == null)
				throw new NullReferenceException(string.Format("The property '{0}' for the page was not found", this.PropertyName));

			return property.GetValue(page, null);
		}

		#endregion
	}
}
