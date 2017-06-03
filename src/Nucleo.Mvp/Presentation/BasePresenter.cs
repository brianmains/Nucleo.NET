using System;
using System.Collections.Generic;

using Nucleo.EventsManagement;
using Nucleo.Views;
using Nucleo.State;


namespace Nucleo.Presentation
{
	/// <summary>
	/// Represents the base class for the presenter.
	/// </summary>
	public class BasePresenter : IPresenter
	{
		private PresenterContext _currentContext = null;
		private PresenterCollection _subpresenters = null;
		private IView _view = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the current context for the presenter execution.
		/// </summary>
		public PresenterContext CurrentContext
		{
			get 
			{
				if (_currentContext == null)
					_currentContext = this.CreatePresenterContext();
				return _currentContext; 
			}
			set { _currentContext = value; }
		}

		/// <summary>
		/// Gets whether the presenter has the current context.
		/// </summary>
		public bool HasCurrentContext
		{
			get { return (_currentContext != null); }
		}

		public IPresenter Parent
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the collection of child presenters.
		/// </summary>
		public PresenterCollection Subpresenters
		{
			get
			{
				if (_subpresenters == null)
					_subpresenters = new PresenterCollection();
				return _subpresenters;
			}
		}

		/// <summary>
		/// Gets the instance of the view.
		/// </summary>
		public IView View
		{
			get { return _view; }
		}

		#endregion



		#region " Constructors "
		
		/// <summary>
		/// Creates the presenter.
		/// </summary>
		/// <param name="view">The view related to the presenter.</param>
		public BasePresenter(IView view)
		{
			_view = view;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates the presenter context.
		/// </summary>
		/// <returns>The created presenter context.</returns>
		protected virtual PresenterContext CreatePresenterContext()
		{
			return PresenterContextInternal.CreateContextOrGetFromCache();
		}

		#endregion
	}
}
