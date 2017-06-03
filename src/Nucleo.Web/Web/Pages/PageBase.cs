using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nucleo.EventArguments;
using Nucleo.Exceptions;
using Nucleo.State;
using Nucleo.Global.Configuration;
using Nucleo.EventArguments;
using Nucleo.Security;
using Nucleo.Reflection;
using Nucleo.Web.Controls;
using Nucleo.Collections;
using Nucleo.Web.Core;
using Nucleo.Context;


namespace Nucleo.Web.Pages
{
	public class PageBase : Page, IPageDriver
	{
		private PageRequestContext _currentContext = null;



		#region " Events "

		public event EventHandler Initializing;

		public event EventHandler Loading;

		public event EventHandler PrepareToRender;

		public event RenderEventHandler Rendered;

		public event RenderEventHandler Rendering;

		public event EventHandler Startup;

		public event EventHandler Unloading;

		public event ValidateEventHandler ValidateState;

		public event DataCancelEventHandler<string> Redirecting;

		public event EventHandler Validated;

		public event CancelEventHandler Validating;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the current request context for the page.
		/// </summary>
		public PageRequestContext CurrentContext
		{
			get 
			{
				if (_currentContext == null)
					_currentContext = PageRequestContext.Create();
				return _currentContext; 
			}
			set { _currentContext = value; }
		}

		/// <summary>
		/// Gets whether the page is loading initially.
		/// </summary>
		public bool IsInitialLoad
		{
			get { return !Page.IsPostBack; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Because of master pages, to find the control with that ID, the method must loop through all of the page controls, and use findcontrol on that object.
		/// </summary>
		/// <param name="controlID">The ID of the control to find.</param>
		/// <returns>An instance of the control, or null if not found.</returns>
		public override Control FindControl(string controlID)
		{
			Control controlReference = base.FindControl(controlID);
			if (controlReference != null)
				return controlReference;

			foreach (Control control in this.Controls)
			{
				Control findControl = control.FindControl(controlID);
				if (findControl != null) return findControl;
			}

			return null;
		}

		/// <summary>
		/// Gets a typed version of the control, found from the control ID value provided.
		/// </summary>
		/// <typeparam name="T">The type to convert the control to.</typeparam>
		/// <param name="controlID">The ID of the control in the collection.</param>
		/// <returns>A strongly typed instance of the control, or nothing if not found.</returns>
		public T FindControl<T>(string controlID) where T : Control
		{
			return this.FindControl(controlID) as T;
		}

		/// <summary>
		/// Gets controls of a specific type, and returns them as an array.
		/// </summary>
		/// <typeparam name="T">The type to look for in the collection.</typeparam>
		/// <returns>An instance of a strongly-typed control collection.</returns>
		public virtual T[] FindControlsOfType<T>() where T:Control
		{
			List<T> controls = new List<T>();

			foreach (Control control in this.Controls)
			{
				if (control is T)
					controls.Add((T)control);
			}

			return controls.ToArray();
		}

		/// <summary>
		/// Validates that the state of the control is OK.
		/// </summary>
		/// <exception cref="ValidateException">Thrown when the control isn't valid.</exception>
		private void IsValidateStateOK()
		{
			ValidateEventArgs vargs = new ValidateEventArgs();
			this.OnValidateState(vargs);

			if (!vargs.IsValid)
				throw new ValidateException("The control didn't validate correctly");
		}

		protected internal virtual void OnInitializing(EventArgs e)
		{
			if (Initializing != null)
				Initializing(this, e);
		}

		protected internal virtual void OnLoading(EventArgs e)
		{
			if (Loading != null)
				Loading(this, e);
		}

		protected internal virtual void OnPrepareToRender(EventArgs e)
		{
			if (PrepareToRender != null)
				PrepareToRender(this, e);
		}

		/// <summary>
		/// Raises the redirecting event.
		/// </summary>
		/// <param name="e">The details regarding the redirection.</param>
		protected virtual void OnRedirecting(DataCancelEventArgs<string> e)
		{
			if (Redirecting != null)
				Redirecting(this, e);
		}

		protected internal virtual void OnRendered(RenderEventArgs e)
		{
			if (Rendered != null)
				Rendered(this, e);
		}

		protected internal virtual void OnRendering(RenderEventArgs e)
		{
			if (Rendering != null)
				Rendering(this, e);
		}

		protected internal virtual void OnStartup(EventArgs e)
		{
			if (Startup != null)
				Startup(this, e);
		}

		protected internal virtual void OnUnloading(EventArgs e)
		{
			if (Unloading != null)
				Unloading(this, e);
		}

		/// <summary>
		/// Raises the validated event.
		/// </summary>
		/// <param name="e">Empty.</param>
		protected internal virtual void OnValidated(EventArgs e)
		{
			if (Validated != null)
				Validated(this, e);
		}

		/// <summary>
		/// Raises the validating event.
		/// </summary>
		/// <param name="e">Empty.</param>
		protected internal virtual void OnValidating(CancelEventArgs e)
		{
			if (Validating != null)
				Validating(this, e);
		}

		/// <summary>
		/// Fires the validate state event when its time to validate a control's state.
		/// </summary>
		/// <param name="e">The validation details.</param>
		protected internal virtual void OnValidateState(ValidateEventArgs e)
		{
			if (ValidateState != null)
				ValidateState(this, e);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			RenderEventArgs e = new RenderEventArgs(new HtmlStreamControlWriter(writer));
			this.OnRendering(e);

			base.Render(writer);

			this.OnRendered(e);
		}

		/// <summary>
		/// Calls the appropriate events before performing the validation.
		/// </summary>
		public override void Validate()
		{
			CancelEventArgs args = new CancelEventArgs(false);
			this.OnValidating(args);

			if (!args.Cancel)
			{
				base.Validate();
				this.OnValidated(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Calls the appropriate events before performing the validation.
		/// </summary>
		/// <param name="validationGroup">The group to validate.</param>
		public override void Validate(string validationGroup)
		{
			CancelEventArgs args = new CancelEventArgs(false);
			this.OnValidating(args);

			if (!args.Cancel)
			{
				base.Validate(validationGroup);
				this.OnValidated(EventArgs.Empty);
			}
		}

		#endregion



		#region " Lifecycle Methods "

		protected override void OnInit(EventArgs e)
		{
			//TODO:Update with new navigation service
			base.OnInit(e);

			if (this.IsInitialLoad)
				this.OnStartup(e);
			//if (!this.Services.Navigation.IsRedirecting)
			this.OnInitializing(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			//TODO:Update with new navigation service
			//if (!this.Services.Navigation.IsRedirecting)
			

			base.OnLoad(e);

			//if (!this.Services.Navigation.IsRedirecting)
			this.OnLoading(e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			this.IsValidateStateOK();

			base.OnPreRender(e);
			this.OnPrepareToRender(e);
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			this.OnUnloading(e);
		}

		#endregion
	}
}