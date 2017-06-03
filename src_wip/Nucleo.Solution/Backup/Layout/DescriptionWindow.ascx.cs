using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Demos;


namespace Nucleo.Layout
{
	public partial class DescriptionWindow : System.Web.UI.UserControl
	{
		public string Content
		{
			get { return this.Description.Text; }
			set { this.Description.Text = value; }
		}



		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (!string.IsNullOrEmpty(this.Content))
				this.Description.Text = this.Content;
			else
			{
				var page = this.Page as IDescriptable;
				if (page != null)
					this.Content = page.Description;
			}
		}
	}
}