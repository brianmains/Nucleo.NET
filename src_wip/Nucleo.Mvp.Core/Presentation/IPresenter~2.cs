using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Views;
using Nucleo.Presentation.Context;


namespace Nucleo.Presentation
{
	public interface IPresenter<TView, TModel> : IPresenter<TView>
		where TView : IView<TModel>
	{
	}
}
