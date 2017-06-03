using System;


namespace Nucleo.Views
{
	/// <summary>
	/// Represents the view with the model.  Must be overridden to have value to the presenter.
	/// </summary>
	/// <typeparam name="TModel">The type of model to use.</typeparam>
	public interface IView<TModel> : IView, IViewModel<TModel>
	{
		
	}
}
