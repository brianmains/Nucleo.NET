using System;
using System.Web.UI;

using Nucleo.EventArguments;


namespace Nucleo.Web.Pages
{
	public class PageControllerWrapper : IPageDriver
	{
		private PageRequestContext _currentContext = null;
		private Page _page = null;



		#region " Events "

		public event EventHandler Initializing;

		public event EventHandler Loading;

		public event EventHandler PrepareToRender;

		public event RenderEventHandler Rendered;

		public event RenderEventHandler Rendering;

		public event EventHandler Startup;

		public event EventHandler Unloading;

		public event ValidateEventHandler ValidateState;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets the current context for the wrapper.
		/// </summary>
		public PageRequestContext CurrentContext
		{
			get { return _currentContext; }
			set { _currentContext = value; }
		}

		public bool IsInitialLoad
		{
			get { return !_page.IsPostBack; }
		}

		#endregion



		#region " Constructors "

		public PageControllerWrapper(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			_page = page;
		}

		#endregion
	}
}
