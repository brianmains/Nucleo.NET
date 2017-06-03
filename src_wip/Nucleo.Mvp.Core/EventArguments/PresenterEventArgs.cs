using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Presentation;
using Nucleo.Views;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents the event arguments for the presenter.
	/// </summary>
	public class PresenterEventArgs : EventArgs
	{
		private IPresenter _presenter = null;
		private IView _view = null;



		#region " Properties "

		/// <summary>
		/// Gets the presenter instance.
		/// </summary>
		public IPresenter Presenter
		{
			get { return _presenter; }
		}

		/// <summary>
		/// Gets the view instance.
		/// </summary>
		public IView View
		{
			get { return _view; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the event args.
		/// </summary>
		/// <param name="presenter">The presenter instance.</param>
		/// <param name="view">The view instance.</param>
		public PresenterEventArgs(IPresenter presenter, IView view)
		{
			_presenter = presenter;
			_view = view;
		}

		#endregion
	}

	public delegate void PresenterEventHandler(object sender, PresenterEventArgs e);
}
