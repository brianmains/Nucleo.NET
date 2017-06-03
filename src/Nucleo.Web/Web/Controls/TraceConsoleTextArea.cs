using System;
using System.Web.UI;


namespace Nucleo.Web.Controls
{
	/// <summary>
	/// Represents the trace console text area; renders a &lt;textarea id="traceconsole" /> to the browser.
	/// </summary>
	public class TraceConsoleTextArea : Control
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the columns for the trace console text area.
		/// </summary>
		public int Columns
		{
			get { return (int)(ViewState["Columns"] ?? 20); }
			set { ViewState["Columns"] = value; }
		}

		/// <summary>
		/// Gets or sets teh rows for the trace console text area.
		/// </summary>
		public int Rows
		{
			get { return (int)(ViewState["Rows"] ?? 30); }
			set { ViewState["Rows"] = value; }
		}

		/// <summary>
		/// Gets or sets the text for the trace console text area.
		/// </summary>
		public string Text
		{
			get { return (string)ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void Render(HtmlTextWriter writer)
		{
			writer.Write(string.Format("<textarea id='TraceConsole' name='TraceConsole' rows='{0}' cols='{1}'>{2}</textarea>", 
				this.Rows, this.Columns, this.Text));
		}

		#endregion
	}
}
