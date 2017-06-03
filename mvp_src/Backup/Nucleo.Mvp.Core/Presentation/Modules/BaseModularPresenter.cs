using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Modules;
using Nucleo.Views;


namespace Nucleo.Presentation.Modules
{
	public class BaseModularPresenter : BasePresenter, IModularPresenter
	{
		/// <summary>
		/// Gets or sets the model tied to the presenter.
		/// </summary>
		public IModule Module
		{
			get;
			set;
		}


		public BaseModularPresenter(IView view)
			: base(view) { }
	}
}
