using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Presentation;
using Nucleo.Presentation.Modules;
using Nucleo.ModuleDemo.Views;


namespace Nucleo.ModuleDemo.Presentation
{
	public class FirstLookPresenter : BaseModularPresenter<IFirstLookView>
	{
		public FirstLookPresenter(IFirstLookView view)
			: base(view) 
		{
			view.Initializing += View_Initializing;
		}

		void View_Initializing(object sender, EventArgs e)
		{
			this.View.Model = new Models.FirstLookModel { Module = this.Module };
		}
	}
}
