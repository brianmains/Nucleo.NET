using System;
using System.Reflection;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Configuration;
using Nucleo.Exceptions;
using Nucleo.Presentation;
using Nucleo.Views.Initialization;
using Nucleo.Web.Core;
using Nucleo.Web.Presentation;
using Nucleo.Web.Presentation.Configuration;
using Nucleo.Validation;
using Nucleo.Views;
using Nucleo.Web.Pages;
using Nucleo.Web.Description;
using Nucleo.Presentation.Creation;


namespace Nucleo.Web.Views
{
	/// <summary>
	/// Represents a base class for views that are a part of the page.
	/// </summary>
	public abstract class BaseViewPage : Page, IView, IViewPresenterAssignment
	{
		private IPresenter _presenter = null;



		#region " Events "

		/// <summary>
		/// Fires when the view is initializing.
		/// </summary>
		public event EventHandler Initializing;

		/// <summary>
		/// Fires when the view is loading.
		/// </summary>
		public event EventHandler Loading;

		/// <summary>
		/// Fires when the view is loaded.
		/// </summary>
		public event EventHandler Loaded;

		/// <summary>
		/// Fires when the view is starting.
		/// </summary>
		public event EventHandler Starting;

		/// <summary>
		/// Fires when the view is unloading.
		/// </summary>
		public event EventHandler Unloading;

		#endregion



		#region " Methods "

		void IViewPresenterAssignment.AddSubpresenter(IPresenter presenter)
		{
			if (_presenter == null)
				this.StartupPresenter();

			_presenter.Subpresenters.Add(presenter);
			presenter.Parent = _presenter;
		}

		/// <summary>
		/// Creates an instance of the presenter associated.
		/// </summary>
		/// <returns>The associated presenter instance.</returns>
		protected virtual IPresenter CreatePresenter()
		{
			IPresenter presenter = PresenterFactory.Create(this);

			if (presenter == null)
				throw new PresenterNotFoundException();

			return presenter;
		}

		private IWebContext GetWebContext()
		{
			if (_presenter is BaseWebPresenter)
				return ((BaseWebPresenter)_presenter).CurrentContext.Context;
			else
				return WebContext.GetCurrent();
		}

		protected virtual void OnInitializing(EventArgs e)
		{
			if (Initializing != null)
				Initializing(this, e);
		}

		protected virtual void OnLoaded(EventArgs e)
		{
			if (Loaded != null)
				Loaded(this, e);
		}

		protected virtual void OnLoading(EventArgs e)
		{
			if (Loading != null)
				Loading(this, e);

			if (this is IAjaxScriptableComponent)
			{
				IWebContext context = this.GetWebContext();
				((IAjaxScriptableComponent)this).GetCssReferences(context.ContentRegistrar);
			}
		}

		protected virtual void OnStarting(EventArgs e)
		{
			if (Starting != null)
				Starting(this, e);
		}

		protected virtual void OnUnloading(EventArgs e)
		{
			if (Unloading != null)
				Unloading(this, e);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (this is IAjaxScriptableComponent)
			{
				IWebContext context = this.GetWebContext();

				ComponentDescriptorCollection components = context.ContentRegistrar.GetComponentDescriptors();
				string script = string.Empty;

				foreach (ComponentDescriptor component in components)
				{
					//Register page scripts directly; register widgets separately
					if (component.ComponentType == "View")
						script += @"Sys.Application.add_load(function(sender, e) { $createView(" + component.GetScript() + "); });";
				}

				ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewPageRegistration", script, true);
			}

			base.Render(writer);
		}

		protected internal void StartupPresenter()
		{
			_presenter = this.CreatePresenter();

			IWebContext context = this.GetWebContext();
			WebViewHost host = WebViewHost.CreateOrGet(context);
			host.Process(this, _presenter);
		}

		#endregion



		#region " Lifecycle Event Handlers "

		/// <summary>
		/// Processes the initializations.
		/// </summary>
		/// <param name="e">Default events.</param>
		protected override void OnInit(EventArgs e)
		{
			if (_presenter == null)
				this.StartupPresenter();	

			if (!Page.IsPostBack)
				this.OnStarting(e);

			base.OnInit(e);

			this.OnInitializing(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			this.OnLoading(e);

			base.OnLoad(e);

			this.OnLoaded(e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this is IAjaxScriptableComponent)
			{
				IWebContext context = this.GetWebContext();

#if DEBUG
				ScriptReferencingRequestDetails reference = new ScriptReferencingRequestDetails(
					typeof(BaseAjaxViewPage).Assembly.GetName().Name, "Nucleo.Web.Views.BaseAjaxView.js", ScriptMode.Debug);
#else
				ScriptReferencingRequestDetails reference = new ScriptReferencingRequestDetails(
					typeof(BaseAjaxViewPage).Assembly.GetName().Name, "Nucleo.Web.Views.BaseAjaxView.js", ScriptMode.Release);
#endif
				context.ContentRegistrar.AddReference(reference);

				((IAjaxScriptableComponent)this).GetAjaxScriptDescriptors(context.ContentRegistrar, this);
				((IAjaxScriptableComponent)this).GetAjaxScriptReferences(context.ContentRegistrar);
			}
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);

			this.OnUnloading(e);

			_presenter = null;
		}

		#endregion
	}
}
