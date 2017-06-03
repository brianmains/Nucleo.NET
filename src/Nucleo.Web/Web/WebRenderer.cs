using System;
using System.Web.UI;

using Nucleo.Web.Tags;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the core class to render a component that doesn't contain a hierarchy of components and can resort to setting up the interface using text.
	/// </summary>
	/// <example>
	/// public class MyRenderer : WebRenderer
	/// {
	///		new public MyControl Component
	///		{
	///			get { return (MyControl)base.Component; }
	///		}
	///		
	///		public override TagElement Render()
	///		{
	///			TagElement tag = TagElementBuilder.Create("DIV");
	///			//Set props
	///			
	///			return tag;
	///		}
	/// }
	/// </example>
	public abstract class WebRenderer
	{
		private object _component = null;



		#region " Properties "

		/// <summary>
		/// Gets the component to render.
		/// </summary>
		public object Component
		{
			get { return _component; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Initializes the renderer component, passing along the related control.
		/// </summary>
		/// <param name="component"></param>
		public virtual void Initialize(object component)
		{
			_component = component;
		}

		/// <summary>
		/// Renders the UI by returning the tag element that represents the user interface.
		/// </summary>
		/// <returns>The element.</returns>
		public abstract TagElement Render();

		#endregion
	}
}
