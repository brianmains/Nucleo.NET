using System;
using System.Web.UI;


namespace Nucleo.Web.ValidationControls.Items
{
	/// <summary>
	/// Represents the base control for display items in the validation framework.
	/// </summary>
	public abstract class BaseValidationDisplayItem : BaseControl, IValidationDisplayItem
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the message of the validation display item.
		/// </summary>
		public string Message
		{
			get { return (string)ViewState["Message"]; }
			set { ViewState["Message"] = value; }
		}

		#endregion



		#region " Methods "

		protected abstract string GetCssClassName();

		public abstract void RenderContent(BaseControlWriter writer);

		public override void RenderUI(BaseControlWriter writer)
		{
			writer.Write("<li class='" + this.GetCssClassName() + "'>");

			this.RenderContent(writer);

			writer.Write("</li>");
		}

		#endregion
	}
}
