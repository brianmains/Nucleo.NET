using System;
using System.ComponentModel;
using System.Web.UI;

using Nucleo.Web.Pages;


namespace Nucleo.Web.Scripts
{
	/// <summary>
	/// Represents a dynamic script loader control.
	/// </summary>
	[
	ParseChildren(true),
	PersistChildren(false)
	]
	public class DynamicScriptLoader : Control, IRenderableControl
	{
		private DynamicScriptCollection _scripts = null;



		#region " Properties "

		/// <summary>
		/// Gets the collection of scripts, which are not attached to viewstate.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public DynamicScriptCollection Scripts
		{
			get 
			{
				if (_scripts == null)
					_scripts = new DynamicScriptCollection();
				return _scripts; 
			}
			set { _scripts = value; }
		}

		#endregion



		#region " Methods "

		protected override void AddParsedSubObject(object obj)
		{
			base.AddParsedSubObject(obj);
		}

		/// <summary>
		/// Gets the script registration statement to register the script.
		/// </summary>
		/// <param name="script">The script to register.</param>
		/// <returns>The statement to register the script.</returns>
		protected virtual string GetScriptRegistration(DynamicScript script)
		{
			return string.Format("n$.Content.registerScript({{ key: '{0}', path: '{1}' }});", script.Name, Page.ResolveClientUrl(script.Path));
		}

		protected override void Render(HtmlTextWriter writer)
		{
			((IRenderableControl)this).RenderUI(new HtmlStreamControlWriter(writer));	
		}

		void IRenderableControl.RenderUI(BaseControlWriter writer)
		{
			writer.WriteLine("<script type='text/javascript' language='javascript'>");
			bool comma = false;

			foreach (DynamicScript script in this.Scripts)
			{
				if (comma)
					writer.Write(",");
				else
					comma = true;

				writer.Write(this.GetScriptRegistration(script));
			}

			writer.WriteLine("</script>");
		}

		#endregion
	}
}
