using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;

using Nucleo.Web.Mvc.Elements.Forms;


namespace Nucleo.Web.Mvc.Elements
{
	public class NucleoElementFactory
	{
		private HtmlHelper _html = null;



		#region " Properties "

		public HtmlHelper Html
		{
			get { return _html; }
		}

		#endregion



		#region " Constructors "

		public NucleoElementFactory(HtmlHelper html)
		{
			_html = html;
		}

		#endregion



		#region " Methods "

		public HtmlFormBuilder BeginForm()
		{
			return new HtmlFormBuilder(this);
		}

		public string TraceConsole(int rows, int columns)
		{
			return this.TraceConsole(rows, columns, null);
		}

		public string TraceConsole(int rows, int columns, string text)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("<textarea id='TraceConsole' name='TraceConsole'");

			if (rows > 0)
				builder.AppendFormat(" rows='{0}'", rows);
			if (columns > 0)
				builder.AppendFormat(" cols='{0}'", columns);

			builder.AppendFormat(">{0}</textarea>", (!string.IsNullOrEmpty(text)) ? text : "");

			return builder.ToString();
		}

		public string EndForm()
		{
			return "</form>";
		}

		#endregion
	}
}
