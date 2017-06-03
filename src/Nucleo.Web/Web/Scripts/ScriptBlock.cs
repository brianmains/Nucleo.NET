using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Core;
using Nucleo.Web.Pages;


namespace Nucleo.Web.Scripts
{
	public class ScriptBlock : Control
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

		private IWebSingletonManager GetSingleton()
		{
			IPageDriver page = this.Page as IPageDriver;
			if (page != null)
				return ((IPageDriver)page).CurrentContext.Singletons;

			return WebSingletonManager.GetCurrent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			IWebSingletonManager singleton = this.GetSingleton();
			ScriptSection section = singleton.GetEntry<ScriptSection>(this.RegionName);

			if (section != null)
			{
				if (string.Compare(this.RegionName, section.RegionName, StringComparison.InvariantCultureIgnoreCase) == 0)
					section.Blocks.Add(this);
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			//Do not render anything here; parent control does the rendering
		}

		protected internal void RenderScript(HtmlTextWriter writer)
		{
			base.RenderChildren(writer);
		}

		#endregion
	}
}
