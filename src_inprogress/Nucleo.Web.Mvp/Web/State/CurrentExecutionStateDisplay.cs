using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web;

using Nucleo.State;


namespace Nucleo.Web.State
{
	/// <summary>
	/// Represents a control to display the current execution state.
	/// </summary>
	public class CurrentExecutionStateDisplay : BaseControl
	{
		/// <summary>
		/// Gets or sets the header text of the control.
		/// </summary>
		[Description("Gets or sets the header text of the control.")]
		public string HeaderText
		{
			get { return (string)ViewState["HeaderText"]; }
			set { ViewState["HeaderText"] = value; }
		}

		protected virtual void RenderHeader(BaseControlWriter writer)
		{
			writer.WriteBeginTag("tr");
			writer.WriteBeginTag("th", new { colspan = 2 });

			writer.Write(this.HeaderText);

			writer.WriteEndTag("th");
			writer.WriteEndTag("tr");
		}

		protected virtual void RenderItem(BaseControlWriter writer, StateValue value)
		{
			writer.WriteBeginTag("tr");

			writer.WriteBeginTag("td");
			writer.Write(value.Key.ToString());
			writer.WriteEndTag("td");

			writer.WriteBeginTag("td");
			writer.Write((value.Value != null) ? value.Value.ToString() : "");
			writer.WriteEndTag("td");

			writer.WriteEndTag("tr");
		}

		public override void RenderUI(BaseControlWriter writer)
		{
			var items = (Dictionary<object, object>)HttpContext.Current.Items[typeof(WebCurrentExecutionState)];
			if (items == null || items.Count == 0)
				return;

			writer.WriteBeginTag("table");
			writer.WriteBeginTag("thead");

			if (!string.IsNullOrEmpty(this.HeaderText))
				this.RenderHeader(writer);

			writer.WriteEndTag("thead");

			foreach (object key in items.Keys)
			{
				this.RenderItem(writer, new StateValue { Key = key, Value = items[key] });
			}

			writer.WriteEndTag("table");
		}
	}
}
