using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Modules;
using Nucleo.Views;


namespace Nucleo.Presentation.Modules
{
	public class BaseModularPresenter<TView, TModel> : BasePresenter<TView, TModel>, IModularPresenter
		where TView: IView<TModel>
		where TModel: class, new()
	{
		/// <summary>
		/// Gets or sets the model tied to the presenter.
		/// </summary>
		public IModule Module
		{
			get;
			set;
		}



		public BaseModularPresenter(TView view)
			: base(view) { }
	}
}
