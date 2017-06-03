using System;
using System.Reflection;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Configuration;
using Nucleo.Exceptions;
using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Web.Presentation.Configuration;
using Nucleo.Views;
using Nucleo.Presentation.Creation;


namespace Nucleo.Web.Views
{
	/// <summary>
	/// Represents a base class for views that are a part of the page as a user control.
	/// </summary>
	public abstract class BaseViewUserControl : UserControl, IView, IViewPresenterAssignment
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

		private void LinkPresenters()
		{
			Control parent = this.Parent;

			while (parent != null)
			{
				if (parent is IViewPresenterAssignment)
				{
					((IViewPresenterAssignment)parent).AddSubpresenter(_presenter);
					return;
				}

				parent = parent.Parent;
			}

			if (this.Page is IViewPresenterAssignment)
				((IViewPresenterAssignment)this.Page).AddSubpresenter(_presenter);
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

		#endregion



		#region " Original Lifecycle Methods "

		/// <summary>
		/// Processes the initializations.
		/// </summary>
		/// <param name="e">Default events.</param>
		protected override void OnInit(EventArgs e)
		{
			if (_presenter == null)
				this.StartupPresenter();

			if (_presenter != null)
				this.LinkPresenters();

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
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);

			this.OnUnloading(e);

			_presenter = null;
		}

		protected internal void StartupPresenter()
		{
			_presenter = this.CreatePresenter();

			WebViewHost host = WebViewHost.CreateOrGet();
			host.Process(this, _presenter);
		}

		#endregion
	}
}
