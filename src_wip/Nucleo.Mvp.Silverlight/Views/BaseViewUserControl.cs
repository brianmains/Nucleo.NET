using System;
using System.Windows;
using System.Windows.Controls;

using Nucleo.Presentation;
using Nucleo.Views;


namespace Nucleo.Views
{
	public abstract class BaseViewUserControl : UserControl, IView, IViewPresenterAssignment
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

		public BaseViewUserControl()
		{
			this.LoadPresenter();
			base.Loaded += new RoutedEventHandler(BaseViewUserControl_Loaded);
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

			this.LoadSubpresenter();
		}

		private void LoadSubpresenter()
		{
			object parent = this.Parent;

			while (parent != null)
			{
				if (parent is IView)
				{
					((IViewPresenterAssignment)parent).AddSubpresenter(_presenter);
				}

				if (parent is FrameworkElement)
					parent = ((FrameworkElement)parent).Parent;
				else
					parent = null;
			}
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

		void BaseViewUserControl_Loaded(object sender, RoutedEventArgs e)
		{
			this.OnStarting(EventArgs.Empty);
			this.OnInitializing(EventArgs.Empty);
			this.OnLoading(EventArgs.Empty);
			this.OnLoaded(EventArgs.Empty);
		}

		#endregion
	}
}
