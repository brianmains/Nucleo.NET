using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Web.Mvc
{
	/// <summary>
	/// Represents the base class for MVC server side components with NO ajax support.
	/// </summary>
	/// <typeparam name="TBuilder">The type of builder being created.</typeparam>
	public abstract class BaseMvcServerComponentBuilder<TBuilder>
		where TBuilder: BaseMvcServerComponentBuilder<TBuilder>
	{
		private NucleoControlFactory _controlFactory = null;



		#region " Properties "

		protected NucleoControlFactory ControlFactory
		{
			get { return _controlFactory; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the component builder.
		/// </summary>
		/// <param name="controlFactory">The control factory.</param>
		public BaseMvcServerComponentBuilder(NucleoControlFactory controlFactory)
		{
			_controlFactory = controlFactory;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the control writer for the control.
		/// </summary>
		/// <returns></returns>
		protected virtual BaseControlWriter GetControlWriter()
		{
			return new HtmlStreamControlWriter(HttpContext.Current.Request.Browser.CreateHtmlTextWriter(
				_controlFactory.Html.ViewContext.HttpContext.Response.Output));
			//return new StringControlWriter();
		}

		/// <summary>
		/// Renders the UI.
		/// </summary>
		public void Render()
		{
			BaseControlWriter writer = this.GetControlWriter();
			this.RenderUI(writer);
		}

		/// <summary>
		/// Renders the UI.
		/// </summary>
		/// <param name="writer">The control writer.</param>
		protected abstract void RenderUI(BaseControlWriter writer);

		#endregion
	}
}
