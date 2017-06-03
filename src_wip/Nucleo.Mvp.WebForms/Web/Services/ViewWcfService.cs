using System;
using System.Web;
using System.Web.Services;

using Nucleo.Configuration;
using Nucleo.Exceptions;
using Nucleo.Presentation;
using Nucleo.Web.Views;
using Nucleo.Views;
using Nucleo.Presentation.Creation;


namespace Nucleo.Web.Services
{
	/// <summary>
	/// Represents the base class for WCF services that act as a view.
	/// </summary>
	public abstract class ViewWcfService : IView
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



		#region " Constructors "

		protected ViewWcfService()
		{
			_presenter = this.CreatePresenter();

			this.OnStarting(EventArgs.Empty);
			this.OnInitializing(EventArgs.Empty);
			this.OnLoading(EventArgs.Empty);
			this.OnLoaded(EventArgs.Empty);
			this.OnUnloading(EventArgs.Empty);	
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates an instance of the presenter associated.
		/// </summary>
		/// <returns>The associated presenter instance.</returns>
		protected virtual IPresenter CreatePresenter()
		{
			//FrameworkSettingsSection section = FrameworkSettingsSection.Instance;
			//IPresenterCreator creator = null;

			//if (section != null && !string.IsNullOrEmpty(section.PresenterCreatorTypeName))
			//{
			//    Type creatorType = Type.GetType(section.PresenterCreatorTypeName);
			//    if (creatorType == null)
			//        throw new NotFoundException(string.Format("The type for the creator specified as '{0}' could not be found.", section.PresenterCreatorTypeName));

			//    creator = (IPresenterCreator)Activator.CreateInstance(creatorType);
			//}

			//PresentationManager mgr = (creator != null)
			//    ? PresentationManager.Create(new PresenterOptions { Creator = creator })
			//    : PresentationManager.Create();
			//IPresenter presenter = mgr.Load(this);

			IPresenter presenter = PresenterFactory.Create(this);

			if (presenter == null)
				throw new PresenterNotFoundException();

			return presenter;
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
	}
}
