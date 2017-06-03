using System;
using System.Web.UI;
using System.Collections.Generic;

using Nucleo.EventArguments;
using Nucleo.Web.Pages;


namespace Nucleo.Web.Pages.Testing
{
	public class PageRunner : Page, IPageDriver
	{
		private ControlCollection _controls = null;
		private PageRequestContext _currentContext = null;
		private bool _isInitialLoad = false;



		#region " Events "

		public event EventHandler Initializing;

		public event EventHandler Loading;

		public event EventHandler PrepareToRender;

		public event EventArguments.RenderEventHandler Rendered;

		public event EventArguments.RenderEventHandler Rendering;

		public event EventHandler Startup;

		public event EventHandler Unloading;

		public event EventArguments.ValidateEventHandler ValidateState;

		#endregion



		#region " Properties "

		public ControlCollection Controls
		{
			get 
			{
				if (_controls == null)
					_controls = new ControlCollection(this.Page);
				return _controls; 
			}
		}

		/// <summary>
		/// Gets or sets the current context execution.
		/// </summary>
		public PageRequestContext CurrentContext
		{
			get { return _currentContext; }
			set { _currentContext = value; }
		}

		/// <summary>
		/// Gets or sets whether the current run is the initial load of the page.
		/// </summary>
		public bool IsInitialLoad
		{
			get { return _isInitialLoad; }
			set { _isInitialLoad = value; }
		}

		#endregion



		#region " Methods "

		public void AddControl(Control control)
		{
			this.Controls.Add(control);
			control.Page = this;
			this.Page.Controls.Add(control);
		}

		public void AddControls(IEnumerable<Control> controls)
		{
			foreach (Control control in controls)
			{
				this.Controls.Add(control);
				control.Page = this;
				this.Page.Controls.Add(control);
			}
		}

		public void FireEvent(PageControllerEvent evt)
		{
			switch (evt)
			{
				case PageControllerEvent.Initializing:
					this.OnInitializing(EventArgs.Empty);
					break;
				case PageControllerEvent.Loading:
					this.OnLoading(EventArgs.Empty);
					break;
				case PageControllerEvent.PrepareToRender:
					this.OnPrepareToRender(EventArgs.Empty);
					break;
				case PageControllerEvent.Rendered:
					this.OnRendered(new RenderEventArgs(null));
					break;
				case PageControllerEvent.Rendering:
					this.OnRendering(new RenderEventArgs(null));
					break;
				case PageControllerEvent.Startup:
					this.OnStartup(EventArgs.Empty);
					break;
				case PageControllerEvent.Unloading:
					this.OnUnloading(EventArgs.Empty);
					break;
				case PageControllerEvent.ValidateState:
					this.OnValidateState(new ValidateEventArgs());
					break;
				default:
					throw new NotImplementedException("The page controller event was not implemented");
			}
		}

		/// <summary>
		/// Fires events up to the specified index.
		/// </summary>
		/// <param name="evt">The event to run up to, and including.</param>
		public void FireEventsTo(PageControllerEvent evt)
		{
			int value = (int)evt;

			for (int index = 0; index <= value; index++)
			{
				if (index != (int)PageControllerEvent.Startup || this.IsInitialLoad)
					this.FireEvent((PageControllerEvent)index);
			}
		}
		
		protected virtual void OnInitializing(EventArgs e)
		{
			if (Initializing != null)
				Initializing(this, e);

			foreach (Control control in this.Controls)
			{
				if (control is BaseAjaxControl)
					((BaseAjaxControl)control).OnInitializing(e);
				else if (control is BaseAjaxExtender)
					((BaseAjaxExtender)control).OnInitializing(e);
				else if (control is BaseAjaxPanel)
					((BaseAjaxPanel)control).OnInitializing(e);
			}
		}

		protected internal void OnLoading(EventArgs e)
		{
			if (Loading != null)
				Loading(this, e);

			foreach (Control control in this.Controls)
			{
				if (control is BaseAjaxControl)
					((BaseAjaxControl)control).OnLoading(e);
				else if (control is BaseAjaxExtender)
					((BaseAjaxExtender)control).OnLoading(e);
				else if (control is BaseAjaxPanel)
					((BaseAjaxPanel)control).OnLoading(e);
			}
		}

		protected internal void OnPrepareToRender(EventArgs e)
		{
			if (PrepareToRender != null)
				PrepareToRender(this, e);

			foreach (Control control in this.Controls)
			{
				if (control is BaseAjaxControl)
					((BaseAjaxControl)control).OnPrepareToRender(e);
				else if (control is BaseAjaxExtender)
					((BaseAjaxExtender)control).OnPrepareToRender(e);
				else if (control is BaseAjaxPanel)
					((BaseAjaxPanel)control).OnPrepareToRender(e);
			}
		}

		protected internal void OnRendered(RenderEventArgs e)
		{
			if (Rendered != null)
				Rendered(this, e);

			foreach (Control control in this.Controls)
			{
				if (control is BaseAjaxControl)
					((BaseAjaxControl)control).OnRendered(e);
				else if (control is BaseAjaxPanel)
					((BaseAjaxPanel)control).OnRendered(e);
			}
		}

		protected internal void OnRendering(RenderEventArgs e)
		{
			if (Rendering != null)
				Rendering(this, e);

			foreach (Control control in this.Controls)
			{
				if (control is BaseAjaxControl)
					((BaseAjaxControl)control).OnRendering(e);
				else if (control is BaseAjaxPanel)
					((BaseAjaxPanel)control).OnRendering(e);
			}
		}

		protected internal void OnStartup(EventArgs e)
		{
			if (Startup != null)
				Startup(this, e);

			foreach (Control control in this.Controls)
			{
				if (control is BaseAjaxControl)
					((BaseAjaxControl)control).OnStartup(e);
				else if (control is BaseAjaxExtender)
					((BaseAjaxExtender)control).OnStartup(e);
				else if (control is BaseAjaxPanel)
					((BaseAjaxPanel)control).OnStartup(e);
			}
		}

		protected internal void OnUnloading(EventArgs e)
		{
			if (Unloading != null)
				Unloading(this, e);

			foreach (Control control in this.Controls)
			{
				if (control is BaseAjaxControl)
					((BaseAjaxControl)control).OnUnloading(e);
				else if (control is BaseAjaxExtender)
					((BaseAjaxExtender)control).OnUnloading(e);
				else if (control is BaseAjaxPanel)
					((BaseAjaxPanel)control).OnUnloading(e);
			}
		}

		/// <summary>
		/// Fires the validate state event when its time to validate a control's state.
		/// </summary>
		/// <param name="e">The validation details.</param>
		protected internal virtual void OnValidateState(ValidateEventArgs e)
		{
			if (ValidateState != null)
				ValidateState(this, e);

			foreach (Control control in this.Controls)
			{
				if (control is BaseAjaxControl)
					((BaseAjaxControl)control).OnValidateState(e);
				else if (control is BaseAjaxExtender)
					((BaseAjaxExtender)control).OnValidateState(e);
				else if (control is BaseAjaxPanel)
					((BaseAjaxPanel)control).OnValidateState(e);
			}
		}

		#endregion
	}
}
