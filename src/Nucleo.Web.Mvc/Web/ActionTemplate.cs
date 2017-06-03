using System;
using System.Web.UI;


namespace Nucleo.Web
{
	public class ActionTemplate : ITemplate
	{
		private System.Action _action = null;



		#region " Constructors "

		public ActionTemplate(System.Action action)
		{
			_action = action;
		}

		#endregion




		#region ITemplate Members

		public void InstantiateIn(Control container)
		{
			//HtmlTextWriter writer = container.Page.Request.Browser.CreateHtmlTextWriter(container.Page.Response.Output);
			//_action();
		}

		#endregion
	}
}
