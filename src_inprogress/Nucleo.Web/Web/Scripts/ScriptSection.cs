using System;
using System.Web.UI;

using Nucleo.Web.Core;
using Nucleo.Web.Pages;


namespace Nucleo.Web.Scripts
{
	public class ScriptSection : Control
	{
		private ScriptBlockCollection _blocks = null;


		#region " Properties "

		public ScriptBlockCollection Blocks
		{
			get 
			{
				if (_blocks == null)
					_blocks = new ScriptBlockCollection();
				return _blocks; 
			}
			set { _blocks = value; }
		}

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

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			WebSingletonManager.GetCurrent().AddEntry<ScriptSection>(this, this.RegionName);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);

			this.RenderScriptBlocks(writer);
		}

		protected virtual void RenderScriptBlocks(HtmlTextWriter writer)
		{
			foreach (ScriptBlock block in this.Blocks)
			{
				if (string.Compare(block.RegionName, this.RegionName, StringComparison.InvariantCultureIgnoreCase) == 0)
					block.RenderScript(writer);
			}
		}

		#endregion
	}
}
