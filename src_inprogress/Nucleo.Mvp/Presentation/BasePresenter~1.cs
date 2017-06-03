using System;

using Nucleo.Views;


namespace Nucleo.Presentation
{
	/// <summary>
	/// Represents a base presenter with a generic form of the view.
	/// </summary>
	/// <typeparam name="TView">The type of view that implements the <see cref="IView">IView interface</see>.</typeparam>
	public class BasePresenter<TView> : BasePresenter, IPresenter<TView>
		where TView: IView
	{
		#region " Properties "

		/// <summary>
		/// Gets the strongly-typed version of the view.
		/// </summary>
		public TView View
		{
			get { return (TView)base.View; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the presenter.
		/// </summary>
		/// <param name="view">The view.</param>
		public BasePresenter(TView view)
			: base(view)
		{
			
		}

		#endregion



		#region " Methods "

		

		#endregion
	}
}
