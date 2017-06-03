using System;
using System.Web;
using System.Web.UI;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the base class for rendering components using the legacy HTML text writer approach (common to .NET controls).
	/// </summary>
	/// <remarks>For controls that render children, use this type of writer.</remarks>
	/// <example>
	/// public class MyLegacyRenderer : WebLegacyRenderer
	/// {
	///		new public MyControl Component
	///		{
	///			get { return (MyControl)base.Component; }
	///		}
	/// 
	///		public override void Render(BaseControlWriter writer)
	///		{
	///			//Writing the UI using the BaseControlWriter
	///		}
	/// }
	/// </example>
	public abstract class WebLegacyRenderer
	{
		private object _component = null;
		private Page _page = null;



		#region " Properties "

		/// <summary>
		/// Gets the component to render.
		/// </summary>
		public object Component
		{
			get { return _component; }
		}

		/// <summary>
		/// Gets the underlying page.
		/// </summary>
		public Page Page
		{
			get { return _page; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Initializes the component, passing the relevant information through to the local variables.  Other initialization work can be performed here.
		/// </summary>
		/// <param name="component">The component being rendered.</param>
		/// <param name="page">The page reference.</param>
		public virtual void Initialize(object component, Page page)
		{
			_component = component;
			_page = page;
		}

		/// <summary>
		/// Performs the actual rendering against a writer component.
		/// </summary>
		/// <param name="writer">The writer to render.</param>
		public abstract void Render(BaseControlWriter writer);

		#endregion
	}
}
