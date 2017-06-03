using System;
using System.IO;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Nucleo.Reflection;


namespace Nucleo.Web
{
	public static class ControlUtility
	{
		public delegate Control ResolveControlCallback(string id);



		#region " Methods "

		public static CssStyleCollection CreateCssStyleCollection()
		{
			return (CssStyleCollection)Activator.CreateInstance(typeof(CssStyleCollection), true);
		}

		public static Control FindControl(Control baseControl, string id)
		{
			return FindControl(baseControl, id, null);
		}

		public static Control FindControl(Control baseControl, string id, ResolveControlCallback handler)
		{
			Control control = baseControl.FindControl(id);
			if (control == null && baseControl.NamingContainer != null)
				control = FindControlRecursive(baseControl.NamingContainer, id);

			if (control == null && handler != null)
				control = handler(id);

			return control;
		}

		private static Control FindControlRecursive(Control control, string id)
		{
			if (control == null)
				return null;

			Control returnControl = control.FindControl(id);
			if (returnControl != null)
				return returnControl;

			return FindControlRecursive(control.NamingContainer, id);
		}

		public static Dictionary<string, object> GetAttributes(string style)
		{
			if (string.IsNullOrEmpty(style))
				return new Dictionary<string, object>();

			Dictionary<string, object> output = new Dictionary<string, object>();
			string[] groupings = style.Split(';');

			foreach (string grouping in groupings)
			{
				string[] pairings = grouping.Split(':');

				if (pairings.Length == 2)
					output.Add(pairings[0], !string.IsNullOrEmpty(pairings[1]) ? pairings[1] : null);
			}

			return output;
		}

		public static string GetControlMarkup(Control control)
		{
			string output = null;

			using (StringWriter textWriter = new StringWriter())
			{
				HtmlTextWriter htmlWriter = new HtmlTextWriter(textWriter);
				control.RenderControl(htmlWriter);

				output = textWriter.ToString();
			}

			return output;
		}

		public static string GetPostbackClientMethod(string controlID, string args)
		{
			if (string.IsNullOrEmpty(controlID))
				throw new ArgumentNullException("controlID");

			if (args == null)
				args = string.Empty;

			return string.Format("__doPostBack('{0}', '{1}');", controlID, args);
		}

		public static PostBackOptions GetPostbackOptions(IButtonControl control)
		{
			PostBackOptions options = new PostBackOptions((Control)control, control.CommandArgument);
			options.ActionUrl = control.PostBackUrl;
			options.PerformValidation = control.CausesValidation;
			options.RequiresJavaScriptProtocol = true;
			options.ValidationGroup = control.ValidationGroup;

			return options;
		}

		public static string GetTemplateMarkup(Control containerControl, ITemplate template)
		{
			template.InstantiateIn(containerControl);

			return GetControlMarkup(containerControl);
		}

		public static string RenderControl(Control control)
		{
			StringWriter textWriter = new StringWriter();

			using (HtmlTextWriter htmlWriter = new HtmlTextWriter(textWriter))
				control.RenderControl(htmlWriter);

			return textWriter.ToString();
		}

		#endregion
	}
}
