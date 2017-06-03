using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Nucleo.Presentation;
using Nucleo.Views;


namespace Nucleo.Views
{
	public abstract class BaseViewAppHostUserControl : UserControl, IView, IViewPresenterAssignment
	{
		private IPresenter _presenter = null;



		#region " Events "

		public event EventHandler Initializing;

		public new event EventHandler Loaded;

		public event EventHandler Loading;

		public event EventHandler Starting;

		public event EventHandler Unloading;

		#endregion



		#region " Constructors "

		public BaseViewAppHostUserControl()
		{
			this.LoadPresenter();

			base.Loaded += new RoutedEventHandler(BaseViewAppHostUserControl_Loaded);
		}

		#endregion



		#region " Methods "

		void IViewPresenterAssignment.AddSubpresenter(IPresenter presenter)
		{
			if (presenter == null)
				throw new ArgumentNullException("presenter");

			_presenter.Subpresenters.Add(presenter);
		}

		private void LoadPresenter()
		{
			_presenter = PresenterFactory.Create(this);
			if (_presenter == null)
				throw new InvalidOperationException("Could not find a presenter for view: " + this.GetType().FullName);
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



		#region " Lifecycle Methods "

		void BaseViewAppHostUserControl_Loaded(object sender, RoutedEventArgs e)
		{
			this.OnStarting(EventArgs.Empty);
			this.OnInitializing(EventArgs.Empty);
			this.OnLoading(EventArgs.Empty);
			this.OnLoaded(EventArgs.Empty);
		}

		#endregion
	}
}
