using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Views;


namespace Nucleo.Presentation
{
	public class BasePresenter<TView, TModel> : BasePresenter<TView>, IPresenter<TView, TModel>
		where TView : IView<TModel>
		where TModel : class, new()
	{
		#region " Constructors "

		public BasePresenter(TView view)
			: base(view) { }
		
		#endregion
	}
}
